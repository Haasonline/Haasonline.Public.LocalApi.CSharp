using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class FlashCrashBotSaveObject
    {
        public string BotName { get; set; }
        public string BotGuid { get; set; }
        public string AccountId { get; set; }
        public decimal Fee { get; set; }
        public Market PriceMarket { get; set; }

        public decimal BasePrice { get; set; }
        public EnumFlashSpreadOptions PriceSpreadType { get; set; }
        public decimal PriceSpread { get; set; }
        public decimal PercentageBoost { get; set; }
        public decimal MinPercentage { get; set; }
        public decimal MaxPercentage { get; set; }

        public EnumCurrencyType AmountType { get; set; }
        public decimal AmountSpread { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SellAmount { get; set; }
        public int RefillDelay { get; set; }

        public bool SafetyEnabled { get; set; }
        public decimal SafetyTriggerLevel { get; set; }
        public bool SafetyMoveInOut { get; set; }

        public bool FollowTheTrend { get; set; }
        public int FollowTheTrendChannelRange { get; set; }
        public int FollowTheTrendChannelOffset { get; set; }
        public int FollowTheTrendTimeout { get; set; }
    }
}