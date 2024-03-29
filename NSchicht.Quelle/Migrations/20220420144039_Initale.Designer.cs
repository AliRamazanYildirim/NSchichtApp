﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSchicht.Quelle;

#nullable disable

namespace NSchicht.Quelle.Migrations
{
    [DbContext(typeof(AppDbKontext))]
    [Migration("20220420144039_Initale")]
    partial class Initale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NSchicht.Kern.Kategorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ErstellungsDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("NeuesDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Kategorien", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ErstellungsDatum = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bleistifte"
                        },
                        new
                        {
                            ID = 2,
                            ErstellungsDatum = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Bücher"
                        },
                        new
                        {
                            ID = 3,
                            ErstellungsDatum = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Notizbücher"
                        });
                });

            modelBuilder.Entity("NSchicht.Kern.Produkt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("ErstellungsDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("NeuesDatum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Vorrat")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KategorieID");

                    b.ToTable("Produkte", (string)null);

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ErstellungsDatum = new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8276),
                            KategorieID = 1,
                            Name = "Aspekte Neu B2+",
                            Preis = 100m,
                            Vorrat = 100
                        },
                        new
                        {
                            ID = 2,
                            ErstellungsDatum = new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8300),
                            KategorieID = 1,
                            Name = "Aspekte Neu C1",
                            Preis = 110m,
                            Vorrat = 100
                        },
                        new
                        {
                            ID = 3,
                            ErstellungsDatum = new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8306),
                            KategorieID = 1,
                            Name = "Aspekte Neu C2",
                            Preis = 135m,
                            Vorrat = 100
                        },
                        new
                        {
                            ID = 4,
                            ErstellungsDatum = new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8311),
                            KategorieID = 2,
                            Name = "Rotring 800+ 0.7mm",
                            Preis = 85m,
                            Vorrat = 100
                        },
                        new
                        {
                            ID = 5,
                            ErstellungsDatum = new DateTime(2022, 4, 20, 17, 40, 38, 209, DateTimeKind.Local).AddTicks(8316),
                            KategorieID = 2,
                            Name = "Rotring 600 0.5mm",
                            Preis = 55m,
                            Vorrat = 100
                        });
                });

            modelBuilder.Entity("NSchicht.Kern.ProduktEigenschaft", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Breite")
                        .HasColumnType("int");

                    b.Property<string>("Farbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Höhe")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProduktID")
                        .IsUnique();

                    b.ToTable("ProduktEigenschaften");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Breite = 21,
                            Farbe = "Schwarz",
                            Höhe = 30,
                            ProduktID = 1
                        },
                        new
                        {
                            ID = 2,
                            Breite = 21,
                            Farbe = "Grün",
                            Höhe = 30,
                            ProduktID = 2
                        });
                });

            modelBuilder.Entity("NSchicht.Kern.Produkt", b =>
                {
                    b.HasOne("NSchicht.Kern.Kategorie", "Kategorie")
                        .WithMany("Produkte")
                        .HasForeignKey("KategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorie");
                });

            modelBuilder.Entity("NSchicht.Kern.ProduktEigenschaft", b =>
                {
                    b.HasOne("NSchicht.Kern.Produkt", "Produkt")
                        .WithOne("ProduktEigenschaft")
                        .HasForeignKey("NSchicht.Kern.ProduktEigenschaft", "ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("NSchicht.Kern.Kategorie", b =>
                {
                    b.Navigation("Produkte");
                });

            modelBuilder.Entity("NSchicht.Kern.Produkt", b =>
                {
                    b.Navigation("ProduktEigenschaft");
                });
#pragma warning restore 612, 618
        }
    }
}
