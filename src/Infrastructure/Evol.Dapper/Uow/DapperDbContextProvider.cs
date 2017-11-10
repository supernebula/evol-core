using Evol.Configuration;
using Evol.Dapper.Repository;

namespace Evol.Dapper.Uow
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
