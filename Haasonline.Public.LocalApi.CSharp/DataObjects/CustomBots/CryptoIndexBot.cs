using System;
using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class CryptoIndexBot : BaseCustomBot
    {
        public string BaseCoin { get; set; }
        public List<CryptoIndexBotIndex> Index { get; set; }

        public decimal TotalExtraBuy { get; set; }
        public decimal TotalExtraSell { get; set; }

        public bool IndividualCoinGrowth { get; set; } = false;
        public bool AllocateProfits { get; set; } = false;
        public DateTime LastOrderTimestamp { get; set; } = DateTime.MinValue;

        public Dictionary<string, decimal> MappendIndexes { get; set; }
        public Dictionary<string, CryptoIndexBotIndexResult> IndexResult { get; set; } = new Dictionary<string, CryptoIndexBotIndexResult>();
    }
}