using Evol.EntityFrameworkCore.Configuration;
using Evol.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Evol.EntityFramework.Repository.Test.Map
{
    public class FakeProductMap : EntityConfigMap<FakeProduct>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100).HasColumnName("Name");
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(8000);
            builder.Property(e => e.SourceUri).HasMaxLength(500);
            builder.Property(e => e.SourceSite).HasMaxLength(100);
            builder.Property(e => e.Picture).HasMaxLength(500);
            builder.Property(e => e.CreateTime).IsRequired();
            builder.Property(e => e.Price).HasColumnName("Price").HasAnnotation("商品价格", "value");
            builder.Ignore(e => e.Specs);
        }


    }
}
