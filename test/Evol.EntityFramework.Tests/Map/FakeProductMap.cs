using System.Data.Entity.ModelConfiguration;
using Evol.Test.Model;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeProductMap : EntityTypeConfiguration<FakeProduct>
    {
        public FakeProductMap()
        {
            this.ToTable("Product");
            this.HasKey(e => e.Id);
            this.Property(e => e.Title).IsRequired().HasMaxLength(100).HasColumnName("Name");
            this.Property(e => e.Description).IsOptional().HasMaxLength(8000);
            this.Property(e => e.SourceUri).HasMaxLength(500);
            this.Property(e => e.SourceSite).HasMaxLength(100);
            this.Property(e => e.Picture).HasMaxLength(500);
            this.Property(e => e.CreateTime).IsRequired();


            this.ToTable("Product");
            this.Property(e => e.Price).HasColumnName("Price").HasColumnAnnotation("商品价格", "value");
            this.Ignore(e => e.Specs);
        }


    }
}
