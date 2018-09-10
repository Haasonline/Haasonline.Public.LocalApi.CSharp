namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class AdvancedIndexBotIndex
    {
        public string Coin { get; set; }
        public decimal AllocatedPercentage { get; set; }
        public decimal LastCalculatedPercentage { get; set; }

        public decimal InVirtualWallet { get; set; }
        public decimal InRealWallet { get; set; }
        public decimal TargetAmount { get; set; }

        public decimal InVirtualWalletBase { get; set; }
        public decimal InRealWalletBase { get; set; }
        public decimal TargetAmountBase { get; set; }

        public decimal StartPrice { get; set; }
        public decimal LastUsedPrice { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal BuyThreshold { get; set; }
        public decimal BuyTarget { get; set; }

        public decimal SellThreshold { get; set; }
        public decimal SellTarget { get; set; }

        public decimal StopLoss { get; set; }
        public decimal StopLossPrice { get; set; }
        public bool IsStopLossActive { get; set; }

        public decimal TrailingStop { get; set; }
        public decimal TrailingStopPrice { get; set; }
        public decimal HighestRecordPrice { get; set; }
        public bool IsTrailingStopLossActive { get; set; }

        public bool IsExcluded { get; set; }

        public string OpenOrderId { get; set; }
        public bool HasOpenOrder { get; set; }
    }
}