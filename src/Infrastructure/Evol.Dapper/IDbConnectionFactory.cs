
namespace Evol.Dapper.Repository
{
    public interface IDbConnectionFactory<out TDbContext> where TDbContext : DapperDbContext
    {
        TDbContext Create();
    }
}
