using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.SingleFileNoModel", Version = "1.0")]

namespace Intent.Modules.IdentityServer4.InMemoryStore.Templates.TestUsers
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class TestUsersTemplateRegistration : SingleFileTemplateRegistration
    {
        public override string TemplateId => TestUsersTemplate.TemplateId;

        public override ITemplate CreateTemplateInstance(IOutputTarget outputTarget)
        {
            return new TestUsersTemplate(outputTarget, null);
        }
    }
}