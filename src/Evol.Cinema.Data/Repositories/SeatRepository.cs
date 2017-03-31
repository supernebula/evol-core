using Evol.Cinema.Domain.Models.Entitys;
using Evol.Cinema.Domain.Repositories;
using Evol.EntityFramework.Repository;

namespace Evol.Cinema.Data.Repositories
{
    public class SeatRepository : BasicEntityFrameworkRepository<Seat, CinemaDbContext>, ISeatRepository
    {
    }
}
