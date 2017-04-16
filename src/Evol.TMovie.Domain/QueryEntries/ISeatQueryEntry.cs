using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface ISeatQueryEntry : IQueryEntry
    {
        Task<Seat> FetchAsync(Guid id);

        Task<List<Seat>> RetrieveAsync(ActorQueryParameter param);

        Task<IPaged<Seat>> PagedAsync(ActorQueryParameter param, int pageIndex, int pageSize);
    }
}
