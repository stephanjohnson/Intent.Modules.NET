﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Application.Contracts;
using Intent.Modules.Application.ServiceImplementations.Templates.ServiceImplementation;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modelers.Domain.Api;
using Intent.Modelers.Services.Api;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Constants;
using Intent.Modules.Entities.Repositories.Api.Templates;
using JetBrains.Annotations;
using OperationModel = Intent.Modelers.Services.Api.OperationModel;

namespace Intent.Modules.Application.ServiceImplementations.Conventions.CRUD.MethodImplementationStrategies
{
    public class UpdateImplementationStrategy : IImplementationStrategy
    {
        private readonly ServiceImplementationTemplate _template;
        private readonly IApplication _application;

        public UpdateImplementationStrategy(ServiceImplementationTemplate template, IApplication application)
        {
            _template = template;
            _application = application;
        }

        public bool IsMatch(OperationModel operationModel)
        {
            if (operationModel.Parameters.Count != 2)
            {
                return false;
            }
            
            if (!operationModel.Parameters.Any(p => p.Name.Contains("id", StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            if (operationModel.TypeReference.Element != null)
            {
                return false;
            }

            var dtoModel = operationModel.Parameters.FirstOrDefault(x => x.TypeReference?.Element?.IsDTOModel() == true)?.TypeReference?.Element?.AsDTOModel();
            if (dtoModel == null)
            {
                return false;
            }

            var domainModel = dtoModel.Mapping?.Element?.AsClassModel();
            if (domainModel == null)
            {
                return false;
            }

            if (dtoModel.Fields.GetEntityIdField(domainModel) == null)
            {
                return false;
            }

            var lowerOperationName = operationModel.Name.ToLower();
            return new[] { "put", "update" }.Any(x => lowerOperationName.Contains(x));
        }

        public void ApplyStrategy(OperationModel operationModel)
        {
            _template.AddTypeSource(TemplateFulfillingRoles.Domain.Entity.Primary);
            _template.AddTypeSource(TemplateFulfillingRoles.Domain.ValueObject);
            _template.AddUsing("System.Linq");
            
            var dtoModel = operationModel.Parameters.FirstOrDefault(x => x.TypeReference.Element.IsDTOModel()).TypeReference.Element.AsDTOModel();
            var domainModel = dtoModel.Mapping.Element.AsClassModel();
            var domainType = _template.TryGetTypeName(TemplateFulfillingRoles.Domain.Entity.Primary, domainModel, out var result)
                ? result
                : domainModel.Name;
            var domainTypePascalCased = domainType.ToPascalCase();
            var domainTypeCamelCased = domainType.ToCamelCase();
            var repositoryTypeName = _template.GetEntityRepositoryInterfaceName(domainModel);
            var repositoryFieldName = $"{domainTypeCamelCased}Repository";
            var idField = dtoModel.Fields.GetEntityIdField(domainModel);
            var dtoParam = operationModel.Parameters.First(p => !p.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase));
            
            var codeLines = new CSharpStatementAggregator();
            codeLines.Add(
                $"var existing{domainTypePascalCased} = await {repositoryFieldName.ToPrivateMemberName()}.FindByIdAsync({operationModel.Parameters.First(p => p.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase)).Name});");
            codeLines.AddRange(GetDTOPropertyAssignments($"existing{domainTypePascalCased}", dtoParam.Name, domainModel.InternalElement, dtoModel.Fields, true));
            
            var @class = _template.CSharpFile.Classes.First();
            var method = @class.FindMethod(m => m.Name.Equals(operationModel.Name, StringComparison.OrdinalIgnoreCase));
            var attr = method.Attributes.OfType<CSharpIntentManagedAttribute>().FirstOrDefault();
            if (attr == null)
            {
                attr = CSharpIntentManagedAttribute.Fully();
                method.AddAttribute(attr);
            }
            attr.WithBodyFully();
            method.Statements.Clear();
            method.AddStatements(codeLines.ToList());

            var ctor = @class.Constructors.First();
            if (ctor.Parameters.All(p => p.Name != repositoryFieldName))
            {
                ctor.AddParameter(repositoryTypeName, repositoryFieldName, parm => parm.IntroduceReadonlyField());
            }
        }
        
        private IList<CSharpStatement> GetDTOPropertyAssignments(string entityVarName, string dtoVarName, IElement domainModel, IList<DTOFieldModel> dtoFields, bool skipIdField)
        {
            var codeLines = new CSharpStatementAggregator();
            foreach (var field in dtoFields)
            {
                if (skipIdField && field.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (field.Mapping?.Element == null
                    && domainModel.ChildElements.All(p => p.Name != field.Name))
                {
                    codeLines.Add($"#warning No matching field found for {field.Name}");
                    continue;
                }

                switch (field.Mapping?.Element?.SpecializationTypeId)
                {
                    default:
                        var mappedPropertyName = field.Mapping?.Element?.Name ?? "<null>";
                        codeLines.Add($"#warning No matching type for Domain: {mappedPropertyName} and DTO: {field.Name}");
                        break;
                    case null:
                    case AttributeModel.SpecializationTypeId:
                        var attribute = field.Mapping?.Element
                                        ?? domainModel.ChildElements.First(p => p.Name == field.Name);
                        if (field.TypeReference.IsCollection)
                        {
                            codeLines.Add($"{entityVarName}.{attribute.Name.ToPascalCase()} = {dtoVarName}.{field.Name.ToPascalCase()}.ToList();");
                            break;
                        }
                        codeLines.Add($"{entityVarName}.{attribute.Name.ToPascalCase()} = {dtoVarName}.{field.Name.ToPascalCase()};");
                        break;
                    case AssociationTargetEndModel.SpecializationTypeId:
                        {
                            var association = field.Mapping.Element.AsAssociationTargetEndModel();
                            var targetEntityElement = (IElement)association.Element;
                            var attributeName = association.Name.ToPascalCase();

                            if (association.Association.AssociationType == AssociationType.Aggregation)
                            {
                                codeLines.Add($@"#warning Field not a composite association: {field.Name.ToPascalCase()}");
                                break;
                            }

                            if (association.Multiplicity is Multiplicity.One or Multiplicity.ZeroToOne)
                            {
                                if (field.TypeReference.IsNullable)
                                {
                                _template.AddUsing(_template.GetTemplate<IClassProvider>("Domain.Common.UpdateHelper").Namespace);
                                    codeLines.Add($"{entityVarName}.{attributeName} = {dtoVarName}.{field.Name.ToPascalCase()} != null");
                                    codeLines.Add($"? ({entityVarName}.{attributeName} ?? new {targetEntityElement.Name.ToPascalCase()}()).UpdateObject({dtoVarName}.{field.Name.ToPascalCase()}, {GetUpdateMethodName(targetEntityElement, attributeName)})", s => s.Indent());
                                    codeLines.Add($": null;", s => s.Indent());
                                }
                                else
                                {
                                    _template.AddUsing(_template.GetTemplate<IClassProvider>("Domain.Common.UpdateHelper").Namespace);
                                    codeLines.Add($"{entityVarName}.{attributeName}.UpdateObject({dtoVarName}.{field.Name.ToPascalCase()}, {GetUpdateMethodName(targetEntityElement, attributeName)});");
                                }
                            }
                            else
                            {
                                _template.AddUsing(_template.GetTemplate<IClassProvider>("Domain.Common.UpdateHelper").Namespace);
                                var targetClass = targetEntityElement.AsClassModel();
                                var targetDto = field.TypeReference.Element.AsDTOModel();
                                codeLines.Add($"{entityVarName}.{attributeName}{(field.TypeReference.IsNullable ? "?" : "")}.UpdateCollection({dtoVarName}.{field.Name.ToPascalCase()}, (e, d) => e.{targetClass.GetEntityIdAttribute().IdName} == d.{targetDto.Fields.GetEntityIdField(targetClass).Name.ToPascalCase()}, {GetUpdateMethodName(targetEntityElement, attributeName)});");
                            }

                            var @class = _template.CSharpFile.Classes.First();
                            @class.AddMethod("void",
                                GetUpdateMethodName(targetEntityElement, attributeName),
                                method => method.Private()
                                    .Static()
                                    .AddAttribute(CSharpIntentManagedAttribute.Fully())
                                    .AddParameter(_template.GetTypeName(targetEntityElement), "entity")
                                    .AddParameter(_template.GetTypeName((IElement)field.TypeReference.Element), "dto")
                                    .AddStatements(GetDTOPropertyAssignments("entity", "dto", targetEntityElement, ((IElement)field.TypeReference.Element).ChildElements.Where(x => x.IsDTOFieldModel()).Select(x => x.AsDTOFieldModel()).ToList(), true)));
                        }
                        break;
                }
            }

            return codeLines.ToList();
        }

        private string GetUpdateMethodName(IElement classModel, [CanBeNull] string attibuteName)
        {
            return $"Update{classModel.Name.ToPascalCase()}";
        }
    }
}