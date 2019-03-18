using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class Indicator
    {
        public string GUID { get; set; }
        public bool Enabled { get; set; }
        public EnumIndicator IndicatorType { get; set; }

        public string IndicatorName { get; set; }
        public List<IndicatorOption> IndicatorInterface { get; set; }

        public string IndicatorTypeShortName { get; set; }
        public string IndicatorTypeFullName { get; set; }

        public Market PriceMarket { get; set; }
        public EnumPriceChartType ChartType { get; set; }
        public int Timer { get; set; }
        public int Deviation { get; set; }
        public int Weight { get; set; }


        public bool UseBuySignals { get; set; }
        public bool UseSellSignals { get; set; }
        public bool UseLongSignals { get; set; }
        public bool UseNoPositionSignals { get; set; }
        public bool UseShortSignals { get; set; }

        public virtual bool ReverseSignals { get; set; }

        public EnumBotTradeResult BuySellResult { get; set; }
        public EnumFundsPosition ShortLongResult { get; set; }

        public EnumFundsPosition MappedLongSignal { get; set; }
        public EnumFundsPosition MappedShortSignal { get; set; }
    }
}