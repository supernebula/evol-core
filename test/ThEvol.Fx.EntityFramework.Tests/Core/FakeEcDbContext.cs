using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace Evol.Fx.EntityFramework.Repository.Test.Core
{
    public class FakeEcDbContext : DbContext
    {
        static FakeEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FakeEcDbContext>());
        }

        public FakeEcDbContext() : base("name=FakeEcConnectionString")
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
