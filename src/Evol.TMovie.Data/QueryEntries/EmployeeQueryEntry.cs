using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evol.TMovie.Data.QueryEntries
{
    public class EmployeeQueryEntry : IEmployeeQueryEntry
    {
        private IEmployeeRepository _employeeRepository { get; set; }
        public EmployeeQueryEntry(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> FetchAsync(Guid id)
        {
            return await _employeeRepository.FindAsync(id);
        }

        public async Task<List<Employee>> GetByIdsAsync(Guid[] ids)
        {
            return (await _employeeRepository.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }

        public async Task<List<Employee>> RetrieveAsync(EmployeeQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var list = (await _employeeRepository.RetrieveAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key))).ToList();
            return list;
        }

        public async Task<IPaged<Employee>> PagedAsync(EmployeeQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var result = await _employeeRepository.PagedAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key), pageIndex, pageSize);
            return result;
        }
    }
}
