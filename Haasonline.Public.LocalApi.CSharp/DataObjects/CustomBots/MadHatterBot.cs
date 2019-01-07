using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class MadHatterBot : BaseCustomBot
    {
        public int Interval { get; set; }

        public EnumLeverageStopLossType StopLossType { get; set; }
        public decimal StopLoss { get; set; }
        public decimal StopLossPrice { get; set; }
        public bool DisableAfterStopLoss { get; set; }

        public decimal PriceChangeToBuy { get; set; }
        public decimal PriceChangeToSell { get; set; }
        public decimal PriceChangeTarget { get; set; }

        public Indicator Macd { get; set; }
        public Indicator BBands { get; set; }
        public Indicator Rsi { get; set; }
        public bool UseTwoSignals { get; set; }

        public EnumFundsPosition MappedBuySignal { get; set; }
        public EnumFundsPosition MappedSellSignal { get; set; }
    }
}