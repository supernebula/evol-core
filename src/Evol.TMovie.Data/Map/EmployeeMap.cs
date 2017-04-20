using Evol.EntityFramework.Configueration;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.TMovie.Data.Map
{
    public class EmployeeMap : EntityConfigMap<Employee>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Salt).IsRequired().HasMaxLength(100);
            builder.Property(e => e.RealName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastLoginTime).IsRequired(false);
            builder.Property(e => e.LoginCount).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
