using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PlantingDto> AddPlant(string address, PlantingDto plant)
        {
            var land = _dbContext.Lands.Where(x => EF.Functions.ILike(x.Account.Address, address)).Include(x => x.Account).Single();
            var actualPlant = _dbContext.Plantings.Where(x => x.LandId == land.LandId && x.Square == plant.Square).FirstOrDefault();
            if (actualPlant?.FruitId > 0)
            {
                throw new Exception("Harvest before plant.");
            }

            var fruit = _dbContext.Fruits.Where(x => x.FruitId == plant.FruitId).Single();
            if (fruit.LevelMin > land.Level)
            {
                throw new Exception("Seed not unlocked");
            }

            // 5 square for level 0, and 3 square for each level
            if (plant.Square >= (5 + 3 * land.Level))
            {
                throw new Exception("Square didn't exist");
            }

            // remove seed price to account balance
            land.Account.CoinBalance -= fruit.SeedPrice;
            if (actualPlant != null)
            {
                actualPlant.Fruit = fruit;
                actualPlant.PlantingDate = DateTime.UtcNow;
            }
            else
            {
                actualPlant = _mapper.Map<Planting>(plant);
                actualPlant.PlantingDate = DateTime.UtcNow;
                land.Plantings.Add(actualPlant);
            }

            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<PlantingDto>(actualPlant);
            result.CoinBalance = land.Account.CoinBalance;
            return result;
        }

        public async Task<LandDto> GetLand(string address)
        {
            var land = _dbContext.Lands.Where(x => EF.Functions.ILike(x.Account.Address, address)).Include(x => x.Plantings).FirstOrDefault();
            if (land == null)
            {
                // create a default land if user didn't have one
                var account = _dbContext.Accounts.Where(x => EF.Functions.ILike(x.Address, address)).Single();
                land = new Land() { AccountId = account.AccountId, Level = 0 };
                _dbContext.Lands.Add(land);
                // first plantation offers
                Planting plant = new Planting() { FruitId = 1, Square = 0 };
                Planting plant2 = new Planting() { FruitId = 1, Square = 1 };
                Planting plant3 = new Planting() { FruitId = 1, Square = 2 };
                land.Plantings.Add(plant);
                land.Plantings.Add(plant2);
                land.Plantings.Add(plant3);
                await _dbContext.SaveChangesAsync();
            }

            return _mapper.Map<LandDto>(land);
        }

        public async Task<PlantingDto> HarvestPlant(string address, PlantingDto plant)
        {
            var land = _dbContext.Lands.Where(x => EF.Functions.ILike(x.Account.Address, address)).Include(x => x.Account).Single();
            var actualPlant = _dbContext.Plantings.Where(x => x.LandId == land.LandId && x.Square == plant.Square).Include(x => x.Fruit).FirstOrDefault();
            if (actualPlant?.FruitId == 0)
            {
                throw new Exception("Nothing to harvest.");
            }

            // add plant price to account balance
            land.Account.CoinBalance += actualPlant.Fruit.PlantPrice;

            actualPlant.FruitId = 0;

            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<PlantingDto>(actualPlant);
            result.CoinBalance = land.Account.CoinBalance;
            return result;
        }

        public async Task<LandDto> BuyLevel(string address)
        {
            var land = _dbContext.Lands.Where(x => EF.Functions.ILike(x.Account.Address, address)).Single();
            if (land.Level > 3)
            {
                throw new Exception("Already level max.");
            }
            var nextLevel = GetLevelPrice().Where(x => x.Level == land.Level + 1).First();
            var price = nextLevel.Price;
            var account = _dbContext.Accounts.Where(x => EF.Functions.ILike(x.Address, address)).Single();
            if (account.CoinBalance >= price)
            {
                land.Level++;
                account.CoinBalance -= price;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Insufficient amount.");
            }
            return _mapper.Map<LandDto>(land);
        }

        public List<LevelDto> GetLevelPrice()
        {
            var level1 = new LevelDto(1, 1);
            var level2 = new LevelDto(2, 50);
            var level3 = new LevelDto(3, 500);
            var level4 = new LevelDto(4, 2500);
            return new List<LevelDto>() { level1, level2, level3, level4 };
        }
    }
}
