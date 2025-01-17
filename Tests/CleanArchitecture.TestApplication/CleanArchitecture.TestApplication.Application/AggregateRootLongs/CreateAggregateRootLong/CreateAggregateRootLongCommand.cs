using System;
using System.Collections.Generic;
using CleanArchitecture.TestApplication.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.AggregateRootLongs.CreateAggregateRootLong
{
    public class CreateAggregateRootLongCommand : IRequest<long>, ICommand
    {
        public string Attribute { get; set; }

        public CreateAggregateRootLongCompositeOfAggrLongDto? CompositeOfAggrLong { get; set; }

    }
}