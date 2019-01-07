using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class MarketMarkingBot : BaseCustomBot
    {
        public PriceTick LastTick { get; set; }
        public List<MarketMakingBotSlot> Slots { get; set; } = new List<MarketMakingBotSlot>();
        public string StopLossTemplate { get; set; }
        public string Template { get; set; }
        public EnumFundsPosition LeverageStartSide { get; set; }

    }
}