using Evol.EntityFramework.Repository;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.TMovie.Domain.Repositories;

namespace Evol.TMovie.Data.Repositories
{
    public class RoleRepository : BasicEntityFrameworkRepository<Role, TMovieDbContext>, IRoleRepository
    {
        public RoleRepository(IEfDbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
