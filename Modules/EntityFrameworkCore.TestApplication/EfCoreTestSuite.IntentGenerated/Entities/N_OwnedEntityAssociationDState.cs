using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntityState", Version = "1.0")]

namespace EfCoreTestSuite.IntentGenerated.Entities
{

    public partial class N_OwnedEntityAssociationD : IN_OwnedEntityAssociationD
    {
        public N_OwnedEntityAssociationD()
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

        private string _associationAttr;

        public string AssociationAttr
        {
            get { return _associationAttr; }
            set
            {
                _associationAttr = value;
            }
        }


    }
}
