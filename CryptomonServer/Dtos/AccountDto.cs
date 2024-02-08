namespace CryptomonServer.Dtos
{

    public class AccountDto
    {
        public string Address { get; set; } // Unique account address (the Ethereum account)
        public string Username { get; set; } // The user name
        public string RecoveryEmail { get; set; } // The user Email
    }
}
