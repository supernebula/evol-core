using Evol.EntityFrameworkCore.Configuration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class ShopCartMap : EntityConfigMap<ShopCart>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("ShopCart");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Number).IsRequired();
            builder.Property(e => e.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
