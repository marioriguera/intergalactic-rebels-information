﻿// <auto-generated />
using System;
using ConfigsInfraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConfigsInfraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240719123606_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConfigsDomain.Entities.HomeViewSlider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasColumnOrder(0);

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Alt")
                        .HasColumnOrder(20);

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Src")
                        .HasColumnOrder(10);

                    b.HasKey("Id");

                    b.ToTable("HomeViewSliders", "HomeViewConfigs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e7bc13e9-0e2a-4ad1-83ae-1130c3862b3c"),
                            Alt = "Wallpaper start",
                            Src = "https://wallpapersmug.com/download/3840x2160/d06c64/starry-space-milky-way-stars.jpg"
                        },
                        new
                        {
                            Id = new Guid("9444b29d-f459-4ff2-bfc6-dacea6543288"),
                            Alt = "Universe nebulosa",
                            Src = "https://wallpapers.com/images/hd/4k-universe-eta-carinae-nebula-2iqpijwfzmw3z4al.jpg"
                        },
                        new
                        {
                            Id = new Guid("c4438db0-7b74-4f66-b37b-7259b1273c4a"),
                            Alt = "Glowing ring",
                            Src = "https://wallpapers.com/images/hd/4k-space-glowing-ring-es4tss2e6i1dzfj6.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
