using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.CosmosDb.IntentGenerated.Entities.Polymorphic
{

    public partial class Poly_ConcreteA : Poly_BaseClassNonAbstract, IPoly_ConcreteA
    {
        public Poly_ConcreteA()
        {
        }


        private string _concreteField;

        public string ConcreteField
        {
            get { return _concreteField; }
            set
            {
                _concreteField = value;
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

    }
}