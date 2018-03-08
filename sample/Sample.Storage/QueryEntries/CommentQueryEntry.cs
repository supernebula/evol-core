using Evol.Common;
using Evol.EntityFrameworkCore.MySql.Repository;
using Sample.Domain.Models.Entities;
using Sample.Domain.QueryEntries;
using Sample.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
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
            return await base.PagedAsync(e => e.PostId == param.PostId, pageIndex, pageSize);
        }

        public async Task<List<Comment>> SelectAsync(CommentQueryParameter param)
        {
            return await base.SelectAsync(e => e.PostId == param.PostId);
        }
    }
}
