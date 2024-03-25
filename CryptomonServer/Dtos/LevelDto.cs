namespace CryptomonServer.Dtos
{
    public class LevelDto
    {
        public int Level { get; set; }
        public decimal Price { get; set; }

        public LevelDto() { }

        public LevelDto(int level, decimal price)
        {
            Price = price;
            Level = level;
        }
    }


}