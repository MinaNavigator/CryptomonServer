using CryptomonServer.Dtos;
using CryptomonServer.Services;
using CryptomonServer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using MinaSignerNet;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace CryptomonServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonsterController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<MonsterController> _logger;
        private readonly IMonsterService _monsterService;
        private readonly ICryptomonService _cryptomonService;
        private readonly IAccountService _accountService;
        private const string message = "Welcome to the mina asp auth, sign this message to authenticate {0}";
        private const string cacheConnectionKey = "GetConnection_{0}";

        public MonsterController(ILogger<MonsterController> logger, IConfiguration config, IMemoryCache cache, IMonsterService monsterService, ICryptomonService cryptomonService, IAccountService accountService)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _accountService = accountService;
            _monsterService = monsterService;
            _cryptomonService = cryptomonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cryptomons = await _cryptomonService.GetAll();
            return Ok(cryptomons);
        }

        [HttpGet("GetByPlayer")]
        public async Task<IActionResult> GetByPlayer()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claimAccount = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Name);
            var address = claimAccount.Value;

            var monsters = await _monsterService.GetMonsterForPlayer(address);
            return Ok(monsters);
        }

        [HttpPost("TransferTo")]
        public async Task<IActionResult> TransferTo([FromBody] TransferDto transferData)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claimAccount = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Name);
            var address = claimAccount.Value;

            await _monsterService.TransferMonster(transferData.MonsterId, address, transferData.AddressTo);
            return Ok();
        }

    }
}
