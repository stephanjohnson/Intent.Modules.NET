using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common.Templates.StaticContent;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.StaticContentTemplateRegistration", Version = "1.0")]

namespace Intent.Modules.Dapr.AspNetCore.Templates.StaticContentTemplateRegistrations
{
    public class DaprComponentFilesStaticContentTemplateRegistration : StaticContentTemplateRegistration
    {
        public new const string TemplateId = "Intent.Modules.Dapr.AspNetCore.Templates.StaticContentTemplateRegistrations.DaprComponentFilesStaticContentTemplateRegistration";

        public DaprComponentFilesStaticContentTemplateRegistration() : base(TemplateId)
        {
        }

        public override string ContentSubFolder => "DaprComponents";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override IReadOnlyDictionary<string, string> Replacements(IOutputTarget outputTarget) => new Dictionary<string, string>
        {
        };

        [IntentManaged(Mode.Ignore)]
        protected override ITemplate CreateTemplate(IOutputTarget outputTarget, string fileFullPath, string fileRelativePath, OverwriteBehaviour defaultOverwriteBehaviour)
        {
            fileRelativePath = $"../dapr/components/{fileRelativePath}";

            return base.CreateTemplate(outputTarget, fileFullPath, fileRelativePath, defaultOverwriteBehaviour);
        }

        [IntentManaged(Mode.Ignore)]
        protected override OverwriteBehaviour DefaultOverrideBehaviour => OverwriteBehaviour.OnceOff;
    }
}