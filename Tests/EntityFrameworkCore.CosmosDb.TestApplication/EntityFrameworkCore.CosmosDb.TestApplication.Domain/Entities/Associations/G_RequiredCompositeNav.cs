using System;
using System.Collections.Generic;
using EntityFrameworkCore.CosmosDb.TestApplication.Domain.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace EntityFrameworkCore.CosmosDb.TestApplication.Domain.Entities.Associations
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class G_RequiredCompositeNav : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public string PartitionKey { get; set; }

        public string RequiredCompNavAttr { get; set; }

        public virtual ICollection<G_MultipleDependent> G_MultipleDependents { get; set; } = new List<G_MultipleDependent>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}