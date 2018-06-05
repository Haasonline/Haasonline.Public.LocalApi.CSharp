using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData
{
    public class Market
    {
        public EnumPriceSource PriceSource { get; set; }
        public string PrimaryCurrency { get; set; }
        public string SecondaryCurrency { get; set; }
        public string ContractName { get; set; }

        public string DisplayName { get; set; }
        public string ShortName { get; set; }

        public int AmountDecimals { get; set; }
        public int PriceDecimals { get; set; }
        public decimal MinimumTradeAmount { get; set; }
        public decimal MinimumTradeVolume { get; set; }

        public decimal TradeFee { get; set; }
        public int SettlementDate { get; set; }
    }
}