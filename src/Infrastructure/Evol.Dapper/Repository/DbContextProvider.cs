using Evol.Configuration;

namespace Evol.Dapper.Repository
{
    public class DapperDbContextProvider : IDapperDbContextProvider
    {
        public TDbContext Get<TDbContext>() where TDbContext : DapperDbContext
        {
            var context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            return context;
        }
    }
}
