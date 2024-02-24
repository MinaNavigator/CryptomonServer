using CryptomonServer.Orm;

namespace CryptomonServer.Dtos
{
    public class GameActionDto
    {
        public int ActionId { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public long Amount { get; set; }
        public long ItemId { get; set; }
        public long PayoutId { get; set; }
        public ActionType ActionType { get; set; }
    }
}
