using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptomonServer.Orm
{
    public class FruitConfiguration : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> builder)
{
            //builder.HasData(new Fruit(1,"Wheat",120,0.02f,0.04f));

        }
    }
}
