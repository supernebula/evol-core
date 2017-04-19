using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class RolePermissionShipUpdateDto : IInputDto
    {
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public Guid[] PermissionIds { get; set; }
    }
}
