using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class InterExchangeArbitrageBot : BaseCustomBot
    {
        public decimal CurrentFeePercentage2 { get; set; }
        public string AccountId2 { get; set; }

        public Market PriceMarket2 { get; set; }

        public decimal TriggerLevel { get; set; }
        public bool MainAccountIsBought { get; set; }

        public PriceTick LastTick { get; set; }
        public PriceTick LastTick2 { get; set; }

        public int PriceDecimals1 { get; set; }
        public int PriceDecimals2 { get; set; }

        public string OpenOrderIDMain { get; set; }
        public string OpenOrderIDSecondairy { get; set; }

        public decimal TotalTradesSoFar { get; set; }
        public decimal MaxTradeAmount { get; set; }
        public int MaxTradesPerDay { get; set; }
    }
}