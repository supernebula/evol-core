using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class PermissionQueryEntry : BaseEntityFrameworkQuery<Permission, TMovieDbContext>, IPermissionQueryEntry
    {
        public PermissionQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<List<Permission>> RetrieveAsync(PermissionQueryParameter param)
        {

            Expression<Func<Permission, bool>> query = null;
            if (param == null && param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Title.StartsWith(param.Name);
            else if (param == null && param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param == null && param.Name != null)
                query = e => e.Title.StartsWith(param.Name);
            else
                query = e => true;

            var list = (await base.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<Permission>> PagedAsync(PermissionQueryParameter param, int pageIndex, int pageSize)
        {

            Expression<Func<Permission, bool>> query = null;
            if (param == null && param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Title.StartsWith(param.Name);
            else if (param == null && param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param == null && param.Name != null)
                query = e => e.Title.StartsWith(param.Name);
            else
                query = e => true;

            return await base.PagedAsync(query, pageIndex, pageSize);
        }

        public async Task<List<Permission>> GetByPermissionIdsAsync(Guid[] ids)
        {
            return (await base.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }

        public Task<List<Permission>> AllAsync()
        {
            var all = base.Query().ToList();
            return Task.FromResult(all);
        }
    }
}