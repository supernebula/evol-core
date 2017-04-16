using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Repositories;

namespace Evol.TMovie.Data.Repositories
{
    public class UserRolePermissionShipRepository : BasicEntityFrameworkRepository<UserRolePermissionShip, TMovieDbContext>, IUserRolePermissionShipRepository
    {
        public UserRolePermissionShipRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
