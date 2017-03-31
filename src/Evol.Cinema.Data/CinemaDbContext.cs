using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using Evol.EntityFramework.Repository;

namespace Evol.Cinema.Data
{

    public class CinemaDbContext : NamedDbContext
    {
        static CinemaDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CinemaDbContext>());
        }
        public CinemaDbContext() : base("name=CinemaConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Name = "cinemaDbContext";
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
