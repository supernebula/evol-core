using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class RolePermissionShipQueryEntry : BaseEntityFrameworkQuery<RolePermissionShip, TMovieDbContext>, IRolePermissionShipQueryEntry
    {
        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        public RolePermissionShipQueryEntry(
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry,
            IEfDbContextProvider efDbContextProvider
            ) : base(efDbContextProvider)
        {
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
        }

        public async Task<IList<RolePermissionShip>> RetrieveAsync(RolePermissionShipQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.RoleId == null || param.PermissionId == null)
                throw new ArgumentNullException(($"{nameof(param.PermissionId)} & {nameof(param.RoleId)}"));
            
            Expression<Func<RolePermissionShip, bool>> query = null;
            if (param != null && param.RoleId != null && param.PermissionId != null)
                query = e => e.RoleId == param.RoleId.Value && e.PermissionId == param.PermissionId.Value;
            else if (param != null && param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param != null && param.PermissionId != null)
                query = e => e.PermissionId == param.PermissionId.Value;
            else
                query = e => true;

            var list = (await base.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<RolePermissionShip>> PagedAsync(RolePermissionShipQueryParameter param, int pageIndex, int pageSize)
        {
            Expression<Func<RolePermissionShip, bool>> query = null;
            if (param != null && param.RoleId != null && param.PermissionId != null)
                query = e => e.RoleId == param.RoleId.Value && e.PermissionId == param.PermissionId.Value;
            else if (param != null && param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param != null && param.PermissionId != null)
                query = e => e.PermissionId == param.PermissionId.Value;
            else
                query = e => true;

            var result = await base.PagedAsync(query, pageIndex, pageSize);
            return result;
        }


        public async Task<IList<Permission>> GetPermissionsAsync(Guid roleId)
        {
            var list = (await base.RetrieveAsync(e => e.RoleId == roleId)).ToList();
            var permissionIds = list.Select(e => e.PermissionId).ToArray();
            var result = await _permissionQueryEntry.GetByPermissionIdsAsync(permissionIds);
            return result;
        }

        public async Task<IList<Role>> GetRolesByPermissionAsync(Guid permissionId)
        {
            var list = (await base.RetrieveAsync(e => e.PermissionId == permissionId)).ToList();
            var roleIds = list.Select(e => e.RoleId).ToArray();
            var result = await _roleQueryEntry.GetByIdsAsync(roleIds);
            return result;
        }
    }
}
