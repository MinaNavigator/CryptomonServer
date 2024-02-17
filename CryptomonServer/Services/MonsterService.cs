using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CryptomonServer.Services
{
    public class MonsterService : IMonsterService
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<MonsterService> _logger;
        private readonly CryptomonDbContext _dbContext;

        public MonsterService(ILogger<MonsterService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
        }

        public async Task<MonsterDto> AddMonster(int cryptomonId, int playerId)
        {
            var cryptomon = await _dbContext.Cryptomons.SingleAsync(x => x.CryptomonId == cryptomonId);
            var monster = new Monster { CryptomonId = cryptomonId, ActualHp = cryptomon.Hp, Level = 1 };
            await _dbContext.AddAsync(monster);
            await _dbContext.SaveChangesAsync();
            return new MonsterDto();
        }

        public async Task<MonsterDto> GetMonster(int monsterId)
        {
            var monster = await _dbContext.Monsters.SingleAsync(x => x.MonsterId == monsterId);
            return new MonsterDto();
        }

        public async Task<List<MonsterDto>> GetMonsterForPlayer(int playerId)
        {
            var monster = await _dbContext.Monsters.Where(x => x.AccountId == playerId).ToListAsync();
            return new List<MonsterDto>();
        }

        public Task TransferMonster(int monsterId, int toPlayerId)
        {
            throw new NotImplementedException();
        }

        public Task<MonsterDto> UpdateMonster(int monsterId, int hp, int exp)
        {
            throw new NotImplementedException();
        }
    }
}
