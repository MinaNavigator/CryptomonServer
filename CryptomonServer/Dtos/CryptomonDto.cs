namespace CryptomonServer.Dtos
{
    [Flags]
    public enum CryptomonType
    {
        Nothing = 0,
        Fire = 1,
        Water = 2,
        Earth = 3,
        Wind = 4
    }

    public class CryptomonDto
    {
        public int CryptomonId { get; set; }
        public string Name { get; set; }
        public CryptomonType CryptomonType { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
    }
}
