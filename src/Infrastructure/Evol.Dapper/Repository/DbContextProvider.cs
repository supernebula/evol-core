
namespace Evol.Dapper.Repository
{
    public class DbContextProvider<TDbContext> : IDbConnectionProvider<TDbContext> where TDbContext : DapperDbContext, new()
    {
        private TDbContext _dbContext;
        public TDbContext Create()
        {
            if (_dbContext == null)
                return _dbContext = new TDbContext();
            return _dbContext;
        }
    }
}
