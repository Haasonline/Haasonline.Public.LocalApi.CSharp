namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class CryptoIndexBotIndex
    {
        public string Coin { get; set; }
        public decimal Amount { get; set; }

        public decimal StartPrice { get; set; }
        public decimal ConversionRate { get; set; }

        public decimal BuyThreshold { get; set; }
        public decimal SellThreshold { get; set; }

        public bool NeedsRebalancing { get; set; }
        public bool HasOpenOrder { get; set; }

        public bool IsStopLossActive { get; set; }
        public decimal StopLoss { get; set; }
    }
}