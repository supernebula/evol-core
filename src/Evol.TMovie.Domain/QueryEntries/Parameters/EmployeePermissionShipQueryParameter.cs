using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class EmployeePermissionShipQueryParameter
    {
        public Guid? EmployeeId { get; set; }

        public Guid? RoleId { get; set; }
    }
}
