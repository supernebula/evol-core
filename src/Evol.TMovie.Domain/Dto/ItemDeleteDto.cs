using Evol.Domain.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evol.TMovie.Domain.Dto
{
    public class ItemDeleteDto : IInputDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
