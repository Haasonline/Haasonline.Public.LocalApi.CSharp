using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class OrderBot : BaseCustomBot
    {
        public List<OrderBotPreOrder> PreOrders { get; set; }
    }
}