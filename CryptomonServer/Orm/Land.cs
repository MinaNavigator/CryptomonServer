using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CryptomonServer.Orm
{
    public class Land
    {
        public int LandId { get; set; }
        public int AccountId { get; set; }
        public int Level { get; set; }

        public virtual Account Account { get; set; }
        public virtual List<Planting> Plantings { get; set; }
    }
}
