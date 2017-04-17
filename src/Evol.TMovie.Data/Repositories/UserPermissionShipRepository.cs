using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Repositories;

namespace Evol.TMovie.Data.Repositories
{
    public class UserPermissionShipRepository : BaseEntityFrameworkRepository<UserPermissionShip, TMovieDbContext>, IUserPermissionShipRepository
    {
        public UserPermissionShipRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
