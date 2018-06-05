using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;
using Newtonsoft.Json;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class Position
    {
        [JsonProperty("Position")]
        public EnumFundsPosition Side { get; set; }
        public decimal UsedMargin { get; set; }
        public decimal Amount { get; set; }
        public decimal Leverage { get; set; }
        public Market PriceMarket { get; set; }
        public decimal InvestmentPrice { get; set; }
        public decimal ProfitLossRatio { get; set; }
        public decimal ProfitLossNow { get; set; }
        public decimal MarginCallPrice { get; set; }
        public string AmountLabel { get; set; }
        public string ProfitLabel { get; set; }
    }
}