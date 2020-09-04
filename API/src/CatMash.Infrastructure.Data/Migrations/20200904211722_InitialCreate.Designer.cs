﻿// <auto-generated />
using CatMash.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatMash.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CatMashDbContext))]
    [Migration("20200904211722_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("CatMash.Domain.Entities.DTO.Cat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}