using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.Cinema.Domain.Models.AggregateRoots;
using Evol.Cinema.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;

namespace Evol.Cinema.Domain.QueryEntries
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
