using Evol.Fx.EntityFramework.Repository;
using System.Data.Entity;
using Evol.Configuration;

namespace Evol.Fx.EntityFramework.Uow
{
    public class EfDbContextProvider : IEfDbContextProvider
    {
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var context = AppConfig.Current.IoCManager.GetService<TDbContext>();
            return context;
        }
    }
}
