using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class IntelliAliceBot : BaseCustomBot
    {
        public EnumLeverageStopLossType SafetyType { get; set; }
        public decimal StopLoss { get; set; }
        public decimal TakeProfit { get; set; }
    }
}