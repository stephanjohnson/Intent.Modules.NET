using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.SingleFileNoModel", Version = "1.0")]
[assembly: DefaultIntentManaged(Mode.Fully)]

namespace Intent.Modules.Entities.Repositories.Api.Templates.PagedResultInterface
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class PagedResultInterfaceTemplateRegistration : SingleFileTemplateRegistration
    {
        private readonly IMetadataManager _metadataManager;

        public PagedResultInterfaceTemplateRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override string TemplateId => PagedResultInterfaceTemplate.TemplateId;
        public override ITemplate CreateTemplateInstance(IOutputTarget outputTarget)
        {
            return new PagedResultInterfaceTemplate(outputTarget);
        }
    }
}
