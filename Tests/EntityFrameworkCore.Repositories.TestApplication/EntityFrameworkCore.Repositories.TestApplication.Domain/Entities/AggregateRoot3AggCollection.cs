using System;
using System.Collections.Generic;
using EntityFrameworkCore.Repositories.TestApplication.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace EntityFrameworkCore.Repositories.TestApplication.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class AggregateRoot3AggCollection : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public Guid AggregateRoot3SingleId { get; set; }

        public virtual AggregateRoot3Single AggregateRoot3Single { get; set; }

        public Guid? AggregateRoot3NullableId { get; set; }

        public virtual AggregateRoot3Nullable? AggregateRoot3Nullable { get; set; }

        public Guid AggregateRoot3CollectionId { get; set; }

        public virtual AggregateRoot3Collection AggregateRoot3Collection { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}