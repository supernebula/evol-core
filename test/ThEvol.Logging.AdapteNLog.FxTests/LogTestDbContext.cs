using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Evol.Logging.AdapteNLog.FxTests
{
    public class LogTestDbContext : DbContext
    {
        static LogTestDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LogTestDbContext>());
        }

        public LogTestDbContext() : base("name=LogTestDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //方法一
            //modelBuilder.Configurations.Add(new ProductMap());
            //...

            //方法二
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
