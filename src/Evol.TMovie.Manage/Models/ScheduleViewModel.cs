using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using AutoMapper.Configuration;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Manage.Models
{
    public class ScheduleViewModel : IOutputDto, ICanConfigMapFrom<Schedule>
    {
        public Guid Id { get; set; }

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
