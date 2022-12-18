using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Resampling;

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    HasHeaderRecord = false,
};

using var reader = new StreamReader("../../../ETHUSDT-trades-2022-12-16.csv");
using var csv = new CsvReader(reader, config);
csv.Context.RegisterClassMap<BinanceTradeMap>();

var source = csv.GetRecords<BinanceTrade>() ;

var period = TimeSpan.FromMinutes(240);

var ohlcv = source.OrderBy(p => p.Time)
    .Select(d => new
    {
        d.Time,
        d.Price,
        d.Quantity,
        Period = d.Time.Ticks / period.Ticks
    })
    .GroupBy(d => d.Period)
    .Select(g => new Ohlcv
    {
        Timestamp = g.Min(d => d.Time),
        Open = g.FirstOrDefault()?.Price ?? 0M,
        Close = g.LastOrDefault()?.Price ?? 0M,
        Low = g.Min(d => d.Price),
        High = g.Max(d => d.Price),
        Volume = g.Sum(d => d.Quantity)
    });

foreach (var item in ohlcv)
{
    Console.WriteLine(item);
}