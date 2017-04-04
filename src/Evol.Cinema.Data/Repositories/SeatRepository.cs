using Evol.TMovie.Domain.Models.Entitys;
using Evol.TMovie.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.TMovie.Data.Repositories
{
    public class SeatRepository : BasicEntityFrameworkRepository<Seat, TMovieDbContext>, ISeatRepository
    {
    }
}
