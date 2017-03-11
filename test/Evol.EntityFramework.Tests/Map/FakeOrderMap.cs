using System.Data.Entity.ModelConfiguration;
using Evol.Test.Model;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeOrderMap : EntityTypeConfiguration<FakeOrder>
    {
        public FakeOrderMap()
        {
            this.ToTable("TestOrder");
            this.HasKey(e => e.Id);
            this.Property(e => e.ProductId).IsRequired();
            this.Property(e => e.UserId).IsRequired();
            this.Property(e => e.Recipient).IsRequired().HasMaxLength(100).HasColumnName("Recipient");
            this.Property(e => e.Address).IsRequired().HasMaxLength(500);
            this.Property(e => e.Amount).IsRequired();
            this.Property(e => e.Number).IsRequired();
            this.Property(e => e.Remark).IsOptional();
            this.Property(e => e.CreateTime).IsRequired();
        }
    }
}
