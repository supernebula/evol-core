
using System.Reflection;
using Evol.EntityFramework.Repository.Test.Migrations;
using Evol.EntityFramework.Repository;

namespace Evol.EntityFramework.Repository.Test.Core
{
    public class FakeEcDbContext : NamedDbContext 
    {

        static FakeEcDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FakeEcDbContext>());
        }

        public FakeEcDbContext() : base("name=fakeEcDbContext")
        {
            Name = GetType().FullName + "#fakeEcDbContext";
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //方法一
            //modelBuilder.Configurations.Add(new FakeProductMap());
            //modelBuilder.Configurations.Add(new FakeUserMap());
            //modelBuilder.Configurations.Add(new FakeOrderMap());
            // Add more EntityMap...

            //方法二
            //var typesRegister =
            //    Assembly.GetExecutingAssembly().GetTypes()
            //        .Where(t => string.IsNullOrWhiteSpace(t.Namespace))
            //        .Where( t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>));
            //foreach (var type in typesRegister)
            //{
            //    dynamic configurationObj = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationObj);
            //}

            //方法三
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
