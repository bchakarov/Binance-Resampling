namespace Resampling;

public class BinanceTrade
{
    public long TradeId { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal QuoteQuantity { get; set; }
    public DateTime Time { get; set; }
    public bool IsBuyerMaker { get; set; }
    public bool IsBestMatch { get; set; }
}