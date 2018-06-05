namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class CryptoIndexBotIndexResult
    {
        public string Coin { get; set; } = "";
        public decimal InWallet { get; set; } = 0M;
        public decimal IndexValue { get; set; } = 0M;

        public bool Deactivated { get; set; } = false;
        public decimal TargetPercentage { get; set; }
        public decimal CurrentPercentage { get; set; }
    }
}