//using Evol.EntityFramework.Repository;
//using Microsoft.EntityFrameworkCore;
//using Evol.Domain;

//namespace Evol.Dapper.Uow
//{
//    public class EfDbContextProvider : IEfDbContextProvider
//    {
//        public TDbContext Get<TDbContext>() where TDbContext : DbContext
//        {
//            var context = AppConfig.Current.IoCManager.GetService<TDbContext>();
//            return context;
//        }
//    }
//}
