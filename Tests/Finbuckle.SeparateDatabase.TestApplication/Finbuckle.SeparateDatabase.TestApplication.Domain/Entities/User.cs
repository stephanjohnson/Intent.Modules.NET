using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace Finbuckle.SeparateDatabase.TestApplication.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}