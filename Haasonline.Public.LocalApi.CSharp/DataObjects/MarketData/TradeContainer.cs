using System;
using System.Collections.Generic;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData
{
    public class TradeContainer
    {
        public DateTime Timestamp { get; set; }
        public long UnixTimestamp { get; set; }

        public List<Trade> LastTrades { get; set; }
    }
}