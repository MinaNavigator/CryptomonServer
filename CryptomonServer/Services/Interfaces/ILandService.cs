using CryptomonServer.Dtos;

namespace CryptomonServer.Services.Interfaces
{
    public interface ILandService
    {
        Task<LandDto> GetLand(string address);
        Task<PlantingDto> AddPlant(PlantingDto plant);
        Task<PlantingDto> HarvestPlant(PlantingDto plant);
    }
}
