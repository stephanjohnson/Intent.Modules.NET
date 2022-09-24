using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Associations
{

    public partial class F_OptionalAggregateNav : IF_OptionalAggregateNav
    {
        public F_OptionalAggregateNav()
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

        private string _optionalAggrNavAttr;

        public string OptionalAggrNavAttr
        {
            get { return _optionalAggrNavAttr; }
            set
            {
                _optionalAggrNavAttr = value;
            }
        }

        private F_OptionalDependent _f_OptionalDependent;

        public virtual F_OptionalDependent F_OptionalDependent
        {
            get
            {
                return _f_OptionalDependent;
            }
            set
            {
                _f_OptionalDependent = value;
            }
        }
        public Guid? F_OptionalDependentId { get; set; }

    }
}