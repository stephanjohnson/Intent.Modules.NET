using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{

    public partial interface IB_OptionalAggregate
    {

        /// <summary>
        /// Get the persistent object's identifier
        /// </summary>
        Guid Id { get; }
        string OptionalAggregateAttr { get; set; }

        string PartitionKey { get; set; }

        B_OptionalDependent B_OptionalDependent { get; set; }

    }
}