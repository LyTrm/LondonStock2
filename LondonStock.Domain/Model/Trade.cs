using static LondonStock.Domain.Enums;

namespace LondonStock.Domain.Model
{
    public class Trade
    {
        public int TradeId { get; set; }
        public string TradeReference { get; set; } = null!;
        public int StockId { get; set; }
        public int BrokerId { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal Quantity { get; set; }
        public Stock Stock { get; set; } = null!;

        public Direction Direction { get; set; }
    }
}
