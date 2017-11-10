using System.Data.Entity;

namespace Evol.Fx.EntityFramework.Repository
{
    public interface IEfDbContextProvider
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
