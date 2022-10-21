using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.InheritanceAssociations
{

    public partial class DerivedClassForAbstractAssociated : IDerivedClassForAbstractAssociated
    {
        public DerivedClassForAbstractAssociated()
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

        private string _associatedField;

        public string AssociatedField
        {
            get { return _associatedField; }
            set
            {
                _associatedField = value;
            }
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


        public Guid DerivedClassForAbstractId { get; set; }
        private DerivedClassForAbstract _derivedClassForAbstract;

        public virtual DerivedClassForAbstract DerivedClassForAbstract
        {
            get
            {
                return _derivedClassForAbstract;
            }
            set
            {
                _derivedClassForAbstract = value;
            }
        }


    }
}