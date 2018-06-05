namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class MarketMarkingBotSlot
    {
        public MarketMarkingBotSlotObject BuyOrder { get; set; }
        public MarketMarkingBotSlotObject SellOrder { get; set; }
        public decimal Offset { get; set; } = 0.0M;
        public bool Active { get; set; } = false;
    }
}