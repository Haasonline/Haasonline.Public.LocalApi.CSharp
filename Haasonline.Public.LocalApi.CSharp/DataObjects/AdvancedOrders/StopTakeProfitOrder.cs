namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AdvancedOrders
{
    public class StopTakeProfitOrder : AdvancedOrderBase
    {
        /// <summary>
        /// When this price is breached, a order will be executed
        /// </summary>
        public decimal TriggerPrice { get; set; }

        /// <summary>
        /// When a order is executed, this price will be used.
        /// </summary>
        public decimal ExecutionPrice { get; set; }
    }
}