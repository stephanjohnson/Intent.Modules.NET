using System;
using System.Collections.Generic;
using CleanArchitecture.TestApplication.Application.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;
using MediatR;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.QueryModels", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.AggregateRoots.GetAggregateRootCompositeManyBById
{
    public class GetAggregateRootCompositeManyBByIdQuery : IRequest<AggregateRootCompositeManyBDto>, IQuery
    {
        public Guid AggregateRootId { get; set; }

        public Guid Id { get; set; }

    }
}