using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CleanArchitecture.TestApplication.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.AggregateRoots
{
    public static class AggregateRootDtoMappingExtensions
    {
        public static AggregateRootDto MapToAggregateRootDto(this AggregateRoot projectFrom, IMapper mapper)
        {
            return mapper.Map<AggregateRootDto>(projectFrom);
        }

        public static List<AggregateRootDto> MapToAggregateRootDtoList(this IEnumerable<AggregateRoot> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToAggregateRootDto(mapper)).ToList();
        }
    }
}