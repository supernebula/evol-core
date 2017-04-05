using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class ScreeningRoomRepository : BasicEntityFrameworkRepository<ScreeningRoom, TMovieDbContext>, IScreeningRoomRepository
    {
        public ScreeningRoomRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
