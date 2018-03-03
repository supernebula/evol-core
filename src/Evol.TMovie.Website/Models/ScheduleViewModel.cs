using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evol.TMovie.Website.Models
{
    public class ScheduleViewModel : IOutputDto, ICanConfigMapFrom<Schedule>
    {
        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            throw new NotImplementedException();
        }
    }
}
