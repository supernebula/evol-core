
namespace Evol.Dapper.Repository
{
    public interface IDbConnectionProvider<out TDbContext> where TDbContext : DapperDbContext
    {
        TDbContext Create();
    }
}
