using System;
using System.Collections.Generic;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class MarketMakingBotSlot
    {
        public string SlotGuid { get; set; } = Guid.NewGuid().ToString(); // UI!
        public MarketMakingBotSlotOrder BuyOrder { get; set; } = new MarketMakingBotSlotOrder();
        public MarketMakingBotSlotOrder SellOrder { get; set; } = new MarketMakingBotSlotOrder();
        public decimal Offset { get; set; }
        public decimal Amount { get; set; }
        public decimal StopLoss { get; set; }
        public bool StopLossHit { get; set; }

        public int Timeout { get; set; }
        public string ExecutionGuid { get; set; }
        public List<int> ExecutionTimes { get; set; } = new List<int>();
    }

    public class MarketMakingBotSlotOrder
    {
        private string _orderGuid = "";

        public string OrderGuid { get; set; }
        public List<string> OrderIds { get; set; } = new List<string>();

        public int ExecutionResetCounter { get; set; } = 0;
        public long ExecutionUnixTimestamp { get; set; }


        public decimal Price { get; set; } = 0M;
        public decimal TempAmount { get; set; } = 0M;
        public bool IsFinished { get; set; } = true;
        public bool WaitingForExecution { get; set; }
    }
}