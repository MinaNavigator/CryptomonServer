﻿using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

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
            var land = _dbContext.Lands.Where(x => x.Account.Address == address).Single();
            var actualPlant = _dbContext.Plantings.Where(x => x.LandId == land.LandId && x.Square == plant.Square).FirstOrDefault();
            if (actualPlant?.FruitId > 0)
            {
                throw new Exception("Harvest before plant.");
            }

            // 5 square for level 0, and 3 square for each level
            if (plant.Square >= (5 + 3 * land.Level))
            {
                throw new Exception("Square didn't exist");
            }


            return _mapper.Map<PlantingDto>(actualPlant);
        }

        public async Task<LandDto> GetLand(string address)
        {
            var land = _dbContext.Lands.Where(x => x.Account.Address == address).FirstOrDefault();
            if (land == null)
            {
                // create a default land if user didn't have one
                var account = _dbContext.Accounts.Where(x => x.Address == address).Single();
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
            var land = _dbContext.Lands.Where(x => x.Account.Address == address).Single();
            var actualPlant = _dbContext.Plantings.Where(x => x.LandId == land.LandId && x.Square == plant.Square).FirstOrDefault();
            if (actualPlant?.FruitId == 0)
            {
                throw new Exception("Nothing to harvest.");
            }

            actualPlant.FruitId = 0;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PlantingDto>(actualPlant);
        }

        public async Task<LandDto> BuyLevel(string address)
        {
            var land = _dbContext.Lands.Where(x => x.Account.Address == address).Single();
            if (land.Level > 3)
            {
                throw new Exception("Already level max.");
            }
            var price = 2500m;
            switch (land.Level)
            {
                case 0:
                    price = 1;
                    break;
                case 1:
                    price = 50;
                    break;
                case 2:
                    price = 500;
                    break;
                default:
                    price = 2500;
                    break;
            }
            var account = _dbContext.Accounts.Where(x => x.Address == address).Single();
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
    }
}
