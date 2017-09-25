using AutoMapper;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class EmployeeCreateOrUpdateDto : IInputDto, ICanConfigMapTo<Employee>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Password { get; set; }

        public string RealName { get; set; }

        public void ConfigMap(MapperConfigurationExpression mapConfig)
        {
            mapConfig.CreateMap<EmployeeCreateOrUpdateDto, Employee>();
        }
    }
}
