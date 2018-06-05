using System;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData
{
    public class PriceTick
    {
        public DateTime Timestamp { get; set; }
        public long UnixTimestamp { get; set; }

        public decimal Open { get; set; }
        public decimal HighValue { get; set; }
        public decimal LowValue { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public decimal CurrentBuyValue { get; set; }
        public decimal CurrentSellValue { get; set; }
    }
}