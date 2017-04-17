using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.Entities;
using Evol.TMovie.Domain.Repositories;

namespace Evol.TMovie.Data.Repositories
{
    public class RolePermissionShipRepository : BaseEntityFrameworkRepository<RolePermissionShip, TMovieDbContext>, IRolePermissionShipRepository
    {
        public RolePermissionShipRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
