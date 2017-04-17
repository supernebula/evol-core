using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Common;
using Evol.Domain.Data;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IRoleQueryEntry : IQueryEntry
    {
        Task<Role> FetchAsync(Guid id);

        Task<List<Role>> RetrieveAsync(RoleQueryParameter param);

        Task<IPaged<Role>> PagedAsync(RoleQueryParameter param, int pageIndex, int pageSize);

        Task<List<Role>> GetByIdsAsync(Guid[] ids);
    }
}
