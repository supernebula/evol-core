using Evol.Common;
using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.QueryEntries;
using Sample.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Storage.QueryEntries
{
    public class PostQueryEntry : BaseEntityFrameworkCoreQuery<Post, Guid, EvolSampleDbContext>, IPostQueryEntry
    {

        public PostQueryEntry(IEfCoreDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<IPaged<Post>> PagedAsync(int pageIndex, int pageSize, PostQueryParameter param)
        {
            Func<IQueryable<Post>, IQueryable<Post>> query = (queryable) => {
                if (param == null)
                    return queryable;
                if (!string.IsNullOrWhiteSpace(param.Title))
                    queryable = queryable.Where(e => e.Title.Contains(param.Title));
                if (!string.IsNullOrWhiteSpace(param.Key))
                    queryable = queryable.Where(e => e.Content.Contains(param.Key));
                return queryable;
            };
            return await base.PagedAsync(query, pageIndex, pageSize);
        }

        public async Task<List<Post>> SelectAsync(PostQueryParameter param)
        {
            return await base.SelectAsync(e => e.Title.Contains(param.Title));
        }
    }
}
