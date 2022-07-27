using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intent.Engine;
using Intent.Modelers.Domain.Api;
using Intent.Modelers.Services.Api;
using Intent.Modelers.Services.CQRS.Api;
using Intent.Modules.Application.MediatR.CRUD.Decorators;
using Intent.Modules.Application.MediatR.Templates;
using Intent.Modules.Application.MediatR.Templates.CommandHandler;
using Intent.Modules.Common.Templates;

namespace Intent.Modules.Application.MediatR.CRUD.CrudStrategies
{
    class UpdateImplementationStrategy : ICrudImplementationStrategy
    {
        private readonly CommandHandlerTemplate _template;
        private readonly IApplication _application;
        private readonly IMetadataManager _metadataManager;
        private readonly Lazy<StrategyData> _matchingElementDetails;

        public UpdateImplementationStrategy(CommandHandlerTemplate template, IApplication application,
            IMetadataManager metadataManager)
        {
            _template = template;
            _application = application;
            _metadataManager = metadataManager;
            _matchingElementDetails = new Lazy<StrategyData>(GetMatchingElementDetails);
        }

        public bool IsMatch()
        {
            return _matchingElementDetails.Value.IsMatch;
        }

        public IEnumerable<RequiredService> GetRequiredServices()
        {
            return new[]
            {
                _matchingElementDetails.Value.Repository
            };
        }

        public string GetImplementation()
        {
            var foundEntity = _matchingElementDetails.Value.FoundEntity;
            var repository = _matchingElementDetails.Value.Repository;
            var idField = _matchingElementDetails.Value.IdField;

            return
                $@"var existing{foundEntity.Name} = await {repository.FieldName}.FindByIdAsync(request.{idField.Name.ToPascalCase()}, cancellationToken);
                {GetPropertyAssignments(foundEntity, _template.Model)}
                return Unit.Value;";
        }

        private StrategyData GetMatchingElementDetails()
        {
            var matchingEntities = _metadataManager.Domain(_application)
                .GetClassModels().Where(x => new[]
                {
                    $"update{x.Name.ToLower()}",
                    $"update{x.Name.ToLower()}details",
                    $"edit{x.Name.ToLower()}",
                    $"edit{x.Name.ToLower()}details",
                }.Contains(_template.Model.Name.ToLower().RemoveSuffix("command"))).ToList();

            if (matchingEntities.Count() != 1)
            {
                return NoMatch;
            }

            var foundEntity = matchingEntities.Single();

            var idField = _template.Model.Properties.FirstOrDefault(p =>
                string.Equals(p.Name, "id", StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(p.Name, $"{foundEntity.Name}Id", StringComparison.InvariantCultureIgnoreCase));
            if (idField == null)
            {
                return NoMatch;
            }

            var repositoryInterface = _template.GetEntityRepositoryInterfaceName(foundEntity);
            if (repositoryInterface == null)
            {
                return NoMatch;
            }

            var repository = new RequiredService(type: repositoryInterface,
                name: repositoryInterface.Substring(1).ToCamelCase());
            
            return new StrategyData(true, foundEntity, idField, repository);
        }

        private string GetPropertyAssignments(ClassModel domainModel, CommandModel command)
        {
            var sb = new StringBuilder();
            foreach (var property in command.Properties.Where(x => !x.Equals(_matchingElementDetails.Value.IdField)))
            {
                var attribute = property.Mapping?.Element != null
                    ? property.Mapping.Element.AsAttributeModel()
                    : domainModel.Attributes.FirstOrDefault(p =>
                        p.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase));
                if (attribute == null)
                {
                    sb.AppendLine($"                #warning No matching field found for {property.Name}");
                    continue;
                }

                if (attribute.Type.Element.Id != property.TypeReference.Element.Id)
                {
                    sb.AppendLine(
                        $"                #warning No matching type for Domain: {attribute.Name} and DTO: {property.Name}");
                    continue;
                }

                sb.AppendLine(
                    $"                existing{_matchingElementDetails.Value.FoundEntity.Name}.{attribute.Name.ToPascalCase()} = request.{property.Name.ToPascalCase()};");
            }

            return sb.ToString().Trim();
        }

        private static readonly StrategyData NoMatch = new StrategyData(false, null, null, null);

        private class StrategyData
        {
            public StrategyData(bool isMatch, ClassModel foundEntity, DTOFieldModel idField, RequiredService repository)
            {
                IsMatch = isMatch;
                FoundEntity = foundEntity;
                IdField = idField;
                Repository = repository;
            }

            public bool IsMatch { get; }
            public ClassModel FoundEntity { get; }
            public DTOFieldModel IdField { get; }
            public RequiredService Repository { get; }
        }
    }
}