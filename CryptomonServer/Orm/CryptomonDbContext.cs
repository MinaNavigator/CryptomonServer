using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace CryptomonServer.Orm
{
    public class CryptomonDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public CryptomonDbContext(DbContextOptions options)
    : base(options)
        {
        }

    }
}
