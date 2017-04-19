using Evol.Domain.Commands;
using Evol.TMovie.Domain.Commands.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Commands
{
    public class EmployeeRoleShipUpdateCommand : Command
    {
        public EmployeeRoleShipUpdateDto Input { get; set; }
    }
}
