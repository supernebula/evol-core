using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Evol.TMovie.Data;
using Evol.TMovie.Domain.Models.Values;

namespace Evol.TMovie.Data.Migrations
{
    [DbContext(typeof(TMovieDbContext))]
    [Migration("20170412082106_Initial-IgnoreChanges")]
    partial class InitialIgnoreChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Cinema");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverUri")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("ForeignName")
                        .HasMaxLength(100);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("Minutes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("ProductId");

                    b.Property<float>("Ratings");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("ReleaseRegion")
                        .HasMaxLength(100);

                    b.Property<int>("SpaceType");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Screening", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CinemaId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<DateTime>("EndTime");

                    b.Property<Guid>("MovieId");

                    b.Property<double>("Price");

                    b.Property<Guid>("ScreeningRoomId");

                    b.Property<double>("SellPrice");

                    b.Property<int>("SpaceType");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("Screening");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.ScreeningRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CinemaId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("SpaceType");

                    b.HasKey("Id");

                    b.ToTable("ScreeningRoom");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColumnNo");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("RowNo");

                    b.Property<Guid>("ScreeningRoomId");

                    b.Property<int>("SeatType");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Seat");
                });
        }
    }
}
