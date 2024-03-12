using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CryptomonServer.Services
{
    public class LandService : ILandService
    {

        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<LandService> _logger;
        private readonly IMapper _mapper;
        private readonly CryptomonDbContext _dbContext;

        public LandService(ILogger<LandService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PlantingDto> AddPlant(PlantingDto plant)
        {
            throw new NotImplementedException();
        }

        public async Task<LandDto> GetLand(string address)
        {
            var land = _dbContext.Lands.Where(x => x.Account.Address == address).FirstOrDefault();
            if (land == null)
            {
                var account = _dbContext.Accounts.Where(x => x.Address == address).Single();
                land = new Land() { AccountId = account.AccountId, Level = 0 };
                _dbContext.Lands.Add(land);
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<LandDto>(land);
        }

        public async Task<PlantingDto> HarvestPlant(PlantingDto plant)
        {
            throw new NotImplementedException();
        }
    }
}
