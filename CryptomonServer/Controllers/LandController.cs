﻿using CryptomonServer.Dtos;
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
        private readonly IProtokitService _protokitService;

        public LandController(ILogger<LandController> logger, IConfiguration config, IMemoryCache cache, IMonsterService monsterService, ICryptomonService cryptomonService, IAccountService accountService, ILandService landService, IProtokitService protokitService)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
            _accountService = accountService;
            _monsterService = monsterService;
            _landService = landService;
            _protokitService = protokitService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLand()
        {
            try
            {
                var land = await _landService.GetLand(GetAddress());
                return Ok(land);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetLand");
                return BadRequest(ex);
            }

        }

        [AllowAnonymous]
        [HttpGet("GetDeposits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDeposits()
        {
            try
            {
                await _protokitService.GetDeposits();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetDeposits");
                return BadRequest(ex);
            }

        }

        [HttpPost("AddPlant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPlant([FromBody] PlantingDto plan)
        {
            try
            {
                var land = await _landService.AddPlant(GetAddress(), plan);
                return Ok(land);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddPlant");
                return BadRequest(ex);
            }
        }

        [HttpPost("HarvestPlant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> HarvestPlant([FromBody] PlantingDto plan)
        {
            try
            {
                var land = await _landService.HarvestPlant(GetAddress(), plan);
                return Ok(land);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "HarvestPlant");
                return BadRequest(ex);
            }
        }

        [HttpPost("BuyLevel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuyLevel()
        {
            try
            {
                var land = await _landService.BuyLevel(GetAddress());
                return Ok(land);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "BuyLevel");
                return BadRequest(ex);
            }
        }

        [HttpGet("GetLevelPrice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetLevelPrice()
        {
            try
            {
                var land = _landService.GetLevelPrice();
                return Ok(land);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetLevelPrice");
                return BadRequest(ex);
            }
        }



        private string GetAddress()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claimAccount = claimsIdentity.FindFirst(JwtRegisteredClaimNames.Name);
            return claimAccount.Value;
        }
    }
}
