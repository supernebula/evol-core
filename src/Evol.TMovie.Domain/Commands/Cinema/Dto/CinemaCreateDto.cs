using AutoMapper;
using AutoMapper.Configuration;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.ComponentModel.DataAnnotations;


namespace Evol.TMovie.Domain.Commands.Dto
{
    public class CinemaCreateDto : IInputDto, ICanConfigMapTo<Cinema>
    {

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "不能为空")]
        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }

        public virtual void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<CinemaCreateDto, Cinema>();
        }


    }
}
