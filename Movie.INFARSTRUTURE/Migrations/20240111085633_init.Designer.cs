﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie.INFARSTRUTURE;

#nullable disable

namespace Movie.INFARSTRUTURE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240111085633_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Movie.INFARSTRUTURE.Entities.Movie", b =>
                {
                    b.Property<Guid>("mv_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<string>("mv_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("release_date")
                        .HasColumnType("datetime2");

                    b.HasKey("mv_id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}