using Evol.EntityFramework.Configueration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class UserMap : EntityConfigMap<User>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("User");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Salt).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RealName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Mobile).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
