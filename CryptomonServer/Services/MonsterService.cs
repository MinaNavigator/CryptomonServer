using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly CryptomonDbContext _dbContext;

        public MonsterService(ILogger<MonsterService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MonsterDto> AddMonster(int cryptomonId, int playerId)
        {
            var cryptomon = await _dbContext.Cryptomons.SingleAsync(x => x.CryptomonId == cryptomonId);
            var monster = new Monster { CryptomonId = cryptomonId, ActualHp = cryptomon.Hp, Level = 1 };
            await _dbContext.AddAsync(monster);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<MonsterDto>(monster);
        }

        public async Task<MonsterDto> GetMonster(int monsterId)
        {
            var monster = await _dbContext.Monsters.SingleAsync(x => x.MonsterId == monsterId);
            return _mapper.Map<MonsterDto>(monster);
        }

        public async Task<List<MonsterDto>> GetMonsterForPlayer(string address)
        {
            var monster = await _dbContext.Monsters.Where(x => x.Account.Address == address).ToListAsync();
            return monster.Select(x => _mapper.Map<MonsterDto>(x)).ToList();
        }

        public async Task TransferMonster(int monsterId, string addressFrom, string addressTo)
        {
            var monster = await _dbContext.Monsters.Where(x=>x.Account.Address == addressFrom).SingleAsync(x => x.MonsterId == monsterId);
            var accountTo =await _dbContext.Accounts.SingleAsync(x=>x.Address == addressTo);
            monster.AccountId = accountTo.AccountId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MonsterDto> UpdateMonster(int monsterId, int hp, int exp)
        {
            var monster = await _dbContext.Monsters.SingleAsync(x => x.MonsterId == monsterId);
            monster.ActualHp = hp;
            monster.Experience = exp;
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<MonsterDto>(monster);
        }
    }
}
