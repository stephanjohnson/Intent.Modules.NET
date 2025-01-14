using System;
using System.Collections.Generic;
using CleanArchitecture.TestApplication.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.AggregateRoots.UpdateAggregateRootCompositeManyB
{
    public class UpdateAggregateRootCompositeManyBCommand : IRequest, ICommand
    {
        public Guid AggregateRootId { get; set; }

        public Guid Id { get; set; }

        public string CompositeAttr { get; set; }

        public DateTime? SomeDate { get; set; }

        public UpdateAggregateRootCompositeManyBCompositeSingleBBDto? Composite { get; set; }

        public List<UpdateAggregateRootCompositeManyBCompositeManyBBDto> Composites { get; set; }

    }
}