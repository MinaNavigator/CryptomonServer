namespace CryptomonServer.Orm
{
    public class Monster
    {
        public int MonsterId { get; set; }
        public int AccountId { get; set; }
        public int CryptomonId { get; set; }
        public int ActualHp { get; set; }
        public int Level { get; set; }

        public virtual Cryptomon Cryptomon { get; set; }
        public virtual Account Account { get; set; }
    }
}
