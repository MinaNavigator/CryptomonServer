﻿// <auto-generated />
using System;
using CryptomonServer.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CryptomonServer.Migrations
{
    [DbContext(typeof(CryptomonDbContext))]
    [Migration("20240309171906_Balance")]
    partial class Balance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("CoinBalance")
                        .HasColumnType("bigint");

                    b.Property<long>("MinaBalance")
                        .HasColumnType("bigint");

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

                    b.Property<long>("PlantPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("SeedPrice")
                        .HasColumnType("bigint");

                    b.HasKey("FruitId");

                    b.ToTable("Fruits");
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
                        .HasColumnType("timestamp with time zone");

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
                        .WithMany()
                        .HasForeignKey("LandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Land");
                });
#pragma warning restore 612, 618
        }
    }
}
