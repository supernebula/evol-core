using Microsoft.EntityFrameworkCore;
using System;
using Evol.EntityFrameworkCore.Configuration;
using Evol.EntityFramework.Repository.Test.Map;

namespace Evol.EntityFramework.Repository.Test.Core
{
    public class FakeEcDbContext : DbContext
    {

        public FakeEcDbContext() : this(null)
        {
        }

        public FakeEcDbContext(DbContextOptions<FakeEcDbContext> options) : base(options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //方法一
            modelBuilder.AddConfiguration<FakeOrderMap>();
            modelBuilder.AddConfiguration<FakeProductMap>();
            modelBuilder.AddConfiguration<FakeUserMap>();
            ////方法二
            //modelBuilder.AddConfigurationFromAssembly(this.GetType().GetTypeInfo().Assembly);
        }
    }
}
