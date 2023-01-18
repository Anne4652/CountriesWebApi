﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CountriesWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CountriesWebApi.Migrations
{
    [DbContext(typeof(CountriesDbContext))]
    [Migration("20221125123350_gDB")]
    partial class gDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CountriesWebApi.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alpha3Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Borders")
                        .HasColumnType("text[]");

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Population")
                        .HasColumnType("integer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subregion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CountriesWebApi.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CountriesWebApi.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("CountriesWebApi.Entities.Currency", b =>
                {
                    b.HasOne("CountriesWebApi.Entities.Country", null)
                        .WithMany("Currencies")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CountriesWebApi.Entities.Language", b =>
                {
                    b.HasOne("CountriesWebApi.Entities.Country", null)
                        .WithMany("Languages")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CountriesWebApi.Entities.Country", b =>
                {
                    b.Navigation("Currencies");

                    b.Navigation("Languages");
                });
#pragma warning restore 612, 618
        }
    }
}