using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IEmployeeQueryEntry : IQueryEntry
    {

        Task<Employee> FindAsync(Guid id);

        Task<Employee> FindByUsernameAsync(string username);

        Task<List<Employee>> RetrieveAsync(EmployeeQueryParameter param);


        Task<IPaged<Employee>> PagedAsync(EmployeeQueryParameter param, int pageIndex, int pageSize);

        Task<List<Employee>> GetByIdsAsync(Guid[] ids);
    }
}
