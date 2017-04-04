using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IActorQueryEntry : IQueryEntry
    {
        Actor Fetch(Guid id);

        Task<Actor> FetchAsync(Guid id);

        List<Actor> Retrieve(ActorQueryParameter param);

        Task<List<Actor>> RetrieveAsync(ActorQueryParameter param);

        IPaged<Actor> RetrievePaged(ActorQueryParameter param);

        Task<IPaged<Actor>> RetrievePagedAsync(ActorQueryParameter param);
    }
}
