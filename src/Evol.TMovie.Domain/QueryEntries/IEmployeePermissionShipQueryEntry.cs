using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IEmployeePermissionShipQueryEntry : IQueryEntry
    {
        Task<EmployeePermissionShip> FetchAsync(Guid id);

        Task<IList<EmployeePermissionShip>> RetrieveAsync(EmployeePermissionShipQueryParameter param);

        Task<IPaged<EmployeePermissionShip>> PagedAsync(EmployeePermissionShipQueryParameter param, int pageIndex, int pageSize);

        Task<IList<Role>> GetRolesByEmployeeIdAsync(Guid employeeId);

        Task<IList<Permission>> GetCustomPermissionsByEmployeeIdAsync(Guid employeeId);

        Task<IList<Employee>> GetEmployeesByRoleIdAsync(Guid roleId);
    }
}
