﻿// <auto-generated />
using System;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221109135234_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Lab3.Models.Game", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RegularPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Studio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameName = "Lorem Ipsum",
                            Publisher = "ZSHT",
                            RegularPrice = 0m,
                            Studio = "Yacoper"
                        },
                        new
                        {
                            Id = 2,
                            GameName = "The Variant",
                            Publisher = "Yacoper",
                            RegularPrice = 71.99m,
                            Studio = "Yacoper"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
