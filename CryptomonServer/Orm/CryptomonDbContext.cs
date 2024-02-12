using Microsoft.EntityFrameworkCore;
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

        public CryptomonDbContext(DbContextOptions options)
    : base(options)
        {
        }

    }
}
