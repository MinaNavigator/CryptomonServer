using CryptomonServer.Dtos;

namespace CryptomonServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(AccountDto newAccount);
        Task<AccountDto> GetAccount(string Address);
    }
}
