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
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Code == null || param.Name == null)
                throw new ArgumentNullException(($"{nameof(param.Code)} & {nameof(param.Name)}"));

            Expression<Func<Permission, bool>> query = null;
            if (param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Title.StartsWith(param.Name);
            else if (param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param.Name != null)
                query = e => e.Title.StartsWith(param.Name);

            var list = (await base.RetrieveAsync(query)).ToList();
            return list;
        }

        public async Task<IPaged<Permission>> PagedAsync(PermissionQueryParameter param, int pageIndex, int pageSize)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));
            if (param.Code == null || param.Name == null)
                throw new ArgumentNullException(($"{nameof(param.Code)} & {nameof(param.Name)}"));

            Expression<Func<Permission, bool>> query = null;
            if (param.Code != null && param.Name != null)
                query = e => e.Code.StartsWith(param.Code) && e.Title.StartsWith(param.Name);
            else if (param.Code != null)
                query = e => e.Code.StartsWith(param.Code);
            else if (param.Name != null)
                query = e => e.Title.StartsWith(param.Name);

            return await base.PagedAsync(query, pageIndex, pageSize);
        }

        public async Task<List<Permission>> GetByPermissionIdsAsync(Guid[] ids)
        {
            return (await base.RetrieveAsync(e => ids.Contains(e.Id))).ToList();
        }
    }
}