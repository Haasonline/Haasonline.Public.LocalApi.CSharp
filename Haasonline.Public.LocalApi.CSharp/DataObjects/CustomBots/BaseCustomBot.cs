using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class BaseCustomBot
    {
        public EnumCustomBotType BotType { get; set; }
        public bool IsBacktesting { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public Market PriceMarket { get; set; }
        public decimal Leverage { get; set; }

        public EnumCoinsPosition CoinPosition { get; set; }
        public EnumFundsPosition FundsPosition { get; set; }


        public decimal CurrentTradeAmount { get; set; }
        public decimal CorrectedTradeAmount { get; set; }

        public decimal LastBuyPrice { get; set; }
        public decimal LastSellPrice { get; set; }


        public decimal CurrentFeePercentage { get; set; } 
        public int SettlementDate { get; set; }
        public virtual string ProfitLabel { get; set; }
        public bool Activated { get; set; }
        public uint ActivatedSince { get; set; }
        public uint DeactivatedSince { get; set; }
        public bool StatusPriceSourceOk { get; set; }
        public bool StatusAccountOk { get; set; }
        public bool OpenOrdersOk { get; set; }
        public bool WalletOk { get; set; }

        public string OpenOrderId { get; set; }
        public decimal TotalFeeCosts { get; set; }
        public decimal TotalProfits { get; set; }
        public decimal ROI { get; set; }

        public decimal LastPriceUpdate { get; set; }
        public decimal ContractValue { get; set; }
        public long LastUpdateTime { get; set; }

        public string GroupName { get; set; }
        public string Notes { get; set; }

        public virtual string CustomTemplate { get; set; }

        public List<string> BotLogBook { get; set; }
        public List<BaseOrder> CompletedOrders { get; set; }
    }
}
