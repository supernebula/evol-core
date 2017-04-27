using Evol.Dapper.Repository;
using Evol.Domain;

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
