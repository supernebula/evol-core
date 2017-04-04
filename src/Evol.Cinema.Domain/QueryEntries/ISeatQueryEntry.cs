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
        Seat Fetch(Guid id);

        Task<Seat> FetchAsync(Guid id);

        List<Seat> Retrieve(ActorQueryParameter param);

        Task<List<Seat>> RetrieveAsync(ActorQueryParameter param);

        IPaged<Seat> RetrievePaged(ActorQueryParameter param);

        Task<IPaged<Seat>> RetrievePagedAsync(ActorQueryParameter param);
    }
}
