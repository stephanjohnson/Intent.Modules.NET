using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]

namespace Intent.Modules.Application.Identity.Templates.CurrentUserServiceInterface
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class CurrentUserServiceInterfaceTemplate : CSharpTemplateBase<object>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Intent.Application.Identity.CurrentUserServiceInterface";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public CurrentUserServiceInterfaceTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"ICurrentUserService",
                @namespace: $"{OutputTarget.GetNamespace()}");
        }

    }
}