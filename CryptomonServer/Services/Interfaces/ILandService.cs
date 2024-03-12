using CryptomonServer.Dtos;

namespace CryptomonServer.Services.Interfaces
{
    public interface ILandService
    {
        Task<LandDto> GetLand(string address);
        Task<PlantingDto> AddPlant(string address, PlantingDto plant);
        Task<PlantingDto> HarvestPlant(string address, PlantingDto plant);
    }
}
