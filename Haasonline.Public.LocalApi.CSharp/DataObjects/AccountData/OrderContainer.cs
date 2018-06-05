using System.Collections.Generic;
using Newtonsoft.Json;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class OrderContainer
    {
        [JsonProperty("ExchangeOrderList")]
        public Dictionary<string, BaseOrder> SpotOrders { get; set; }

        [JsonProperty("MarginOrderList")]
        public Dictionary<string, BaseOrder> MarginOrders { get; set; }

        [JsonProperty("LeverageOrderList")]
        public Dictionary<string, BaseOrder> LeverageOrders { get; set; }
    }
}