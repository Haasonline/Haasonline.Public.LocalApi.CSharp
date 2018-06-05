using System;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData
{
    public class Trade
    {
        public DateTime Timestamp { get; set; }
        public long UnixTimestamp { get; set; }

        public EnumTradeType TradeType { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}