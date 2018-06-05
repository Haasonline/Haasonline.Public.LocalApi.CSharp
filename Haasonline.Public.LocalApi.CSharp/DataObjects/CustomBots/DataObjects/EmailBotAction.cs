using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class EmailBotAction
    {
        public string Guid { get; set; } = "";
        public string ProviderGuid { get; set; } = "";
        public List<EmailBotActionMessage> Messages { get; set; } = new List<EmailBotActionMessage>();

        public int TimeoutInSeconds { get; set; } = 65;

        public EnumBotTradeResult SpotAction { get; set; }
        public EnumFundsMovingPosition LeverageAction { get; set; }
    }
}