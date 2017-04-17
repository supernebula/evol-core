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

namespace Evol.TMovie.Data.QueryEntries
{
    public class RolePermissionShipQueryEntry : IRolePermissionShipQueryEntry
    {
        private IRolePermissionShipRepository _rolePermissionShipRepository { get; set; }

        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        public RolePermissionShipQueryEntry(
            IRolePermissionShipRepository rolePermissionShipRepository,
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry
            )
        {
            _rolePermissionShipRepository = rolePermissionShipRepository;
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
        }
        public async Task<RolePermissionShip> FindAsync(Guid id)
        {
            return await _rolePermissionShipRepository.FindAsync(id);
        }


        public async Task<IList<RolePermissionShip>> RetrieveAsync(RolePermissionShipQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.RoleId == null || param.PermissionId == null)
                throw new ArgumentNullException(($"{nameof(param.PermissionId)} & {nameof(param.RoleId)}"));
            
            Expression<Func<RolePermissionShip, bool>> query = null;
            if (param.RoleId != null && param.PermissionId != null)
                query = e => e.RoleId == param.RoleId.Value && e.PermissionId == param.PermissionId.Value;
            else if (param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param.PermissionId != null)
                query = e => e.PermissionId == param.PermissionId.Value;

            var list = (await _rolePermissionShipRepository.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<RolePermissionShip>> PagedAsync(RolePermissionShipQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.RoleId == null || param.PermissionId == null)
                throw new ArgumentNullException(($"{nameof(param.PermissionId)} & {nameof(param.RoleId)}"));

            Expression<Func<RolePermissionShip, bool>> query = null;
            if (param.RoleId != null && param.PermissionId != null)
                query = e => e.RoleId == param.RoleId.Value && e.PermissionId == param.PermissionId.Value;
            else if (param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param.PermissionId != null)
                query = e => e.PermissionId == param.PermissionId.Value;

            var result = await _rolePermissionShipRepository.PagedAsync(query, pageIndex, pageSize);
            return result;
        }


        public async Task<IList<Permission>> GetPermissionsAsync(Guid roleId)
        {
            var list = (await _rolePermissionShipRepository.RetrieveAsync(e => e.RoleId == roleId)).ToList();
            var permissionIds = list.Select(e => e.PermissionId).ToArray();
            var result = await _permissionQueryEntry.GetByPermissionIdsAsync(permissionIds);
            return result;
        }

        public async Task<IList<Role>> GetRolesByPermissionAsync(Guid permissionId)
        {
            var list = (await _rolePermissionShipRepository.RetrieveAsync(e => e.PermissionId == permissionId)).ToList();
            var roleIds = list.Select(e => e.RoleId).ToArray();
            var result = await _roleQueryEntry.GetByIdsAsync(roleIds);
            return result;
        }
    }
}
