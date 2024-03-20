using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptomonServer.Orm
{
    public class FruitConfiguration : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> builder)
        {
            builder.HasData(new Fruit(1, "Wheat", 120, 0.02m, 0.04m));
            builder.HasData(new Fruit(2, "Potato", 300, 0.10m, 0.16m));
            builder.HasData(new Fruit(3, "Pumpkin", 3600, 0.40m, 0.80m));
            builder.HasData(new Fruit(4, "Beetroot", 14400, 1m, 1.8m));
            builder.HasData(new Fruit(5, "Cauliflower", 28800, 4m, 8m));
            builder.HasData(new Fruit(6, "Parsnip", 86400, 10m, 16m));
            builder.HasData(new Fruit(7, "Radish", 259200, 50m, 80m));
        }
    }
}
