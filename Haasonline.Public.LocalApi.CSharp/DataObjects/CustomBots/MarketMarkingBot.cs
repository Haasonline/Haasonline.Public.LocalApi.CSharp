using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class MarketMarkingBot : BaseCustomBot
    {
        public decimal TradeAmount { get; set; }
        public decimal CustomFee { get; set; }

        public MarketMarkingBotSlot FirstOrder { get; set; }
        public MarketMarkingBotSlot SecondOrder { get; set; }

        public decimal FirstOffset { get; set; }
        public decimal SecondOffset { get; set; }

        public bool UseSecondOrder { get; set; }
        public int ResetTimeout { get; set; }

        public PriceTick LastTick { get; set; }
    }
}