using System;
using System.Collections.Generic;
using EfCoreTestSuite.TPT.IntentGenerated.DomainEvents;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.TPT.IntentGenerated.Entities.InheritanceAssociations
{

    public partial class FkBaseClass : IFkBaseClass, IHasDomainEvent
    {
        public FkBaseClass()
        {
        }


        private Guid _compositeKeyA;

        public Guid CompositeKeyA
        {
            get { return _compositeKeyA; }
            set
            {
                _compositeKeyA = value;
            }
        }

        private Guid _compositeKeyB;

        public Guid CompositeKeyB
        {
            get { return _compositeKeyB; }
            set
            {
                _compositeKeyB = value;
            }
        }



        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}