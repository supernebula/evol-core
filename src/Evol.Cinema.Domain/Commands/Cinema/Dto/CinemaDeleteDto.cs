using Evol.Domain.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evol.Cinema.Domain.Commands.Dto
{
    public class CinemaDeleteDto : IInputDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
