using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CryptomonServer.Orm
{
    public class Fruit
    {
        public int FruitId { get; set; }
        public string Name { get; set; }
        // grow time in seconds
        public int GrowTime { get; set; }
        [Range(0.0, Double.MaxValue)]
        [Precision(32, 9)]
        public decimal SeedPrice { get; set; }
        [Range(0.0, Double.MaxValue)]
        [Precision(32, 9)]
        public decimal PlantPrice { get; set; }

        public int LevelMin { get; set; }

        public Fruit() { }

        public Fruit(int fruitId, string name, int growTime, decimal seedPrice, decimal plantPrice, int levelMin = 0)
        {
            FruitId = fruitId;
            Name = name;
            GrowTime = growTime;
            SeedPrice = seedPrice;
            PlantPrice = plantPrice;
            LevelMin = levelMin;
        }
    }
}
