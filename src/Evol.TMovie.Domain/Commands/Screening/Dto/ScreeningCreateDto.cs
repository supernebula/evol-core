using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Values;
using System;
using AutoMapper.Configuration;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class ScreeningCreateDto : IInputDto, ICanConfigMapTo<Screening>
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
            mapConfig.CreateMap<ScreeningCreateDto, Screening>();
        }
    }
}
