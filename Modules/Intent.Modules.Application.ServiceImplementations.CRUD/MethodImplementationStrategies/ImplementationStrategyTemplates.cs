using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.Domain.Api;
using Intent.Modelers.Services.Api;
using Intent.Modules.Application.Dtos.Templates.DtoModel;
using Intent.Modules.Application.ServiceImplementations.Conventions.CRUD.Decorators;
using Intent.Modules.Common.Templates;

namespace Intent.Modules.Application.ServiceImplementations.Conventions.CRUD.MethodImplementationStrategies;

static class ImplementationStrategyTemplates
{
    public static bool HasDomainEntityName(this CrudConventionDecorator decorator, ClassModel domainModel)
    {
        return !string.IsNullOrEmpty(decorator.GetDomainEntityName(domainModel));
    }

    public static bool HasEntityRepositoryInterfaceName(this CrudConventionDecorator decorator, ClassModel domainModel)
    {
        return !string.IsNullOrEmpty(decorator.GetEntityRepositoryInterfaceName(domainModel));
    }

    public static bool HasDtoName(this CrudConventionDecorator decorator, ICanBeReferencedType reference)
    {
        return reference != null && !string.IsNullOrEmpty(decorator.GetDtoName(reference));
    }
    
    public static string GetDomainEntityName(this CrudConventionDecorator decorator, ClassModel domainModel)
    {
        var entityName = decorator.Template
            .GetTypeName("Domain.Entity", domainModel, TemplateDiscoveryOptions.DoNotThrow);
        return entityName;
    }

    public static string GetEntityRepositoryInterfaceName(this CrudConventionDecorator decorator, ClassModel domainModel)
    {
        var repo = decorator.Template.GetTypeName("Repository.Interface.Entity", domainModel, TemplateDiscoveryOptions.DoNotThrow);
        return repo;
    }
    
    public static string GetDtoName(this CrudConventionDecorator decorator, ICanBeReferencedType reference)
    {
        var dto = decorator.FindDTOModel(reference.Id);
        var dtoTemplate = decorator.Template.GetTemplate<IClassProvider>(DtoModelTemplate.TemplateId, dto, TemplateDiscoveryOptions.DoNotThrow);
        if (dtoTemplate == null)
        {
            return null;
        }

        return dtoTemplate.ClassName;
    }
}