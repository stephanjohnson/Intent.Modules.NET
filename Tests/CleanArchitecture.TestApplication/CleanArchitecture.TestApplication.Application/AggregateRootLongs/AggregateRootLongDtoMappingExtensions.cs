using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using CleanArchitecture.TestApplication.Domain.Entities;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.AutoMapper.MappingExtensions", Version = "1.0")]

namespace CleanArchitecture.TestApplication.Application.AggregateRootLongs
{
    public static class AggregateRootLongDtoMappingExtensions
    {
        public static AggregateRootLongDto MapToAggregateRootLongDto(this AggregateRootLong projectFrom, IMapper mapper)
        {
            return mapper.Map<AggregateRootLongDto>(projectFrom);
        }

        public static List<AggregateRootLongDto> MapToAggregateRootLongDtoList(this IEnumerable<AggregateRootLong> projectFrom, IMapper mapper)
        {
            return projectFrom.Select(x => x.MapToAggregateRootLongDto(mapper)).ToList();
        }
    }
}