using CryptomonServer.Dtos;

namespace CryptomonServer.Services.Interfaces
{
    public interface IProtokitService
    {
        Task SaveActions();

        Task GetDeposits();
    }
}
