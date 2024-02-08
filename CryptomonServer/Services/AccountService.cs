using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CryptomonServer.Services
{
    public class AccountService : IAccountService
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AccountService> _logger;
        private readonly CryptomonDbContext _dbContext;

        public AccountService(ILogger<AccountService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
        }

        public async Task Register(AccountDto newAccount)
        {
            Account entity = new Account();
            entity.Address = newAccount.Address;
            entity.RecoveryMail = newAccount.RecoveryEmail;
            entity.RegistrationDate = DateTime.Now.ToUniversalTime();
            entity.Username = newAccount.Username;

            _dbContext.Accounts.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AccountDto> GetAccount(string address)
        {
            var entity = await _dbContext.Accounts.Where(x => x.Address == address).FirstOrDefaultAsync();
            return entity != null ?
                new AccountDto() { Address = entity.Address, RecoveryEmail = entity.RecoveryMail }
                : new AccountDto();
        }
    }
}
