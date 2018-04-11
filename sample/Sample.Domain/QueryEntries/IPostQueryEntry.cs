using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Common;
using Evol.Common.Data;
using Evol.Domain.Data;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.QueryEntries.Parameters;

namespace Sample.Domain.QueryEntries
{
    public interface IPostQueryEntry : IQueryEntry
    {
        Task<Post> FindAsync(Guid id);

        Task<List<Post>> SelectAsync(PostQueryParameter param);

        Task<IPaged<Post>> PagedAsync(int pageIndex, int pageSize, PostQueryParameter param);
    }
}

