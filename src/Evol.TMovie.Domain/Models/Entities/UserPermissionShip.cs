using Evol.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Domain.Models.Entities
{
    /// <summary>
    /// User(1) ------《 Role(n) 
    /// OR 
    /// User(1) --------《 Permission(n)
    /// </summary>
    [Obsolete]
    public class UserPermissionShip : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid? RoleId { get; set; }

        public Guid? CustomPermissionId { get; set; }
    }
}
