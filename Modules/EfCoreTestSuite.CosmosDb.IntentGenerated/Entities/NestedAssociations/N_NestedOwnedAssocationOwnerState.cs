using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.NestedAssociations
{

    public partial class N_NestedOwnedAssocationOwner : IN_NestedOwnedAssocationOwner
    {
        public N_NestedOwnedAssocationOwner()
        {
        }

        private Guid? _id = null;

        /// <summary>
        /// Get the persistent object's identifier
        /// </summary>
        public virtual Guid Id
        {
            get { return _id ?? (_id = IdentityGenerator.NewSequentialId()).Value; }
            set { _id = value; }
        }

        private string _partitionKey;

        public string PartitionKey
        {
            get { return _partitionKey; }
            set
            {
                _partitionKey = value;
            }
        }

        private string _ownerAttr;

        public string OwnerAttr
        {
            get { return _ownerAttr; }
            set
            {
                _ownerAttr = value;
            }
        }

        private ICollection<N_OwnedEntity> _n_OwnedEntities;

        public virtual ICollection<N_OwnedEntity> N_OwnedEntities
        {
            get
            {
                return _n_OwnedEntities ??= new List<N_OwnedEntity>();
            }
            set
            {
                _n_OwnedEntities = value;
            }
        }


    }
}
