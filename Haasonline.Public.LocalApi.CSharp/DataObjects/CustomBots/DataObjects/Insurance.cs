using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects
{
    public class Insurance
    {
        public string GUID { get; set; }
        public bool Enabled { get; set; }
        public EnumInsurances InsuranceType { get; set; }

        public string InsuranceTypeShortName { get; set; }
        public string InsuranceTypeFullName { get; set; }
        public bool AgreeToTrade { get; set; }
        public string InsuranceName { get; set; }
        public List<IndicatorOption> InsuranceInterface { get; set; }
    }
}