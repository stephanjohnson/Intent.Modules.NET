using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityInterface", Version = "1.0")]

namespace EfCoreTestSuite.TPT.IntentGenerated.Entities
{

    public interface IFkAssociatedClass
    {
        IFkDerivedClass FkDerivedClass { get; set; }

    }
}
