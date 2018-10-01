using System;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class BaseOrder
    {
        public OrderPair Pair { get; set; }
        public string OrderId { get; set; }
        public EnumOrderStatus OrderStatus { get; set; }

        public EnumOrderType OrderType { get; set; }
        public EnumFundsMovingPosition FundsMovement { get; set; }

        public decimal Price { get; set; } = 0.0M;
        public decimal Amount { get; set; } = 0.0M;
        public decimal AmountFilled { get; set; } = 0.0M;

        public DateTime AddedTime { get; set; } 
        public int UnixAddedTime { get; set; }
    }
}