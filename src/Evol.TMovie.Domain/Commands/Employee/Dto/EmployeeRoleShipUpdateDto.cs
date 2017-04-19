using Evol.Domain.Dto;
using Evol.TMovie.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evol.TMovie.Domain.Commands.Dto
{
    public class EmployeeRoleShipUpdateDto : IInputDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid[] RoleIds { get; set; }
    }
}
