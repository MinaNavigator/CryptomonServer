using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace CryptomonServer.Orm
{

    public enum ActionType
    {
        None = 0,
        Mint = 1,
        Transfer = 2,
        Burn = 3,
        Deposit = 4,
        Withdraw = 5
    }

    // Store all game event and compile it at merkle tree to store it on mina blockchain
    public class GameAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActionId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public long Amount { get; set; }
        public long ItemId { get; set; }
        public long PayoutId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
