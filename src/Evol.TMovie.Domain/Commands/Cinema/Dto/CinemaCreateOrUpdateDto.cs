using AutoMapper;
using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.ComponentModel.DataAnnotations;


namespace Evol.TMovie.Domain.Commands.Dto
{
    public class CinemaCreateOrUpdateDto : IInputDto, ICanOptionMapTo<Cinema>
    {

        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "不能为空")]
        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<CinemaCreateOrUpdateDto, Cinema>()
                .ForMember(e => e.Id, m => m.MapFrom(s => s.Id));
        }


    }
}
