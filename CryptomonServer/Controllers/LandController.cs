using CryptomonServer.Dtos;
using CryptomonServer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CryptomonServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LandController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<LandController> _logger;
        private readonly IMonsterService _monsterService;
        private readonly ICryptomonService _cryptomonService;
        private readonly IAccountService _accountService;
        private readonly ILandService _landService;

        public LandController(ILogger<LandController> logger, IConfiguration config, IMemoryCache cache, IMonsterService monsterService, ICryptomonService cryptomonService, IAccountService accountService, ILandService landService)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _accountService = accountService;
            _monsterService = monsterService;
            _landService = landService;

        }

        [HttpGet()]
        public async Task<IActionResult> GetLand()
        {
            var land = await _landService.GetLand(GetAddress());
            return Ok(land);
        }

        [HttpPost("AddPlant")]
        public async Task<IActionResult> AddPlant([FromBody]PlantingDto plan)
        {
            var land = await _landService.AddPlant(GetAddress(),plan);
            return Ok(land);
        }

        [HttpPost("HarvestPlant")]
        public async Task<IActionResult> HarvestPlant([FromBody] PlantingDto plan)
        {
            var land = await _landService.HarvestPlant(GetAddress(), plan);
            return Ok(land);
        }


        private string GetAddress()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claimAccount = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Name);
            return claimAccount.Value;
        }
    }
}
