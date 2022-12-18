using CsvHelper.Configuration;

namespace Resampling;

public class BinanceTradeMap : ClassMap<BinanceTrade>
{
    public BinanceTradeMap()
    {
        Map(m => m.TradeId).Index(0);
        Map(m => m.Price).Index(1);
        Map(m => m.Quantity).Index(2);
        Map(m => m.QuoteQuantity).Index(3);
        Map(m => m.Time).Index(4).TypeConverter<TimestampConverter>();
        Map(m => m.IsBuyerMaker).Index(5);
        Map(m => m.IsBestMatch).Index(6);
    }
}