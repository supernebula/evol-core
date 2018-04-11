using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.Domain.Data;
using Evol.Common.Data;

namespace Evol.TMovie.Domain.QueryEntries
{
    public interface IActorQueryEntry : IQueryEntry
    {
        Task<Actor> FindAsync(Guid id);

        Task<List<Actor>> RetrieveAsync(ActorQueryParameter param);

        Task<IPaged<Actor>> PagedAsync(ActorQueryParameter param);
    }
}
