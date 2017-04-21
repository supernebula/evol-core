using Evol.Common;
using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Expression<Func<Employee, bool>> query = null;
            if (param != null && !string.IsNullOrWhiteSpace(param.Key))
                query = e => e.Username.Contains(param.Key) || e.RealName.Contains(param.Key);
            else
                query = e => true;

            var list = (await base.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<Employee>> PagedAsync(EmployeeQueryParameter param, int pageIndex, int pageSize)
        {
            Expression<Func<Employee, bool>> query = null;
            if (param != null && !string.IsNullOrWhiteSpace(param.Key))
                query = e => e.Username.Contains(param.Key) || e.RealName.Contains(param.Key);
            else
                query = e => true;

            var result = await base.PagedAsync(query, pageIndex, pageSize);
            return result;
        }

        public async Task<Employee> FindByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException();
            return (await base.RetrieveAsync(e => e.Username == username)).FirstOrDefault();
        }
    }
}
