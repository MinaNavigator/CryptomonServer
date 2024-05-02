using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CryptomonServer.Orm
{


    // Store all game event and compile it at merkle tree to store it on mina blockchain
    public class Deposit
    {
        public int DepositId { get; set; }
        public int AccountId { get; set; }
        public ulong Amount { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Account Account { get; set; }

        public Deposit() { }

        public Deposit(int depositId, int accountId, ulong amount, DateTime addedDate)
        {
            DepositId = depositId;
            AccountId = accountId;
            Amount = amount;
            AddedDate = addedDate;
        }
    }
}
