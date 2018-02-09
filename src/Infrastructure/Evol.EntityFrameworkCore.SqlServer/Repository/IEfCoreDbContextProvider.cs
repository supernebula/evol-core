using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFrameworkCore.SqlServer.Repository
{
    public interface IEfCoreDbContextProvider
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
