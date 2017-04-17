using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IRolePermissionShipQueryEntry : IQueryEntry
    {
        Task<RolePermissionShip> FindAsync(Guid id);

        Task<IList<RolePermissionShip>> RetrieveAsync(RolePermissionShipQueryParameter param);

        Task<IPaged<RolePermissionShip>> PagedAsync(RolePermissionShipQueryParameter param, int pageIndex, int pageSize);

        Task<IList<Role>> GetRolesByPermissionAsync(Guid PermissionId);

        Task<IList<Permission>> GetPermissionsAsync(Guid permissionId);
    }
}
