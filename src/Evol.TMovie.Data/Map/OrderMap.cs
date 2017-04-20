using Evol.EntityFramework.Configueration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{

    public class OrderMap : EntityConfigMap<Order>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Order");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId).IsRequired();
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ItemCount).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
            builder.Ignore(e => e.Items);
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.PayTime).IsRequired(false);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
