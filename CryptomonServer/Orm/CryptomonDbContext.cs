﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace CryptomonServer.Orm
{
    public class CryptomonDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<GameAction> GameActions { get; set; }
        public DbSet<Cryptomon> Cryptomons { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Planting> Plantings { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        public CryptomonDbContext(DbContextOptions options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FruitConfiguration());

            modelBuilder.Entity<Planting>().Property(e => e.PlantingDate).HasDefaultValueSql("NOW()");
        }

    }
}
