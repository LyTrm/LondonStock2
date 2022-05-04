namespace LondonStock.Domain.Model
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Symbol { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
