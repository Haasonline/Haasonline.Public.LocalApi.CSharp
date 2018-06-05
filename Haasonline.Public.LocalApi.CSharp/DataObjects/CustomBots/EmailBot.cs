using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class EmailBot : BaseCustomBot
    {
        public List<EmailBotAction> Actions { get; set; }
        public decimal StopLoss { get; set; }
        public decimal StopLossPrice { get; set; }

        // On leverage this is the minimum profit
        public decimal PriceChangeToBuy { get; set; }

        // On leverage this is the stop loss
        public decimal PriceChangeToSell { get; set; }
        public decimal PriceChangeTarget { get; set; }

        public decimal MaximumLossOnPosition
        {
            get { return PriceChangeToBuy; }
            set { }
        }

        public decimal MinimumProfitOnPosition
        {
            get { return PriceChangeToBuy; }
            set { }
        }

    }
}