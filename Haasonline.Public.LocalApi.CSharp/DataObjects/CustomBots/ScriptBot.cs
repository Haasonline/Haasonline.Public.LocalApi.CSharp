using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class ScriptBot : BaseCustomBot
    {
        public Dictionary<string, ScriptBotOrder> OpenOrders { get; set; }

        public List<string> FinishedOrders { get; set; }
        public List<string> CancelledOrders { get; set; }
        public Dictionary<string, string> AvailableScript { get; set; }

        public string ScriptId { get; set; }
        public string FullScriptName { get; set; }

        public List<IndicatorOption> BotSettings { get; set; }
        public bool ScriptStatusOk { get; set; }
        public string LocalScriptPath { get; set; }

        public decimal LastLongBuyPrice { get; set; }
        public decimal LastShortBuyPrice { get; set; }
        public decimal LastLongSellPrice { get; set; }
        public decimal LastShortSellPrice { get; set; }
    }
}