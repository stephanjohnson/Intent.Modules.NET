using System;
using System.Collections.Generic;
using EntityFrameworkCore.SqlServer.TestApplication.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace EntityFrameworkCore.SqlServer.TestApplication.Domain.Entities.ExplicitKeys
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class FK_B_CompositeForeignKey : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public Guid PK_CompositeKeyCompositeKeyA { get; set; }

        public Guid PK_CompositeKeyCompositeKeyB { get; set; }

        public virtual PK_B_CompositeKey PK_CompositeKey { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}