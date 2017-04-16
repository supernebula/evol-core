using System;

namespace Evol.TMovie.Domain.QueryEntries.Parameters
{
    public class UserRolePermissionShipQueryParameter
    {
        public Guid? UserId { get; set; }

        public Guid? RoleId { get; set; }
    }
}
