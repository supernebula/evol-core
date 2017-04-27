
namespace Evol.Dapper.Repository
{
    public interface IDapperDbContextProvider
    {
        TDbContext Get<TDbContext>() where TDbContext : DapperDbContext;
    }
}
