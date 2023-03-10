using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Builder;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Constants;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.CosmosDb.Templates.CosmosDbUnitOfWorkInterface
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class CosmosDbUnitOfWorkInterfaceTemplate : CSharpTemplateBase<object>, ICSharpFileBuilderTemplate
    {
        public const string TemplateId = "Intent.CosmosDb.CosmosDbUnitOfWorkInterface";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public CosmosDbUnitOfWorkInterfaceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            CSharpFile = new CSharpFile(this.GetNamespace(), this.GetFolderPath())
                .AddUsing("System.Threading")
                .AddUsing("System.Threading.Tasks")
                .AddInterface($"ICosmosDbUnitOfWork", inter =>
                {
                    var originalUnitOfWorkInterfaceName = GetTypeName(TemplateFulfillingRoles.Domain.UnitOfWork, TemplateDiscoveryOptions.DoNotThrow);
                    if (!string.IsNullOrEmpty(originalUnitOfWorkInterfaceName))
                    {
                        inter.ExtendsInterface(originalUnitOfWorkInterfaceName);
                    }

                    inter.AddMethod("Task<int>", "SaveChangesAsync", method =>
                    {
                        method.AddParameter("CancellationToken", "cancellationToken", param => param.WithDefaultValue("default"));
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