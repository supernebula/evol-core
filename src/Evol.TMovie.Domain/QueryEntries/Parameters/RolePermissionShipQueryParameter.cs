using System;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class RolePermissionShipQueryParameter
    {
        public Guid? RoleId { get; set; }

        public Guid? PermissionId { get; set; }
    }
}
