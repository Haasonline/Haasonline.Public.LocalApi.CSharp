using System;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class MarketMarkingBotSlotObject
    {
        public string OrderID { get; set; } = "";
        public decimal Price { get; set; } = 0.0M;
        public decimal TempAmount { get; set; } = 0.0M;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool Locked { get; set; } = false;
    }
}