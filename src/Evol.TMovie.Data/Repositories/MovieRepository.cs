using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class MovieRepository : BaseEntityFrameworkRepository<Movie, TMovieDbContext>, IMovieRepository
    {
        public MovieRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
