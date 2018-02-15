using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFrameworkCore.MySql.Repository
{
    public interface IEfCoreDbContextProvider
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
