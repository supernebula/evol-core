using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models.AggregateRoots;

namespace Sample.Storage.Map
{
    public class PostMap : EntityConfigMap<Post>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Post");
            builder.HasKey(e => e.Id).HasAnnotation(nameof(Post.Id), new { TypeName = "BINARY(16)" });
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Content).IsRequired().HasMaxLength(1000);
            builder.Property(e => e.Tag).IsRequired().HasMaxLength(200);
            builder.Property(e => e.UserId).HasAnnotation(nameof(Post.Id), new { TypeName = "BINARY(16)" }).IsRequired();
            builder.Property(e => e.CreateTime).IsRequired();
        }
    }
}
