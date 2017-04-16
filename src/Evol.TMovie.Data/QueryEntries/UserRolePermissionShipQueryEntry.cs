using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using System.Linq;

namespace Evol.TMovie.Data.QueryEntries
{
    public class UserRolePermissionShipQueryEntry : IUserRolePermissionShipQueryEntry
    {
        private IUserRolePermissionShipRepository _userRolePermissionShipRepository { get; set; }

        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        private IUserQueryEntry _userQueryEntry { get; set; }

        public UserRolePermissionShipQueryEntry(
            IUserRolePermissionShipRepository userRolePermissionShipQueryEntry,
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry
            )
        {
            _userRolePermissionShipRepository = userRolePermissionShipQueryEntry;
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
        }

        public async Task<UserRolePermissionShip> FetchAsync(Guid id)
        {
             return await _userRolePermissionShipRepository.FindAsync(id);
        }

        public async Task<IList<Permission>> GetCustomPermissionsByUserIdAsync(Guid userId)
        {
            var list = (await _userRolePermissionShipRepository.RetrieveAsync(e => e.CustomPermissionId != null && e.UserId == userId)).ToList();
            var customPermissionids = list.Select(e => e.CustomPermissionId.Value).ToArray();
            var permissions = await _permissionQueryEntry.GetByPermissionIdsAsync(customPermissionids);
            return permissions;
        }

        public async Task<IList<Role>> GetRolesByUserIdAsync(Guid userId)
        {
            var list = (await _userRolePermissionShipRepository.RetrieveAsync(e => e.RoleId != null && e.UserId == userId)).ToList();
            var roleIds = list.Select(e => e.RoleId.Value).ToArray();
            var permissions = await _roleQueryEntry.GetByIdsAsync(roleIds);
            return permissions;
        }

        public Task<IList<User>> GetUsersByRoleIdAsync(Guid userId)
        {
            var list = (await _userRolePermissionShipRepository.RetrieveAsync(e => e.RoleId != null && e.UserId == userId)).ToList();
            var roleIds = list.Select(e => e.RoleId.Value).ToArray();
            var permissions = await _roleQueryEntry.GetByIdsAsync(roleIds);
            return permissions;
        }

        public Task<IList<UserRolePermissionShip>> RetrieveAsync(UserRolePermissionShipQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<RolePermissionShip>> PagedAsync(UserRolePermissionShipQueryParameter param, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
