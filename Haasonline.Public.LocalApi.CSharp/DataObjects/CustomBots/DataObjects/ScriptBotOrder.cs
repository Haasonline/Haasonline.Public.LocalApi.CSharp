using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class ScriptBotOrder
    {
        public string Guid { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public EnumOrderType OrderType { get; set; }
        public EnumFundsMovingPosition FundsMovement { get; set; }
    }
}