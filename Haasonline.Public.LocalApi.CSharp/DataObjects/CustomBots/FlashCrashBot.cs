using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class FlashCrashBot : BaseCustomBot
    {
        public Dictionary<int, SlotObject> Slots { get; set; }
        public int BaseKey { get; set; }

        public decimal TotalBuyAmount { get; set; }
        public decimal TotalSellAmount { get; set; }

        public decimal BasePrice { get; set; }
        public bool IsStopping { get; set; }

        public EnumFlashSpreadOptions PriceSpreadType { get; set; }
        public decimal PriceSpread { get; set; }
        public decimal PercentageBoost { get; set; }

        public decimal AmountSpread { get; set; }
        public int AmountDecimals { get; set; }
        public int PriceDecimals { get; set; }

        public EnumCurrencyType AmountType { get; set; }
        public EnumFlashSpreadOptions AmountSpreadType { get; set; }
        public int RefillDelay { get; set; }

        public decimal MinPercentage { get; set; }
        public decimal MaxPercentage { get; set; }

        public bool QuickRestartPossible { get; set; }

        public bool FollowTheTrend { get; set; }
        public int FollowTheTrendTimeout { get; set; }
        public int FollowTheTrendChannelRange { get; set; }
        public int FollowTheTrendChannelOffset { get; set; }

        public bool SafetyEnabled { get; set; }
        public decimal SafetyTriggerLevel { get; set; }

        public bool SafetyMoveOutMarket { get; set; }
        public bool SafetyMoveInMarket { get; set; }
        public decimal SafetyMoveInOutTarget { get; set; }
    }
}