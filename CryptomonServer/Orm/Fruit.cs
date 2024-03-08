namespace CryptomonServer.Orm
{
    public class Fruit
    {
        public int FruitId { get; set; }
        public string Name { get; set; }

        // grow time in seconds
        public int GrowTime { get; set; }
        public long SeedPrice { get; set; }
        public long PlantPrice { get; set; }
    }
}
