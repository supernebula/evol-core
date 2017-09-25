using Evol.TMovie.Domain.QueryEntries;
using System;
using System.Collections.Generic;
using System.Text;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Repositories;
using System.Linq.Expressions;
using System.Linq;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class EmployeePermissionShipQueryEntry : BaseEntityFrameworkQuery<EmployeePermissionShip, TMovieDbContext>, IEmployeePermissionShipQueryEntry
    {
        private IPermissionQueryEntry _permissionQueryEntry { get; set; }

        private IRoleQueryEntry _roleQueryEntry { get; set; }

        private IEmployeeQueryEntry _employeeQueryEntry { get; set; }

        public EmployeePermissionShipQueryEntry(
            IPermissionQueryEntry permissionQueryEntry,
            IRoleQueryEntry roleQueryEntry,
            IEmployeeQueryEntry employeeQueryEntry,
            IEfDbContextProvider efDbContextProvider
            ) : base(efDbContextProvider)
        {
            _permissionQueryEntry = permissionQueryEntry;
            _roleQueryEntry = roleQueryEntry;
            _employeeQueryEntry = employeeQueryEntry;
        }

        public async Task<IPaged<EmployeePermissionShip>> PagedAsync(EmployeePermissionShipQueryParameter param, int pageIndex, int pageSize)
        {
            //if (param == null)
            //    throw new ArgumentNullException(nameof(param));
            //if (param.RoleId == null || param.EmployeeId == null)
            //    throw new ArgumentNullException(($"{nameof(param.RoleId)} & {nameof(param.EmployeeId)}"));

            Expression<Func<EmployeePermissionShip, bool>> query = null;
            if (param != null && param.RoleId != null && param.EmployeeId != null)
                query = e => e.RoleId == param.RoleId.Value && e.EmployeeId == param.EmployeeId.Value;
            else if (param != null && param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param != null && param.EmployeeId != null)
                query = e => e.EmployeeId == param.EmployeeId.Value;
            else
                query = e => true;

            var result = await base.PagedAsync(query, pageIndex, pageSize);
            return result;
        }

        public async Task<IList<EmployeePermissionShip>> RetrieveAsync(EmployeePermissionShipQueryParameter param)
        {

            Expression<Func<EmployeePermissionShip, bool>> query = null;
            if (param == null && param.RoleId != null && param.EmployeeId != null)
                query = e => e.RoleId == param.RoleId.Value && e.EmployeeId == param.EmployeeId.Value;
            else if (param == null && param.RoleId != null)
                query = e => e.RoleId == param.RoleId.Value;
            else if (param == null && param.EmployeeId != null)
                query = e => e.EmployeeId == param.EmployeeId.Value;
            else
                query = e => true;

            var list = (await base.SelectAsync(query)).ToList();
            return list;
        }

        public async Task<IList<Permission>> GetCustomPermissionsByEmployeeIdAsync(Guid employeeId)
        {
            var list = (await base.SelectAsync(e => e.CustomPermissionId != null && e.EmployeeId == employeeId)).ToList();
            var customPermissionids = list.Select(e => e.CustomPermissionId.Value).ToArray();
            var permissions = await _permissionQueryEntry.GetByPermissionIdsAsync(customPermissionids);
            return permissions;
        }

        public async Task<IList<Employee>> GetEmployeesByRoleIdAsync(Guid roleId)
        {
            var list = (await base.SelectAsync(e => e.RoleId != null && e.RoleId == roleId)).ToList();
            var userIds = list.Select(e => e.EmployeeId).ToArray();
            var employees = await _employeeQueryEntry.GetByIdsAsync(userIds);
            return employees;
        }

        public async Task<IList<Role>> GetRolesByEmployeeIdAsync(Guid employeeId)
        {
            var list = (await base.SelectAsync(e => e.RoleId != null && e.EmployeeId == employeeId)).ToList();
            var roleIds = list.Select(e => e.RoleId.Value).ToArray();
            var roles = await _roleQueryEntry.GetByIdsAsync(roleIds);
            return roles;
        }

        public async Task<IList<Employee>> GetEmployeesByRoleCodeAsync(string roleCode)
        {
            if (string.IsNullOrWhiteSpace(roleCode))
                throw new ArgumentNullException(nameof(roleCode));
            var role = await _roleQueryEntry.FindByCodeAsync(roleCode);
            var users = await GetEmployeesByRoleIdAsync(role.Id);
            return users;
        }
    }
}
