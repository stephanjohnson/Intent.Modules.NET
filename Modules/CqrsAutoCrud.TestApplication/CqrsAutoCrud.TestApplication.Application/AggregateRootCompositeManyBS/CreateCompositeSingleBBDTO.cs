using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Application.AggregateRootCompositeManyBS
{

    public class CreateCompositeSingleBBDTO
    {
        public CreateCompositeSingleBBDTO()
        {
        }

        public static CreateCompositeSingleBBDTO Create(
            string compositeAttr)
        {
            return new CreateCompositeSingleBBDTO
            {
                CompositeAttr = compositeAttr,
            };
        }

        public string CompositeAttr { get; set; }

    }
}