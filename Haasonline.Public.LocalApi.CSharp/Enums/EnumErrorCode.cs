namespace Haasonline.LocalApi.CSharp.Enums
{
    public enum EnumErrorCode
    {
        Success = 100,

        InvalidRequest = 1001,
        InvalidSignature = 1002,
        InvalidBotGuid = 1003,
        InvalidBotElementGuid = 1004,
        InvalidAccountGuid = 1005,
        InvalidMarket = 1006,
        InvalidEnum = 1007,
        InvalidParameter = 1008,

        PriceSourceNotActive = 1020,
        PriceMarketIsSyncing = 1021,
        MissingParameter = 1022,

        UnkownError = 2000,
    }
}