using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface ICinemaQueryEntry
    {
        Task<Cinema> FetchAsync(Guid id);

        Task<List<Cinema>> RetrieveAsync(CinemaQueryParameter param);

        Task<IPaged<Cinema>> PagedAsync(CinemaQueryParameter param, int pageIndex, int pageSize);
    }
}
