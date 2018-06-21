using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class AccountInformation
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public EnumPlatformType PlatformType { get; set; }
        public EnumPriceSource ConnectedPriceSource { get; set; }

        public bool IsSimulatedAccount { get; set; }
        public Dictionary<string, string> AvailableOrderTemplates { get; set; }
    }
}