﻿using CryptomonServer.Dtos;
using CryptomonServer.Orm;

namespace CryptomonServer.Services.Interfaces
{
    public interface IMonsterService
    {
        Task<MonsterDto> AddMonster(int cryptomonId, int playerId);
        Task<MonsterDto> UpdateMonster(int monsterId, int hp, int exp);
        Task TransferMonster(int monsterId, string addressFrom, string addressTo);
        Task<MonsterDto> GetMonster(int monsterId);
        Task<List<MonsterDto>> GetMonsterForPlayer(string address);
    }
}
