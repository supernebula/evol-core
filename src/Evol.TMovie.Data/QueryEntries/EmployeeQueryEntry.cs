using Evol.Common;
using Evol.EntityFramework.Repository;
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
    public class EmployeeQueryEntry : BaseEntityFrameworkQuery<Employee, TMovieDbContext>, IEmployeeQueryEntry
    {
        public EmployeeQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Employee>> GetByIdsAsync(Guid[] ids)
        {
            return (await base.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }

        public async Task<List<Employee>> RetrieveAsync(EmployeeQueryParameter param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var list = (await base.RetrieveAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key))).ToList();
            return list;
        }

        public async Task<IPaged<Employee>> PagedAsync(EmployeeQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Key == null)
                throw new ArgumentNullException((nameof(param.Key)));

            var result = await base.PagedAsync(e => e.Username.StartsWith(param.Key) || e.RealName.StartsWith(param.Key), pageIndex, pageSize);
            return result;
        }
    }
}
