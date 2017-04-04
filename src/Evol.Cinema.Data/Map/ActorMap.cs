using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.EntityFramework.Configueration;
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
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ImagePath).IsRequired(false);
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
