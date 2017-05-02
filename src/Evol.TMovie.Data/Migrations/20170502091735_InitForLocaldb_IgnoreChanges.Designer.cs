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
    [Migration("20170502091735_InitForLocaldb_IgnoreChanges")]
    partial class InitForLocaldb_IgnoreChanges
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

                    b.Property<DateTime?>("LastLoginTime");

                    b.Property<int>("LoginCount");

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

                    b.Property<Guid>("ProductId");

                    b.Property<float>("Ratings");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("ReleaseRegion")
                        .HasMaxLength(100);

                    b.Property<int>("SpaceType");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("ItemCount");

                    b.Property<string>("No");

                    b.Property<DateTime?>("PayTime");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<float>("FixPrice");

                    b.Property<int>("GoodsState");

                    b.Property<int>("QuantityPerUnit");

                    b.Property<float>("SellPrice");

                    b.Property<int>("Stock");

                    b.Property<Guid>("SupplierId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");
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

                    b.Property<int>("SpaceType");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ScreeningRoom");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.ShopCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("Number");

                    b.Property<float>("Price");

                    b.Property<Guid>("ProductId");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ShopCart");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.AggregateRoots.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(100);

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

                    b.ToTable("User");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.Entities.EmployeePermissionShip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid?>("CustomPermissionId");

                    b.Property<Guid>("EmployeeId");

                    b.Property<Guid?>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("EmployeePermissionShip");
                });

            modelBuilder.Entity("Evol.TMovie.Domain.Models.Entities.RolePermissionShip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<Guid>("PermissionId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RolePermissionShip");
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
