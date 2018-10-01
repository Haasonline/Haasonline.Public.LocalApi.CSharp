using System;
using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots
{
    public class AdvancedIndexBot : BaseCustomBot
    {
        public string BaseCoin { get; set; }
        public List<AdvancedIndexBotIndex> Index { get; set; }

        public decimal TotalExtraBuy { get; set; }
        public decimal TotalExtraSell { get; set; }

        public EnumAdvancedIndexBotRebalanceType RebalanceType { get; set; }
        public int RebalanceInterval { get; set; }
        public DateTime RebalanceTimestamp { get; set; }
        public long RebalanceUnix { get; set; }

        public bool AllocateProfits { get; set; } = false;
        public DateTime LastOrderTimestamp { get; set; } = DateTime.MinValue;
        public bool PreserveBaseIndexPercentage { get; set; }

        public Dictionary<string, decimal> MappendIndexes { get; set; }
        public Dictionary<string, AdvancedIndexBotIndex> IndexResult { get; set; } = new Dictionary<string, AdvancedIndexBotIndex>();
    }
}