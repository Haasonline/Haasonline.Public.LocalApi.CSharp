using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AdvancedOrders
{
    public class AdvancedOrderBase
    {
        public EnumPlatform PlatformType { get; set; }

        public string Guid { get; set; }
        public string Name { get; set; }
        public bool Activated { get; set; }

        public string AccountGuid { get; set; } = "";
        public Market Market { get; set; } = new Market();
        public decimal Leverage { get; set; }

        public decimal Amount { get; set; }
        public decimal CorrectedAmount { get; set; }
        
        public int OrderDirection { get; set; }

        public bool StartOrderOnActivation { get; set; }
        public decimal StartOrderPrice { get; set; }
        public string StartTemplateGuid { get; set; }

        public bool IsPlacingStartOrder { get; set; }
        public bool IsTracking { get; set; }

        public virtual string TemplateGuid { get; set; }

        public List<BaseOrder> CompletedOrders { get; set; }
    }
}