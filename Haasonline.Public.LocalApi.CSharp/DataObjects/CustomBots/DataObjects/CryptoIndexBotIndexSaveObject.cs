namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class CryptoIndexBotIndexSaveObject
    {
        public string Coin { get; set; }
        public decimal Amount { get; set; }

        public decimal BuyThreshold { get; set; }
        public decimal SellThreshold { get; set; }
        public decimal StopLoss { get; set; }
    }
}