using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CryptomonServer.Orm
{
    [Index(nameof(Address), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string? RecoveryMail { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Range(0.0, Double.MaxValue)]
        [Precision(32, 9)]
        public decimal CoinBalance { get; set; }
        [Range(0.0, Double.MaxValue)]
        [Precision(32, 9)]
        public decimal MinaBalance { get; set; }
    }
}