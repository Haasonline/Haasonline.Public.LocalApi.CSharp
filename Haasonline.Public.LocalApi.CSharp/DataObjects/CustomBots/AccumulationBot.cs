using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class AccumulationBot : BaseCustomBot
    {
        public int AmountDecimals { get; set; }
        public int PriceDecimals { get; set; }

        public long NextOrderTime { get; set; }

        public EnumOrderType OrderType { get; set; } = EnumOrderType.Buy;
        public decimal AccumulatedSoFar { get; set; }

        public EnumAccumulationBotStopType StopType { get; set; } = EnumAccumulationBotStopType.MaxTotalAmount;
        public decimal StopTypeValue { get; set; } = 0.0M;

        public int RandomOrderTimeX { get; set; } = 1;
        public int RandomOrderTimeY { get; set; } = 60;

        public decimal RandomOrderSizeX { get; set; } = 1;
        public decimal RandomOrderSizeY { get; set; } = 60;

        public bool TriggerOnPrice { get; set; }
        public bool TriggerWhenHigher { get; set; }
        public decimal TriggerValue { get; set; }
    }
}