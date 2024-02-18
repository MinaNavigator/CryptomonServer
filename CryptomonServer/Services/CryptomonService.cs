using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CryptomonServer.Services
{
    public class CryptomonService : ICryptomonService
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<CryptomonService> _logger;
        private readonly IMapper _mapper;
        private readonly CryptomonDbContext _dbContext;

        public CryptomonService(ILogger<CryptomonService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CryptomonDto>> GetAll()
        {
            var monster = await _dbContext.Cryptomons.ToArrayAsync();
            return monster.Select(x => _mapper.Map<CryptomonDto>(x)).ToList();
        }
    }
}
