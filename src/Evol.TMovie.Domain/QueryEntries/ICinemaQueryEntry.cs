using Evol.Common;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Domain.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface ICinemaQueryEntry : IQueryEntry
    {
        Task<Cinema> FindAsync(Guid id);

        Task<List<Cinema>> RetrieveAsync(CinemaQueryParameter param);

        Task<IPaged<Cinema>> PagedAsync(CinemaQueryParameter param, int pageIndex, int pageSize);

        Task<List<Movie>> SelectShowingMoiveAsync(Guid cinemaId);
    }
}
