using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.Entities
{
    /// <summary>
    /// Role(1) ----《 Permission(n)
    /// </summary>
    public class RolePermissionShip : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }
    }
}
