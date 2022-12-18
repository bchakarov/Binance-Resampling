using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Resampling;

public class TimestampConverter : DefaultTypeConverter
{
    private static readonly DateTime Epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData) => Epoch.AddTicks((long)Math.Round(double.Parse(text!) * TimeSpan.TicksPerMillisecond));
}