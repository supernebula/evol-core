using AutoMapper;
using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.AggregateRoots;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class PermissionCreateOrUpdateDto : IInputDto, ICanConfigMapTo<Permission>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Code { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Title { get; set; }
    }
}
