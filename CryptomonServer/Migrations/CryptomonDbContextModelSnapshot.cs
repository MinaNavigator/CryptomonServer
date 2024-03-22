﻿// <auto-generated />
using System;
using CryptomonServer.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CryptomonServer.Migrations
{
    [DbContext(typeof(CryptomonDbContext))]
    partial class CryptomonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CryptomonServer.Orm.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("CoinBalance")
                        .HasPrecision(32, 9)
                        .HasColumnType("numeric(32,9)");

                    b.Property<decimal>("MinaBalance")
                        .HasPrecision(32, 9)
                        .HasColumnType("numeric(32,9)");

                    b.Property<string>("RecoveryMail")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccountId");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Cryptomon", b =>
                {
                    b.Property<int>("CryptomonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CryptomonId"));

                    b.Property<int>("Atk")
                        .HasColumnType("integer");

                    b.Property<int>("CryptomonType")
                        .HasColumnType("integer");

                    b.Property<int>("Def")
                        .HasColumnType("integer");

                    b.Property<int>("Hp")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CryptomonId");

                    b.ToTable("Cryptomons");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Fruit", b =>
                {
                    b.Property<int>("FruitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FruitId"));

                    b.Property<int>("GrowTime")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PlantPrice")
                        .HasPrecision(32, 9)
                        .HasColumnType("numeric(32,9)");

                    b.Property<decimal>("SeedPrice")
                        .HasPrecision(32, 9)
                        .HasColumnType("numeric(32,9)");

                    b.HasKey("FruitId");

                    b.ToTable("Fruits");

                    b.HasData(
                        new
                        {
                            FruitId = 1,
                            GrowTime = 120,
                            Name = "Wheat",
                            PlantPrice = 0.04m,
                            SeedPrice = 0.02m
                        },
                        new
                        {
                            FruitId = 2,
                            GrowTime = 300,
                            Name = "Potato",
                            PlantPrice = 0.16m,
                            SeedPrice = 0.10m
                        },
                        new
                        {
                            FruitId = 3,
                            GrowTime = 3600,
                            Name = "Pumpkin",
                            PlantPrice = 0.80m,
                            SeedPrice = 0.40m
                        },
                        new
                        {
                            FruitId = 4,
                            GrowTime = 14400,
                            Name = "Beetroot",
                            PlantPrice = 1.8m,
                            SeedPrice = 1m
                        },
                        new
                        {
                            FruitId = 5,
                            GrowTime = 28800,
                            Name = "Cauliflower",
                            PlantPrice = 8m,
                            SeedPrice = 4m
                        },
                        new
                        {
                            FruitId = 6,
                            GrowTime = 86400,
                            Name = "Parsnip",
                            PlantPrice = 16m,
                            SeedPrice = 10m
                        },
                        new
                        {
                            FruitId = 7,
                            GrowTime = 259200,
                            Name = "Radish",
                            PlantPrice = 80m,
                            SeedPrice = 50m
                        });
                });

            modelBuilder.Entity("CryptomonServer.Orm.GameAction", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActionId"));

                    b.Property<int>("ActionType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("PayoutId")
                        .HasColumnType("bigint");

                    b.Property<string>("Player1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Player2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ActionId");

                    b.ToTable("GameActions");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Land", b =>
                {
                    b.Property<int>("LandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LandId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("LandId");

                    b.HasIndex("AccountId");

                    b.ToTable("Lands");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MonsterId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<int>("ActualHp")
                        .HasColumnType("integer");

                    b.Property<int>("CryptomonId")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.HasKey("MonsterId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CryptomonId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Planting", b =>
                {
                    b.Property<long>("PlantingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PlantingId"));

                    b.Property<int>("FruitId")
                        .HasColumnType("integer");

                    b.Property<int>("LandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PlantingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("Square")
                        .HasColumnType("integer");

                    b.HasKey("PlantingId");

                    b.HasIndex("LandId", "Square")
                        .IsUnique();

                    b.ToTable("Plantings");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Land", b =>
                {
                    b.HasOne("CryptomonServer.Orm.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Monster", b =>
                {
                    b.HasOne("CryptomonServer.Orm.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CryptomonServer.Orm.Cryptomon", "Cryptomon")
                        .WithMany()
                        .HasForeignKey("CryptomonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Cryptomon");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Planting", b =>
                {
                    b.HasOne("CryptomonServer.Orm.Land", "Land")
                        .WithMany("Plantings")
                        .HasForeignKey("LandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Land");
                });

            modelBuilder.Entity("CryptomonServer.Orm.Land", b =>
                {
                    b.Navigation("Plantings");
                });
#pragma warning restore 612, 618
        }
    }
}
