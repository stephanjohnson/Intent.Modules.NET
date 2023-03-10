using System.Collections.Generic;
using Intent.Modules.Common.Templates;
using Intent.Modules.CosmosDb.Templates.CosmosDbContext;
using Intent.Modules.CosmosDb.Templates.CosmosDbUnitOfWorkInterface;
using Intent.Modules.CosmosDb.Templates.Integration.UnitOfWorkBehaviour;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: DefaultIntentManaged(Mode.Fully, Targets = Targets.Usings)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateExtensions", Version = "1.0")]

namespace Intent.Modules.CosmosDb.Templates
{
    public static class TemplateExtensions
    {

        public static string GetCosmosDbContextName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(CosmosDbContextTemplate.TemplateId);
        }

        public static string GetCosmosDbUnitOfWorkInterfaceName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(CosmosDbUnitOfWorkInterfaceTemplate.TemplateId);
        }

        public static string GetUnitOfWorkBehaviourName<T>(this IntentTemplateBase<T> template)
        {
            return template.GetTypeName(UnitOfWorkBehaviourTemplate.TemplateId);
        }

    }
}