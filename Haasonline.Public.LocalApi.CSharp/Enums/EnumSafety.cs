namespace Haasonline.Public.LocalApi.CSharp.Enums
{
    public enum EnumSafety
    {
        /* A */
        /* B */
        /* C */
        //CandelierExit,
        CloseBeforeSettlement = 0,
        ClosePositionWithLoss = 14,
        ClosePositionWithProfit = 15,
        /* D */
        DeactivateBotAfterBuy = 12,
        DeactivateBotAfterSell = 13,
        DeavtivateBotAfterXTrades = 18,
        DeactiveBotAfterXIdleMinutes = 21,
        DeactiveBotAfterXActiveMinutes = 22,
        ToT = 20,

        /* E */
        /* F */
        ForceToBoughtLong = 7,
        ForceToSoldShort = 8,
        /* G */
        /* H */
        /* I */
        /* J */
        /* K */
        /* L */
        /* M */
        /* N */
        /* O */
        /* P */
        PricePump = 16,
        PriceDump = 17,
        /* Q */
        /* R */
        RoofInDynamic = 1,
        RoofInFixed = 2,
        RoofOutDynamic = 3,
        RoofOutFixed = 4,
        ResetBuyPrice = 10,
        ResetSellPrice = 11,
        /* S */
        StopLossFixed = 5,
        StopLossDynamic = 6,
        //        StopLossTrailing = 23,
        //ScriptURL,
        ScriptSafety = 9,
        /* T */
        //TakeLosses,
        //TakeProfits
        /* U */
        /* V */
        /* W */
        /* X */
        /* Y */
        /* Z */
        HaasScriptSafety = 19
    }
}