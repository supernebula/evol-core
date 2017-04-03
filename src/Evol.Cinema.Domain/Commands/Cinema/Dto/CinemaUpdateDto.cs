using Evol.Domain.Dto;
using System.ComponentModel.DataAnnotations;

namespace Evol.Cinema.Domain.Commands.Dto
{
    public class CinemaUpdateDto : IInputDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
