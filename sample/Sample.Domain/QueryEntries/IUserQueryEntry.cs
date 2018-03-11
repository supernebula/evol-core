using Evol.Common;
using Evol.Domain.Data;
using Sample.Domain.Models.AggregateRoots;
using Sample.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Domain.QueryEntries
{
    public interface IUserQueryEntry : IQueryEntry
    {
        Task<User> FindAsync(Guid id);

        Task<List<User>> SelectAsync(UserQueryParameter param);

        Task<IPaged<User>> PagedAsync(int pageIndex, int pageSize, UserQueryParameter param);
    }
}
