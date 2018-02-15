using Evol.Domain.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Dto
{
    public class ItemDeleteDto : IInputDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
