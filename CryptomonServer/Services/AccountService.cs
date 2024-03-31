using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountService(ILogger<AccountService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
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
            var entity = await _dbContext.Accounts.Where(x => EF.Functions.ILike(x.Address, address)).FirstOrDefaultAsync();
            if (entity != null)
            {
                return _mapper.Map<AccountDto>(entity);
            }
            return new AccountDto();
        }
    }
}
