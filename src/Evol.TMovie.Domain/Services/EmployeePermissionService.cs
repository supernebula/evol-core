using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Services.Models;
using Evol.TMovie.Domain.QueryEntries;

namespace Evol.TMovie.Domain.Services
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IEmployeePermissionShipQueryEntry _employeePermissionShipQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        private IEmployeeQueryEntry _employeeQueryEntry { get; set; }
        public EmployeePermissionService(
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry,
            IEmployeeQueryEntry employeeQueryEntry
            )
        {
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
            _employeeQueryEntry = employeeQueryEntry;
        }
        public async Task<EmployeePermissionDto> GetAsync(Guid employeeId)
        {
            var employee = await _employeeQueryEntry.FindAsync(employeeId);
            if (employee == null)
                return null;
            var roles = await _employeePermissionShipQueryEntry.GetRolesByEmployeeIdAsync(employeeId);
            var customPermissions = await _employeePermissionShipQueryEntry.GetCustomPermissionsByEmployeeIdAsync(employeeId);

            var result = new EmployeePermissionDto()
            {
                EmployeeId = employee.Id,
                UserName = employee.Username,
                RealName = employee.RealName,
                Roles = roles.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList(),
                CustomPermissions = customPermissions.Select(e => new KeyValuePair<Guid, string>(e.Id, e.Code)).ToList()
            };

            return result;
        }
    }
}
