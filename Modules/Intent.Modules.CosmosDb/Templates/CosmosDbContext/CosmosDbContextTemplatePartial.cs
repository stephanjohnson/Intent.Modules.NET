using System.Collections.Generic;
using Intent.CosmosDb;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.CosmosDb.Templates.CosmosDbUnitOfWorkInterface;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.CosmosDb.Templates.CosmosDbContext
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class CosmosDbContextTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Intent.CosmosDb.CosmosDbContext";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public CosmosDbContextTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NugetPackages.MicrosoftAzureCosmos);

            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("System.Threading")
                .AddUsing("System.Threading.Tasks")
                .AddUsing("Microsoft.Azure.Cosmos")
                .AddClass($"CosmosDbContext", @class =>
                {
                    @class.ImplementsInterface(GetTypeName(CosmosDbUnitOfWorkInterfaceTemplate.TemplateId));

                    @class.AddField("CosmosClient", "_cosmosClient", c => c.PrivateReadOnly());
                    @class.AddField("string", "_databaseName", c => c.PrivateReadOnly());

                    @class.AddConstructor(ctor =>
                    {
                        ctor.AddParameter("CosmosClient", "cosmosClient");
                        ctor.AddParameter("string", "databaseName");
                        ctor.CallsBase(b =>
                        {
                            b.AddArgument("cosmosClient");
                            b.AddArgument("databaseName");
                        });

                        ctor.AddStatement("_cosmosClient = cosmosClient;");
                        ctor.AddStatement("_databaseName = databaseName;");
                    });

                    @class.AddMethod("Container", "GetContainer", method =>
                    {
                        method.AddParameter("string", "containerName");
                        method.AddStatement("return _cosmosClient.GetContainer(_databaseName, containerName);");
                    });

                    @class.AddMethod("Task<int>", $"SaveChangesAsync", method =>
                    {
                        method.Async();
                        method.AddParameter("CancellationToken", "cancellationToken");
                        method.AddStatement("return (await base.SaveChangesAsync(cancellationToken)).Results.Count;");
                    });
                });
        }

        [IntentManaged(Mode.Fully)]
        public CSharpFile CSharpFile { get; }

        [IntentManaged(Mode.Fully)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return CSharpFile.GetConfig();
        }

        [IntentManaged(Mode.Fully)]
        public override string TransformText()
        {
            return CSharpFile.ToString();
        }
    }
}