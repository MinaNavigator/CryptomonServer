namespace CryptomonServer.Orm
{
    public class Cryptomon
    {
        public int CryptomonId { get; set; }
        public string Name { get; set; }
        public int CryptomonType { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
    }
}
