namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class ZoneDefinition
    {
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TargetPrice { get; set; }

        public decimal ExposureNow { get; set; }
        public decimal TakenProfit { get; set; } 
        public decimal TakenLosses { get; set; } 
        public decimal Exit { get; set; } 
        public decimal FeeCosts { get; set; }
    }
}