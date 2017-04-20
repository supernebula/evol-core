using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Services.Models;
using Evol.TMovie.Domain.QueryEntries;

namespace Evol.TMovie.Domain.Services
{
    public class UserPermissionService : IUserPermissionService
    {
        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IUserPermissionShipQueryEntry _userPermissionShipQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        private IUserQueryEntry _userQueryEntry { get; set; }

        public UserPermissionService(
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry,
            IUserQueryEntry userQueryEntry
            )
        {
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
            _userQueryEntry = userQueryEntry;
        }
        public async Task<UserPermissionDto> GetAsync(Guid userId)
        {
            var user = await _userQueryEntry.FindAsync(userId);
            if (user == null)
                return null;
            var roles = await _userPermissionShipQueryEntry.GetRolesByUserIdAsync(userId);
            var customPermissions = await _userPermissionShipQueryEntry.GetCustomPermissionsByUserIdAsync(userId);

            var result = new UserPermissionDto()
            {
                UserId = user.Id,
                UserName = user.Username,
                RealName = user.RealName,
                Roles = roles.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList(),
                CustomPermissions = customPermissions.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList()
            };

            return result;
        }
    }
}
