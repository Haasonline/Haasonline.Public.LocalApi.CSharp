using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class OrderBotPreOrder : BaseOrder
    {
        public EnumOrderBotTriggerType Trigger { get; set; }
        public decimal TriggerPrice { get; set; }
        public string CustomTemplate { get; set; }
        public string DependsOn { get; set; } = "";
        public string DependsOnNotExecuted { get; set; } = "";
    }
}