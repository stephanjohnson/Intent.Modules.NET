using System;
using System.Collections.Generic;
using CqrsAutoCrud.TestApplication.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CqrsAutoCrud.TestApplication.Application.AggregateRoots.DeleteAggregateRootCompositeManyB
{
    public class DeleteAggregateRootCompositeManyBCommand : IRequest, ICommand
    {
        public Guid AggregateRootId { get; set; }

        public Guid Id { get; set; }

    }
}