using System;
using Evol.TMovie.Domain.Models.AggregateRoots;
using Evol.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Evol.TMovie.Data.Map
{
    public class MovieMap : EntityConfigMap<Movie>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            var builder = EntityBuilder(modelBuilder);
            builder.ToTable("Movie");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ForeignName).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.ReleaseDate).IsRequired();
            builder.Property(e => e.Minutes).IsRequired();
            builder.Property(e => e.ReleaseRegion).IsRequired(false).HasMaxLength(100);
            builder.Property(e => e.SpaceType).IsRequired(true);
            builder.Property(e => e.CoverUri).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(e => e.Ratings);
            builder.Property(e => e.Language).IsRequired().HasMaxLength(30);
            builder.Ignore(e => e.Actors);
            builder.Ignore(e => e.Images);
            builder.Ignore(e => e.Categorys);
            builder.Ignore(e => e.Tags);
            builder.Ignore(e => e.Images);
            builder.Property(e => e.CreateTime).IsRequired();

        }
    }
}
