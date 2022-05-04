using LondonStock.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LondonStock.Domain.Enums;

namespace LondonStock.Infrastructure.Repositories
{
    public class Trade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TradeId { get; set; }
        public string TradeReference { get; set; } = null!;
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;
        public int BrokerId { get; set; }
        public DateTime TradeDate { get; set; }
        public decimal Quantity { get; set; }
        public Direction Direction { get; set; }
    }
}
