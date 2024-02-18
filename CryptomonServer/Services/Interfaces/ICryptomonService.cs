using CryptomonServer.Dtos;
using CryptomonServer.Orm;

namespace CryptomonServer.Services.Interfaces
{
    public interface ICryptomonService
    {
        Task<List<CryptomonDto>> GetAll();
    }
}
