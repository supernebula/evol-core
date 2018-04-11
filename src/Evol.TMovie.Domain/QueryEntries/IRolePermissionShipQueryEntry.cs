using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Common.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IRolePermissionShipQueryEntry : IQueryEntry
    {
        Task<RolePermissionShip> FindAsync(Guid id);

        Task<List<RolePermissionShip>> RetrieveAsync(RolePermissionShipQueryParameter param);

        Task<IPaged<RolePermissionShip>> PagedAsync(RolePermissionShipQueryParameter param, int pageIndex, int pageSize);

        Task<List<Role>> GetRolesByPermissionAsync(Guid permissionId);

        Task<List<Permission>> GetPermissionsAsync(Guid roleId);

        Task<List<Permission>> GetPermissionsAsync(Guid[] roleIds);
    }
}
