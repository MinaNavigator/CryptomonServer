using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CryptomonServer.Orm
{
    [Index(nameof(LandId), nameof(Square), IsUnique = true)]
    public class Planting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlantingId { get; set; }
        public int LandId { get; set; }
        public int Square { get; set; }
        public int FruitId { get; set; }
        public DateTime PlantingDate { get; set; }
        public virtual Land Land { get; set; }

    }
}
