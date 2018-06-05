using System;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.TradeBot
{
    public class TradeBotSignals
    {
        public bool PriceSourceConnected { get; set; }

        public bool AccountConnected { get; set; } 
        public bool TradeAmountOk { get; set; }
        public bool OpenOrdersOk { get; set; }
        public bool InBenchmark { get; set; }
        public bool IsSafetySignalNow { get; set; }

        public decimal MaxLongAmount { get; set; } 
        public decimal MaxNoPositionAmount { get; set; }
        public decimal MaxShortAmount { get; set; }

        public decimal MaxBuyAmount { get; set; } 
        public decimal MaxSellAmount { get; set; } 

        public int BotBuySellSignal = 50;  
        public int BotLongShortSignal = 50; 

        public DateTime LastPollMoment { get; set; } 
        public int UnixLastPollMoment { get; set; }

        public EnumBotTradeResult BuySellResult { get; set; } 
        public EnumFundsPosition LongShortResult { get; set; }
    }
}