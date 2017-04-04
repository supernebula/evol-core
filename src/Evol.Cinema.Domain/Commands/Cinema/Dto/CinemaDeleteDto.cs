using Evol.Domain.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class CinemaDeleteDto : IInputDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
