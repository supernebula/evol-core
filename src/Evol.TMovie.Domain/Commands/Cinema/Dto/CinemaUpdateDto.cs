using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class CinemaUpdateDto : CinemaCreateDto, IInputDto, ICanOptionMapTo<Cinema>
    {

        public Guid Id { get; set; }

        public override void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<CinemaUpdateDto, Cinema>()
                .ForMember(e => e.Id, m => m.MapFrom(s => s.Id));
        }
    }
}
