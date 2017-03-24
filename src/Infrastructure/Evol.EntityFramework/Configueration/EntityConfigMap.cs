using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evol.EntityFramework.Configueration
{
    public abstract class EntityConfigMap<TEntity> : EntityConfigMap where TEntity : class
    {
        public EntityTypeBuilder<TEntity> EntityBuilder(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<TEntity>();
        }
    }

    public abstract class EntityConfigMap
    {
        public abstract void Map(ModelBuilder modelBuilder);
    }
}
