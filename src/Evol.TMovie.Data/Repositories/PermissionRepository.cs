using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;


namespace Evol.TMovie.Data.Repositories
{
    public class PermissionRepository : BaseEntityFrameworkRepository<Permission, TMovieDbContext>, IPermissionRepository
    {
        public PermissionRepository(IEfUnitOfWorkDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
