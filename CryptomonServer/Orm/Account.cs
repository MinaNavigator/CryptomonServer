﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CryptomonServer.Orm
{
    [Index(nameof(Address), IsUnique = true)]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string? RecoveryMail { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}