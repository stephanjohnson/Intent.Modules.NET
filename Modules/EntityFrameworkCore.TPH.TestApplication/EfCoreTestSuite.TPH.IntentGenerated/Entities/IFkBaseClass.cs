using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.TPH.IntentGenerated.Entities
{

    public partial interface IFkBaseClass
    {

        Guid CompositeKeyA { get; set; }

        Guid CompositeKeyB { get; set; }

    }
}