using Evol.Domain.Dto;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using AutoMapper.Configuration;

namespace EvolFx.TMovie.Website.Models.CinemaViewModels
{
    public class CinemaViewModel : IOutputDto, ICanConfigMapFrom<Cinema>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime CreateTime { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<Cinema, CinemaViewModel>();
        }
    }
}
