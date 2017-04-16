using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;


namespace Evol.TMovie.Data.Repositories
{
    public class PermissionRepository : BasicEntityFrameworkRepository<Permission, TMovieDbContext>, IPermissionRepository
    {
        public PermissionRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
