using System;
using System.Collections.Generic;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData
{
    public class Orderbook
    {
        public DateTime Timestamp { get; set; }
        public long UnixLastUpdate { get; set; }

        public Market PriceMarket { get; set; }
        public List<OrderbookRecord> Bid { get; set; }
        public List<OrderbookRecord> Ask { get; set; }
    }
}