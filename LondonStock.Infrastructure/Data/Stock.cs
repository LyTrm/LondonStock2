using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LondonStock.Infrastructure.Data
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StockId { get; set; }
        public string Symbol { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
