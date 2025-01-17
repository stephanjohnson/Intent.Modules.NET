using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.CSharp;
using Intent.Modules.Common.CSharp.Templates;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.VisualStudio;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: IntentTemplate("Intent.ModuleBuilder.CSharp.Templates.CSharpTemplatePartial", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace Intent.Modules.Entities.Repositories.Api.Templates.PagedResultInterface
{
    [IntentManaged(Mode.Fully, Body = Mode.Merge)]
    partial class PagedResultInterfaceTemplate : CSharpTemplateBase<object>
    {
        public const string TemplateId = "Intent.Entities.Repositories.Api.PagedResultInterface";

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public PagedResultInterfaceTemplate(IOutputTarget outputTarget, object model = null)
            : base(TemplateId, outputTarget, model)
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        protected override CSharpFileConfig DefineFileConfig()
        {
            return new CSharpFileConfig(
                className: $"IPagedResult",
                @namespace: $"{this.GetNamespace()}");
        }
    }
}
