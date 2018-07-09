using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData
{
    public class SoftwareInformation
    {
        public bool IsBeta { get; set; }
        public string VersionNumber { get; set; }
        public EnumSoftwareLicence LicenceType { get; set; }
    }
}