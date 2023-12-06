﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    [Migration("20231101173625_Seeding data for Diffcilties and regions")]
    partial class SeedingdataforDiffciltiesandregions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd6666fd-6d2f-4a1b-a2c3-8bc1ca0e74c1"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("05abb55d-3f75-471a-8f05-c8e8c506f15d"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("ceb67693-65ed-4975-be6d-3755069ad11b"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb7aec7f-d049-497a-abe4-5616afccfd47"),
                            Code = "hyd",
                            Name = "Hyderabad",
                            RegionImageURL = "SOme-image.jpg"
                        },
                        new
                        {
                            Id = new Guid("d450126e-1ed2-4e9c-801d-bfd0d51be7c2"),
                            Code = "Bng",
                            Name = "Bangalore",
                            RegionImageURL = "Bangalore-image.jpg"
                        },
                        new
                        {
                            Id = new Guid("c0ece3dd-d65a-4d74-ad1b-b83f2e46cc30"),
                            Code = "Ptr",
                            Name = "Penturu",
                            RegionImageURL = "Penturu-Image.png"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthINKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
