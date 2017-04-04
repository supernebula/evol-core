
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;

namespace Evol.TMovie.Data.Repositories
{
    public class SeatRepository : BasicEntityFrameworkRepository<Seat, TMovieDbContext>, ISeatRepository
    {
        public SeatRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
