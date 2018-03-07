using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Common;
using Evol.Domain.Data;
using Sample.Domain.Models.Entities;
using Sample.Domain.QueryEntries.Parameters;

namespace Sample.Domain.QueryEntries
{
    public interface ICommentQueryEntry : IQueryEntry
    {
        Task<Comment> FindAsync(string id);

        Task<List<Comment>> SelectAsync(CommentQueryParameter param);

        Task<IPaged<Comment>> PagedAsync(int pageIndex, int pageSize, CommentQueryParameter param);
    }
}
