using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.DependencyInjection;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Eventing.GoogleCloud.PubSub.Templates.InterfaceTemplates.CloudResourceManagerInterface;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.Eventing.GoogleCloud.PubSub.Templates.ImplementationTemplates.GoogleCloudResourceManager
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class GoogleCloudResourceManagerTemplate : CSharpTemplateBase<object>
    {
        public const string TemplateId = "Intent.Eventing.GoogleCloud.PubSub.ImplementationTemplates.GoogleCloudResourceManager";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public GoogleCloudResourceManagerTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
            AddNugetDependency(NugetPackages.GoogleCloudPubSubV1);
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"GoogleCloudResourceManager",
                @namespace: $"{this.GetNamespace()}",
                relativeLocation: $"{this.GetFolderPath()}");
        }

        public override void BeforeTemplateExecution()
        {
            this.ApplyAppSetting("GoogleCloud:UseMetadataServer", false);
            this.ApplyAppSetting("GoogleCloud:ProjectId", $"x-object-xyz");
            this.ApplyAppSetting("GoogleCloud:ShouldSetupCloudResources", true);
            
            ExecutionContext.EventDispatcher.Publish(ContainerRegistrationRequest
                .ToRegister(this)
                .ForConcern("Infrastructure")
                .WithSingletonLifeTime());
            ExecutionContext.EventDispatcher.Publish(ContainerRegistrationRequest
                .ToRegister(this)
                .ForInterface(this.GetCloudResourceManagerInterfaceName())
                .ForConcern("Infrastructure")
                .HasDependency(GetTemplate<IClassProvider>(CloudResourceManagerInterfaceTemplate.TemplateId))
                .WithResolveFromContainer());
        }
    }
}