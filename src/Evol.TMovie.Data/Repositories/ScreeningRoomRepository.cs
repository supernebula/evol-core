using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class ScreeningRoomRepository : BaseEntityFrameworkRepository<ScreeningRoom, TMovieDbContext>, IScreeningRoomRepository
    {
        public ScreeningRoomRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
