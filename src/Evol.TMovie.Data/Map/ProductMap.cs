using Evol.EntityFrameworkCore.Configuration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class ProductMap : EntityConfigMap<Product>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Product");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Brand).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CategoryId).IsRequired();
            builder.Property(e => e.SupplierId).IsRequired();
            builder.Property(e => e.QuantityPerUnit).IsRequired();
            builder.Property(e => e.FixPrice).IsRequired();
            builder.Property(e => e.SellPrice).IsRequired();
            builder.Property(e => e.Stock).IsRequired();
            builder.Property(e => e.GoodsState).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
