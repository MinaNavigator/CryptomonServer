using CryptomonServer.Dtos;
using CryptomonServer.Services.Interfaces;

namespace CryptomonServer.Services
{
    public class LandService : ILandService
    {
        public async Task<PlantingDto> AddPlant(PlantingDto plant)
        {
            throw new NotImplementedException();
        }

        public async Task<LandDto> GetLand(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<PlantingDto> HarvestPlant(PlantingDto plant)
        {
            throw new NotImplementedException();
        }
    }
}
