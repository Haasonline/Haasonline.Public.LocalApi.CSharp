using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.TradeBot
{
    public class TradeBot
    {
        public EnumBotType BotType { get; set; }
        public string GUID { get; set; } = "";

        public string Name { get; set; } = "";
        public string AccountId { get; set; } = "";

        public bool Activated { get; set; }
        public decimal CurrentTradeAmount { get; set; }
        public decimal CurrentFeePercentage { get; set; }

        public EnumCoinsPosition CoinsPosition { get; set; }
        public EnumFundsPosition FundsPosition { get; set; }

        public decimal LastBuyPrice { get; set; }
        public decimal LastSellPrice { get; set; }

        public decimal LastLongPrice { get; set; }
        public decimal LastShortPrice { get; set; }

        public bool AdjustAmountDown { get; set; }
        public EnumLimitOrderPriceType LimitOrderType { get; set; }

        public int OpenOrderTimeout { get; set; }
        public int TemplateTimeout { get; set; }
        public bool GoAllIn { get; set; }

        public List<string> IssuedOrders { get; set; }
        public List<BaseOrder> CompletedOrders { get; set; }

        public decimal ROI { get; set; } = 0.0M; 
        public decimal TotalFeeCosts { get; set; } = 0.0M;
        public decimal TotalProfits { get; set; } = 0.0M;

        public decimal LastPriceUpdate { get; set; }
        public decimal ContractValue { get; set; }
        public string GroupName { get; set; }

        public int BuyWeight { get; set; }
        public int SellWeight { get; set; }
        public int LongWeight { get; set; }
        public int ShortWeight { get; set; }
        public int ExitWeight { get; set; }

        public TradeBotSignals BotSignals { get; set; } 

        public List<string> BotLogBook { get; set; }

        public Market PriceMarket { get; set; }
        public decimal Leverage { get; set; }

        public int UnixSettlementDate { get; set; }

        public bool HighFrequencyUpdates { get; set; }
        public bool UseHiddenOrders { get; set; }

        public string BuyOrderTemplateId { get; set; }
        public string SellOrderTemplateId { get; set; }

        public string EnterPositionOrderTemplateId { get; set; }
        public string ExitPositionOrderTemplateId { get; set; }

        public string ProfitLabel { get; set; }

        public string Notes { get; set; }
        public bool Locked { get; set; }
        public uint ActivatedSince { get; set; }
        public uint DeactivatedSince { get; set; }
        public bool ConsensusMode { get; set; }

        public Dictionary<string, Safety> Safeties { get; set; }
        public Dictionary<string, Indicator> Indicators { get; set; }
        public Dictionary<string, Insurance> Insurances { get; set; }
    }
}