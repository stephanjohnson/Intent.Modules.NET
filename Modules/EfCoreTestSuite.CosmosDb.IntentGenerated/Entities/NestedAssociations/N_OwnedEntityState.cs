using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.NestedAssociations
{

    public partial class N_OwnedEntity : IN_OwnedEntity
    {
        public N_OwnedEntity()
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

        private string _ownedAttr;

        public string OwnedAttr
        {
            get { return _ownedAttr; }
            set
            {
                _ownedAttr = value;
            }
        }


        public Guid N_OwnedEntityAssociationBId { get; set; }
        private N_OwnedEntityAssociationB _n_OwnedEntityAssociationB;

        public virtual N_OwnedEntityAssociationB N_OwnedEntityAssociationB
        {
            get
            {
                return _n_OwnedEntityAssociationB;
            }
            set
            {
                _n_OwnedEntityAssociationB = value;
            }
        }

        private ICollection<N_OwnedEntityAssociationC> _n_OwnedEntityAssociationCS;

        public virtual ICollection<N_OwnedEntityAssociationC> N_OwnedEntityAssociationCS
        {
            get
            {
                return _n_OwnedEntityAssociationCS ??= new List<N_OwnedEntityAssociationC>();
            }
            set
            {
                _n_OwnedEntityAssociationCS = value;
            }
        }

        private N_OwnedEntityAssociationD _n_OwnedEntityAssociationD;

        public virtual N_OwnedEntityAssociationD N_OwnedEntityAssociationD
        {
            get
            {
                return _n_OwnedEntityAssociationD;
            }
            set
            {
                _n_OwnedEntityAssociationD = value;
            }
        }


        public Guid N_NestedOwnedAssocationOwnerId { get; set; }
        private N_NestedOwnedAssocationOwner _n_NestedOwnedAssocationOwner;

        public virtual N_NestedOwnedAssocationOwner N_NestedOwnedAssocationOwner
        {
            get
            {
                return _n_NestedOwnedAssocationOwner;
            }
            set
            {
                _n_NestedOwnedAssocationOwner = value;
            }
        }


    }
}
