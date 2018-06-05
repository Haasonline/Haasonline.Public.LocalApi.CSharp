namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class ScalperBot : BaseCustomBot
    {
        public decimal MinimumTargetChange { get; set; }
        public decimal MaxAllowedReverseChange { get; set; }
    }
}