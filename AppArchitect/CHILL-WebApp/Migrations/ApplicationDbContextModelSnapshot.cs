﻿// <auto-generated />
using System;
using CHILL_WebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CHILL_WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CHILL_WebApp.Models.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("X1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("X2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("X3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("X4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Y1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Y2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Y3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Y4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExpertsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertsId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsLabeled")
                        .HasColumnType("bit");

                    b.Property<int?>("LabelId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("ExpertPhoto", b =>
                {
                    b.Property<int>("ExpertsId")
                        .HasColumnType("int");

                    b.Property<int>("PhotosId")
                        .HasColumnType("int");

                    b.HasKey("ExpertsId", "PhotosId");

                    b.HasIndex("PhotosId");

                    b.ToTable("ExpertPhoto");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Coordinate", b =>
                {
                    b.HasOne("CHILL_WebApp.Models.Photo", "Photos")
                        .WithMany("Coordinates")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Label", b =>
                {
                    b.HasOne("CHILL_WebApp.Models.Expert", "Experts")
                        .WithMany()
                        .HasForeignKey("ExpertsId");

                    b.Navigation("Experts");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Photo", b =>
                {
                    b.HasOne("CHILL_WebApp.Models.Label", "Labels")
                        .WithMany("Photos")
                        .HasForeignKey("LabelId");

                    b.Navigation("Labels");
                });

            modelBuilder.Entity("ExpertPhoto", b =>
                {
                    b.HasOne("CHILL_WebApp.Models.Expert", null)
                        .WithMany()
                        .HasForeignKey("ExpertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CHILL_WebApp.Models.Photo", null)
                        .WithMany()
                        .HasForeignKey("PhotosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Label", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("CHILL_WebApp.Models.Photo", b =>
                {
                    b.Navigation("Coordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
