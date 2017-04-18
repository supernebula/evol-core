using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.QueryEntries;
using Evol.TMovie.Domain.QueryEntries.Parameters;
using Evol.Common;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.QueryEntries
{
    public class ActorQueryEntry : BaseEntityFrameworkQuery<Actor, TMovieDbContext>, IActorQueryEntry
    {
        public ActorQueryEntry(IEfDbContextProvider efDbContextProvider) : base(efDbContextProvider)
        {
        }

        public Task<List<Actor>> RetrieveAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }

        public Task<IPaged<Actor>> PagedAsync(ActorQueryParameter param)
        {
            throw new NotImplementedException();
        }
    }
}
