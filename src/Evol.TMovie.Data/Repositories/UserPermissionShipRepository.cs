using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Repositories;

namespace Evol.TMovie.Data.Repositories
{
    public class UserPermissionShipRepository : BasicEntityFrameworkRepository<UserPermissionShip, TMovieDbContext>, IUserPermissionShipRepository
    {
        public UserPermissionShipRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
