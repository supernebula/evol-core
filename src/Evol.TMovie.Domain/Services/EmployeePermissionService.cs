using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Services.Models;
using Evol.TMovie.Domain.QueryEntries;
using Evol.Domain;
using Microsoft.Extensions.Caching.Memory;
using Evol.TMovie.Domain.Models.AggregateRoots;

namespace Evol.TMovie.Domain.Services
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private static IMemoryCache _roleCache;

        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IEmployeePermissionShipQueryEntry _employeePermissionShipQueryEntry { get; set; }

        private IRolePermissionShipQueryEntry _rolePermissionShipQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }


        private IEmployeeQueryEntry _employeeQueryEntry { get; set; }
        public EmployeePermissionService(
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry,
            IEmployeeQueryEntry employeeQueryEntry,
            IRolePermissionShipQueryEntry rolePermissionShipQueryEntry,
            IEmployeePermissionShipQueryEntry employeePermissionShipQueryEntry
            )
        {
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
            _employeeQueryEntry = employeeQueryEntry;
            _employeePermissionShipQueryEntry = employeePermissionShipQueryEntry;
            _rolePermissionShipQueryEntry = rolePermissionShipQueryEntry;
        }

        static EmployeePermissionService()
        {
            _roleCache = AppConfig.Current.IoCManager.GetService<IMemoryCache>();
        }
        public async Task<EmployeePermissionDto> GetAsync(Guid employeeId)
        {
            var employee = await _employeeQueryEntry.FindAsync(employeeId);
            if (employee == null)
                return null;
            var roles = await _employeePermissionShipQueryEntry.GetRolesByEmployeeIdAsync(employeeId);
            var customPermissions = await _employeePermissionShipQueryEntry.GetCustomPermissionsByEmployeeIdAsync(employeeId);
            var roleIds = roles.Select(e => e.Id).ToArray();
            var permissonsOfRole = await _rolePermissionShipQueryEntry.GetPermissionsAsync(roleIds);

            var result = new EmployeePermissionDto()
            {
                EmployeeId = employee.Id,
                UserName = employee.Username,
                RealName = employee.RealName,
                Roles = roles.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList(),
                PermissionsOfRole = permissonsOfRole.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList(),
                CustomPermissions = customPermissions.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList()
            };

            return result;
        }

        public async Task<bool> ValidatePermissionAsync(Guid employeeId, string permissionCode, string httpSessionId)
        {

            List<string> allPermission = null;
            object cacheObj;
            if (_roleCache.TryGetValue(employeeId, out cacheObj))
            {
                var permissions = cacheObj != null ? cacheObj as List<string> : null;
                if (permissions == null)
                    _roleCache.Remove(employeeId);
            }
            allPermission = allPermission ?? await GetAllPermissionAsync(employeeId);
            if (allPermission == null || !allPermission.Any())
                return false;
            var cacheEntry = _roleCache.CreateEntry(employeeId);
            cacheEntry.SetSlidingExpiration(TimeSpan.FromMinutes(20));
            cacheEntry.SetValue(allPermission);

            return allPermission.Any((e => e == permissionCode));
        }

        private async Task<List<string>> GetAllPermissionAsync(Guid employeeId)
        {
            var dto = await GetAsync(employeeId);
            var permissions = dto.PermissionsOfRole;
            permissions.AddRange(dto.CustomPermissions);
            return permissions.Select(e => e.Value).ToList();
        }
    }
}
