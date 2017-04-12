using Evol.Domain.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class CinemaCreateOrUpdateDto : IInputDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }
    }
}
