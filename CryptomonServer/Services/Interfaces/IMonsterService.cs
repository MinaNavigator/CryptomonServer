using CryptomonServer.Dtos;
using CryptomonServer.Orm;

namespace CryptomonServer.Services.Interfaces
{
    public interface IMonsterService
    {
        void AddMonster(int cryptomonId, int playerId);
        Task<MonsterDto> UpdateMonster(int monsterId, int hp, int exp);
        void TransferMonster(int monsterId, int toPlayerId);
        Task<MonsterDto> GetMonster(int monsterId);
        Task<List<MonsterDto>> GetMonsterForPlayer(int playerId);
    }
}
