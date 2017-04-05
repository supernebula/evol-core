using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class ActorRepository : BasicEntityFrameworkRepository<Actor, TMovieDbContext>, IActorRepository
    {
        public ActorRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
