using Evol.Common;
using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.Entities;
using Sample.Domain.QueryEntries;
using Sample.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Storage.QueryEntries
{
    public class CommentQueryEntry : BaseEntityFrameworkCoreQuery<Comment, Guid, EvolSampleDbContext>, ICommentQueryEntry
    {

        public CommentQueryEntry(IEfCoreDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public async Task<IPaged<Comment>> PagedAsync(int pageIndex, int pageSize, CommentQueryParameter param)
        {
            Func<IQueryable<Comment>, IQueryable<Comment>> query = (queryable) => {
                if (param == null)
                    return queryable;
                if (param.PostId != null)
                    queryable = queryable.Where(e => e.PostId == param.PostId.Value);
                if (param.UserId != null)
                    queryable = queryable.Where(e => e.UserId == param.UserId.Value);
                return queryable;
            };
            return await base.PagedAsync(query, pageIndex, pageSize);
        }

        public async Task<List<Comment>> SelectAsync(CommentQueryParameter param)
        {
            Func<IQueryable<Comment>, IQueryable<Comment>> query = (queryable) => {
                if (param == null)
                    return queryable;
                if (param.PostId != null)
                    queryable = queryable.Where(e => e.PostId == param.PostId.Value);
                if (param.UserId != null)
                    queryable = queryable.Where(e => e.UserId == param.UserId.Value);
                return queryable;
            };
            return await SelectAsync(query);
        }
    }
}
