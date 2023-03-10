using System.Linq;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Configuration;
using Intent.Modules.Common.CSharp.DependencyInjection;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.CSharp.VisualStudio;
using Intent.Modules.Common.Plugins;
using Intent.Modules.Common.Templates;
using Intent.Modules.Constants;
using Intent.Modules.CosmosDb.Templates.CosmosDbContext;
using Intent.Modules.CosmosDb.Templates.CosmosDbUnitOfWorkInterface;
using Intent.Plugins.FactoryExtensions;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.FactoryExtension", Version = "1.0")]

namespace Intent.Modules.CosmosDb.FactoryExtensions
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    public class DependencyInjectionFactoryExtension : FactoryExtensionBase
    {
        public override string Id => "Intent.CosmosDb.DependencyInjectionFactoryExtension";

        private const string ConfigSectionCosmos = "Cosmos";

        public override int Order => 0;

        protected override void OnAfterTemplateRegistrations(IApplication application)
        {
            var dbContext = application.FindTemplateInstance<ICSharpTemplate>(TemplateDependency.OnTemplate(CosmosDbContextTemplate.TemplateId));
            if (dbContext == null)
            {
                return;
            }

            var dependencyInjection = application.FindTemplateInstance<ICSharpFileBuilderTemplate>(TemplateFulfillingRoles.Infrastructure.DependencyInjection);
            if (dependencyInjection == null)
            {
                return;
			}

			dependencyInjection.AddUsing("Microsoft.Azure.Cosmos");

			dependencyInjection.CSharpFile.OnBuild(file =>
            {
                file.Classes.First().FindMethod("AddInfrastructure")
                    .AddStatement(new CSharpInvocationStatement($"services.AddScoped<{dependencyInjection.GetTypeName(dbContext.Id)}>")
                            .AddArgument(new CSharpLambdaBlock("provider")
                                .AddStatement($@"var accountEndpoint = configuration[""Cosmos:AccountEndpoint""];")
								.AddStatement($@"var accountKey = configuration[""Cosmos:AccountKey""];")
								.AddStatement($@"var databaseName = configuration[""Cosmos:DatabaseName""];")
								.AddStatement($@"var cosmosClient = new CosmosClient(accountEndpoint, accountKey);")
                                .AddStatement($@"return new {dependencyInjection.GetTypeName(dbContext.Id)}(cosmosClient, databaseName);"))
                            .WithArgumentsOnNewLines(),
                        stmt => stmt.AddMetadata("application-cosmosdb-context", true));
            });

            application.EventDispatcher.Publish(new AppSettingRegistrationRequest($"{ConfigSectionCosmos}:AccountEndpoint", "https://localhost:8081"));
            application.EventDispatcher.Publish(new AppSettingRegistrationRequest($"{ConfigSectionCosmos}:AccountKey", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="));
            application.EventDispatcher.Publish(new AppSettingRegistrationRequest($"{ConfigSectionCosmos}:DatabaseName", $"{dependencyInjection.OutputTarget.GetProject().ApplicationName()}DB"));
            application.EventDispatcher.Publish(new AppSettingRegistrationRequest($"{ConfigSectionCosmos}:EnsureDbCreated", true));

            //application.EventDispatcher.Publish(ServiceConfigurationRequest
            //    .ToRegister("AddCosmosDbUnitOfWork")
            //    .ForConcern("Infrastructure")
            //    .RequiresUsingNamespaces("Intent.Modules.CosmosDb.Common.CosmosDb", "Intent.Modules.CosmosDb.UnitOfWork.Abstractions.Extensions"));
            //application.EventDispatcher.Publish(ServiceConfigurationRequest
            //    .ToRegister($"AddCosmosDbUnitOfWork<{dbContext.ClassName}>")
            //    .ForConcern("Infrastructure")
            //    .RequiresUsingNamespaces("Intent.Modules.CosmosDb.Common.CosmosDb", "Intent.Modules.CosmosDb.UnitOfWork.Abstractions.Extensions"));
            //application.EventDispatcher.Publish(ContainerRegistrationRequest
            //    .ToRegister(dbContext)
            //    .ForInterface(dbContext.GetTemplate<IClassProvider>(CosmosDbUnitOfWorkInterfaceTemplate.TemplateId))
            //    .ForConcern("Infrastructure")
            //    .WithResolveFromContainer());
            //application.EventDispatcher.Publish(ContainerRegistrationRequest
            //    .ToRegister(dbContext)
            //    .ForInterface("ICosmosDbContext")
            //    .RequiresUsingNamespaces("Intent.Modules.CosmosDb.Common.CosmosDb")
            //    .ForConcern("Infrastructure")
            //    .WithResolveFromContainer());
        }
    }
}
