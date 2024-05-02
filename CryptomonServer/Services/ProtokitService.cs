using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;
using CryptomonServer.Services.Interfaces;
using GraphQL;
using GraphQL.Client.Abstractions;
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
        private readonly IGraphQLClient _client;

        public ProtokitService(ILogger<ProtokitService> logger, IGraphQLClient client, IConfiguration config, IMemoryCache cache, CryptomonDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _dbContext = dbContext;
            _mapper = mapper;
            _client = client;
        }

        public async Task GetDeposits()
        {
            var address = _config["ContractAddress"];
            var query = new GraphQLRequest
            {
                Query = @"
                    query EventQuery($contract: String!) {
                      events(input: {address: $contract}) {
                        eventData {
                          data
                        }
                      }
                    }",
                Variables = new { contract = address }
            };
            var response = await _client.SendQueryAsync<DepositEvents>(query);

            var eventData = response.Data.Events.SelectMany(x => x.EventData).ToList();

            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                foreach (var data in eventData)
                {
                    // todo group by account
                    var account = _dbContext.Accounts.Where(x => EF.Functions.ILike(x.Address, data.Account)).FirstOrDefault();
                    if (account != null)
                    {
                        bool alreadyExist = _dbContext.Deposits.Any(x => x.DepositId == data.Index);
                        if (!alreadyExist)
                        {
                            var newDeposit = new Deposit(data.Index, account.AccountId, data.Amount, DateTime.UtcNow);

                            var amountGame = data.AmountDecimal * 2;
                            account.CoinBalance += amountGame;
                            _dbContext.Deposits.Add(newDeposit);

                            await _dbContext.SaveChangesAsync();
                        }
                    }
                }
                await transaction.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }



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
