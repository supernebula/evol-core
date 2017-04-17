
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;

namespace Evol.TMovie.Data.Repositories
{
    public class SeatRepository : BaseEntityFrameworkRepository<Seat, TMovieDbContext>, ISeatRepository
    {
        public SeatRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
