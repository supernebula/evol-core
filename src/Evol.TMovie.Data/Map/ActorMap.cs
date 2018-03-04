using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.Map
{
    public class ActorMap : EntityConfigMap<Actor>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Actor");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ImagePath).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
