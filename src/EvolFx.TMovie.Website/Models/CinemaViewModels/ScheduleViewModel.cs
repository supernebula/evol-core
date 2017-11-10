using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Evol.TMovie.Domain.Models.Values;

namespace EvolFx.TMovie.Website.Models.CinemaViewModels
{
    public class ScheduleViewModel : IOutputDto, ICanConfigMapFrom<Schedule>
    {

        public Guid MovieId { get; set; }

        public Guid CinemaId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid ScreeningRoomId { get; set; }


        public double Price { get; set; }

        public double SellPrice { get; set; }


        public SpaceDimensionType SpaceType { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Schedule, ScheduleViewModel>();
        }
    }
}
