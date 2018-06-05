using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class Safety
    {
        public string GUID { get; set; }
        public EnumSafety SafetyType { get; set; }

        public string SafetyName { get; set; }
        public string SafetyTypeShortName { get; set; }
        public string SafetyTypeFullName { get; set; }

        public Market PriceMarket { get; set; }

        public EnumBotTradeResult BuySellResult { get; set; }
        public EnumFundsPosition ShortLongResult { get; set; }

        public EnumFundsPosition MapBuySignal { get; set; }
        public EnumFundsPosition MapSellSignal { get; set; }

        public List<IndicatorOption> SafetyInterface { get; set; }
    }
}