using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class ZoneRecoveryBot : BaseCustomBot
    {
        public decimal FactorShort { get; set; }
        public decimal FactorLong { get; set; }
        public decimal ZoneFactor { get; set; }
        public decimal TargetPercentage { get; set; }
        public decimal TradeAmount { get; set; }
        public decimal MaxTradeAmount { get; set; }

        public decimal TriggerLevel { get; set; }
        public bool UseMarketOrders { get; set; }
        public bool RoundAmount { get; set; }

        public decimal BasePrice { get; set; }
        public EnumFundsPosition FirstAction { get; set; }

        public List<ZoneDefinition> CalculatedZones { get; set; }
        public decimal TakeLongPrice { get; set; }
        public decimal GoLongPrice { get; set; }
        public decimal GoShortPrice { get; set; }
        public decimal TakeShortPrice { get; set; }
        public List<OpenRecoveryPositionDefinition> TakenPositions { get; set; }
    }
}