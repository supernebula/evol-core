using Evol.EntityFramework.Configueration;
using Evol.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeOrderMap : EntityConfigMap<FakeOrder>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("TestOrder");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Recipient).IsRequired().HasMaxLength(100).HasColumnName("Recipient");
            builder.Property(e => e.Address).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Number).IsRequired();
            builder.Property(e => e.Remark).IsRequired(false);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
