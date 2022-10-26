using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.NestedAssociations
{

    public partial interface IN_OwnedEntity
    {

        /// <summary>
        /// Get the persistent object's identifier
        /// </summary>
        Guid Id { get; }
        string OwnedAttr { get; set; }

        Guid N_OwnedEntityAssociationBId { get; }
        N_OwnedEntityAssociationB N_OwnedEntityAssociationB { get; set; }

        ICollection<N_OwnedEntityAssociationC> N_OwnedEntityAssociationCS { get; set; }

        N_OwnedEntityAssociationD N_OwnedEntityAssociationD { get; set; }

        Guid N_NestedOwnedAssocationOwnerId { get; }
        N_NestedOwnedAssocationOwner N_NestedOwnedAssocationOwner { get; set; }

    }
}
