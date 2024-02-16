namespace CryptomonServer.Dtos
{
    public class MonsterDto
    {
        public int MonsterId { get; set; }
        public int ActualHp { get; set; }
        public int Level { get; set; }

        public virtual CryptomonDto Cryptomon { get; set; }
    }
}
