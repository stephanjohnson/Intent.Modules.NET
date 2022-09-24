using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{

    public partial class E_RequiredCompositeNav : IE_RequiredCompositeNav
    {
        public E_RequiredCompositeNav()
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

        private string _requiredCompositeNavAttr;

        public string RequiredCompositeNavAttr
        {
            get { return _requiredCompositeNavAttr; }
            set
            {
                _requiredCompositeNavAttr = value;
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

        private E_RequiredDependent _e_RequiredDependent;

        public virtual E_RequiredDependent E_RequiredDependent
        {
            get
            {
                return _e_RequiredDependent;
            }
            set
            {
                _e_RequiredDependent = value;
            }
        }


    }
}