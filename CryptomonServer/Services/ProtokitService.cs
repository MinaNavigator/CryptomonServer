﻿using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CryptomonServer.Services
{
    public class ProtokitService : IProtokitService
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ProtokitService> _logger;
        private readonly IMapper _mapper;
        private readonly CryptomonDbContext _dbContext;

        public ProtokitService(ILogger<ProtokitService> logger, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task GetDeposits()
        {
            // todo read from protokit api deposit

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "url to define");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_config["ApiKey"]}");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var action = new GameAction() { ActionType = ActionType.DepositMina };
            

        }

        public async Task SaveActions()
        {
            var actions = await _dbContext.GameActions.Where(x => x.RegistrationDate == null).OrderBy(x => x.ActionId).ToListAsync();

            // todo send actions to protokit restapi

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "url to define");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_config["ApiKey"]}");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            //return false;
        }
    }
}
