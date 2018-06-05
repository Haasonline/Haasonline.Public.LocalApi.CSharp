using System.Collections.Generic;
using System.Globalization;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots;
using Haasonline.Public.LocalApi.CSharp.DataObjects.CustomBots.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class CustomBotApi : ApiBase
    {
        public CustomBotApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        #region Control
        public HaasonlineClientResponse<List<BaseCustomBot>> GetAllBots()
        {
            return Get<List<BaseCustomBot>>("/AllCustomBots");
        }

        public HaasonlineClientResponse<T> GetBot<T>(string botGuid) where T : BaseCustomBot
        {
            return Get<T>("/GetCustomBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid }
            });
        }


        public HaasonlineClientResponse<bool> ActivateBots(string botGuid, bool withExtra = false)
        {
            return Get<bool>("/ActivateCustomBot", new Dictionary<string, string>
            {
                {"botid", botGuid},
                {"extra", withExtra.ToString()},
            });
        }
        public HaasonlineClientResponse<bool> DeactivateBots(string botGuid, bool withExtra = false)
        {
            return Get<bool>("/DeactivateCustomBot", new Dictionary<string, string>
            {
                {"botid", botGuid},
                {"extra", withExtra.ToString()},
            });
        }

        public HaasonlineClientResponse<T> NewBot<T>(EnumCustomBotType botType, string name, string accountId, string primairyCoin, string secondairyCoin, string contractName)
        {
            return Get<T>("/NewCustomBot", new Dictionary<string, string>
            {
                {"botType", botType.ToString()},
                {"name", name},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
            });
        }
        public HaasonlineClientResponse<T> NewBot<T>(EnumCustomBotType botType, string name, string accountId, Market market)
        {
            return NewBot<T>(botType, name, accountId, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<JObject> NewBot(EnumCustomBotType botType, string name, string accountId, string primairyCoin, string secondairyCoin, string contractName)
        {
            return NewBot<JObject>(botType, name, accountId, primairyCoin, secondairyCoin, contractName);
        }
        public HaasonlineClientResponse<JObject> NewBot(EnumCustomBotType botType, string name, string accountId, Market market)
        {
            return NewBot<JObject>(botType, name, accountId, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<bool> RemoveBot(string botGuid)
        {
            return Get<bool>("/RemoveCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }

        public HaasonlineClientResponse<BaseCustomBot> ClearBot(string botGuid)
        {
            return ClearBot<BaseCustomBot>(botGuid);
        }
        public HaasonlineClientResponse<T> ClearBot<T>(string botGuid) where T : BaseCustomBot
        {
            return Get<T>("/ClearCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }

        public HaasonlineClientResponse<T> BacktestBot<T>(string botGuid, int minutesToTest) where T : BaseCustomBot
        {
            return Get<T>("/BacktestCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"minutesToTest", minutesToTest.ToString()}
            });
        }
        public HaasonlineClientResponse<T> BacktestBot<T>(string botGuid, int startUnix, int endUnix) where T : BaseCustomBot
        {
            return Get<T>("/BacktestCustomBotSpecific", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }

        public HaasonlineClientResponse<T> CloneBot<T>(EnumCustomBotType botType, string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage) where T : BaseCustomBot
        {
            return Get<T>("/CloneCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"name", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<T> CloneBotSimple<T>(EnumCustomBotType botType, string botGuid, string botName, string accountId) where T : BaseCustomBot
        {
            return Get<T>("/CloneCustomBotSimple", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"name", botName},
                {"accountId", accountId},
            });
        }
        #endregion

        #region Bot Setup
        public HaasonlineClientResponse<AccumulationBot> SetupAccumulationBot(string botName, string botGuid, string accountId, string primairyCoin, string secondairyCoin, EnumAccumulationBotStopType stopType, decimal stopTypeValue, decimal randomOrderSizeX, decimal randomOrderSizeY, int randomOrderTimeX, int randomOrderTimeY, EnumOrderType direction, bool triggerOnPrice, bool triggerWhenHiger, decimal triggerValue)
        {
            return Get<AccumulationBot>("/SetupAccumulationBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"stopTypeValue", stopTypeValue.ToString()},

                {"randomOrderSizeX", randomOrderSizeX.ToString(CultureInfo.InvariantCulture)},
                {"randomOrderSizeY", randomOrderSizeY.ToString(CultureInfo.InvariantCulture)},
                {"randomOrderTimeX", randomOrderTimeX.ToString(CultureInfo.InvariantCulture)},
                {"randomOrderTimeY", randomOrderTimeY.ToString(CultureInfo.InvariantCulture)},
                {"triggerValue", triggerValue.ToString(CultureInfo.InvariantCulture)},
                {"triggerWhenHigher", triggerWhenHiger.ToString()},
                {"triggerOnPrice", triggerOnPrice.ToString()},
                {"stopType", stopType.ToString()},
                {"direction", direction.ToString()},
            });
        }
        public HaasonlineClientResponse<CryptoIndexBot> SetupCryptoIndexBot(string botGuid, string botName, string accountId, string templateGuid, string baseCoin, decimal totalIndexValue, bool individualGrowth, List<CryptoIndexBotIndexSaveObject> indexes, bool allocateProfits)
        {
            return Get<CryptoIndexBot>("/SetupCryptoIndexBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"templateGuid", templateGuid},
                {"baseCoin", baseCoin},
                {"totalIndexValue", totalIndexValue.ToString(CultureInfo.InvariantCulture)},
                {"individualGrowth", individualGrowth.ToString()},
                {"allocateProfits", allocateProfits.ToString()},
                {"index", JsonConvert.SerializeObject(indexes)},
            });
        }
        public HaasonlineClientResponse<EmailBot> SetupEmailBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, decimal tradeAmount, decimal fee, string templateGuid, string position, List<EmailBotAction> actions, decimal stopLoss, decimal minChangeToBuy, decimal minChangeToSell)
        {
            return Get<EmailBot>("/SetupEmailBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"position", position},
                {"templateGuid", templateGuid},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"stopLoss", stopLoss.ToString(CultureInfo.InvariantCulture)},
                {"minChangeToBuy", minChangeToBuy.ToString(CultureInfo.InvariantCulture)},
                {"minChangeToSell", minChangeToSell.ToString(CultureInfo.InvariantCulture)},
                {"emails", JsonConvert.SerializeObject(actions)},
            });
        }
        public HaasonlineClientResponse<FlashCrashBot> SetupFlashCrashBot(FlashCrashBotSaveObject saveObject)
        {
            return Get<FlashCrashBot>("/SetupFlashCrashBot", new Dictionary<string, string>()
            {
                {"botName", saveObject.BotName},
                {"botGuid", saveObject.BotGuid},
                {"accountId", saveObject.AccountId},
                {"primairyCoin", saveObject.PriceMarket.PrimaryCurrency},
                {"secondairyCoin", saveObject.PriceMarket.SecondaryCurrency},
                {"fee", saveObject.Fee.ToString(CultureInfo.InvariantCulture)},

                {"basePrice", saveObject.BasePrice.ToString(CultureInfo.InvariantCulture)},
                {"priceSpreadType", saveObject.PriceSpreadType.ToString()},
                {"priceSpread", saveObject.PriceSpread.ToString(CultureInfo.InvariantCulture)},
                {"percentageBoost", saveObject.PercentageBoost.ToString(CultureInfo.InvariantCulture)},
                {"minPercentage", saveObject.MinPercentage.ToString(CultureInfo.InvariantCulture)},
                {"maxPercentage", saveObject.MaxPercentage.ToString(CultureInfo.InvariantCulture)},

                {"amountType", saveObject.AmountType.ToString()},
                {"amountSpread", saveObject.AmountSpread.ToString(CultureInfo.InvariantCulture)},
                {"sellAmount", saveObject.SellAmount.ToString(CultureInfo.InvariantCulture)},
                {"buyAmount", saveObject.BuyAmount.ToString(CultureInfo.InvariantCulture)},
                {"refillDelay", saveObject.RefillDelay.ToString(CultureInfo.InvariantCulture)},

                {"fttEnabled", saveObject.FollowTheTrend.ToString(CultureInfo.InvariantCulture)},
                {"fttOffset", saveObject.FollowTheTrendChannelOffset.ToString(CultureInfo.InvariantCulture)},
                {"fttRange", saveObject.FollowTheTrendChannelRange.ToString(CultureInfo.InvariantCulture)},
                {"fttTimeout", saveObject.FollowTheTrendTimeout.ToString(CultureInfo.InvariantCulture)},

                {"safetyTriggerLevel", saveObject.SafetyTriggerLevel.ToString(CultureInfo.InvariantCulture)},
                {"safetyEnabled", saveObject.SafetyEnabled.ToString()},
                {"safetyMoveInOut", saveObject.SafetyMoveInOut.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<InterExchangeArbitrageBot> SetupInterExchangeArbitrageBot(string botGuid, string botName, string accountId, string accountId2, string primairyCoin, string secondairyCoin, string primairyCoin2, string secondairyCoin2, decimal tradeAmount, decimal triggerLevel, string templateGuid, decimal maxAmount, int maxTrades)
        {
            return Get<InterExchangeArbitrageBot>("/SetupInterExchangeArbitrageBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"accountId2", accountId2},
                {"primairyCoin2", primairyCoin2},
                {"secondairyCoin2", secondairyCoin2},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"triggerLevel", triggerLevel.ToString(CultureInfo.InvariantCulture)},
                {"templateGuid", templateGuid.ToString(CultureInfo.InvariantCulture)},
                {"maxAmount", maxAmount.ToString(CultureInfo.InvariantCulture)},
                {"maxTrades", maxTrades.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<BaseCustomBot> SetupIntellibotAlice(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal tradeAmount, decimal fee, decimal leverage, string position)
        {
            return Get<BaseCustomBot>("/SetupIntellibotAlice", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<MarketMarkingBot> SetupMarketMakingBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, decimal tradeamount, decimal fee, decimal offset, int resetTimeout, bool usedSecondOrder, decimal secondOffset)
        {
            return Get<MarketMarkingBot>("/SetupMarketMakingBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"tradeAmount", tradeamount.ToString(CultureInfo.InvariantCulture)},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"priceOffset", offset.ToString(CultureInfo.InvariantCulture)},
                {"resetTimer", resetTimeout.ToString(CultureInfo.InvariantCulture)},
                {"useSecondOrder", usedSecondOrder.ToString(CultureInfo.InvariantCulture)},
                {"secondOrderPriceOffset", secondOffset.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<MadHatterBot> SetupMadHatterBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, decimal tradeAmount, decimal fee, string templateGuid, string position, int interval, bool consensusmode, bool disableAfterStopLoss)
        {
            return Get<MadHatterBot>("/SetupMadHatterBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"templateGuid", templateGuid},
                {"position", position},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},

                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"useTwoSignals", consensusmode.ToString()},
                {"disableAfterStopLoss", disableAfterStopLoss.ToString(CultureInfo.InvariantCulture)},
                {"interval", interval.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<OrderBot> SetupOrderBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin)
        {
            return Get<OrderBot>("/SetupOrderBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
            });
        }
        public HaasonlineClientResponse<BaseCustomBot> SetupPingPongBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, decimal tradeAmount, decimal fee, string position)
        {
            return Get<BaseCustomBot>("/SetupPingPongBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<ScalperBot> SetupScalpingBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, decimal tradeAmount, decimal fee, string position, string templateGuid, decimal targetPercentage, decimal safetyValue)
        {
            return Get<ScalperBot>("/SetupScalpingBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"targetProc", targetPercentage.ToString(CultureInfo.InvariantCulture)},
                {"safetyThreshold", safetyValue.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"templateGuid", templateGuid},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<ScriptBot> SetupScriptBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, decimal tradeAmount, decimal fee, string templateGuid, string position, string scriptId)
        {
            return Get<ScriptBot>("/SetupScriptBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"templateGuid", templateGuid},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},

                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"scriptId", scriptId},
            });
        }
        public HaasonlineClientResponse<ZoneRecoveryBot> SetupZoneRecoveryBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, decimal tradeAmount, decimal maxTradeAmount, decimal factorShort, decimal factorLong, decimal targetProfit, decimal zone)
        {
            return Get<ZoneRecoveryBot>("/SetupZoneRecoveryBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"maxTradeAmount", maxTradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"factorShort", factorShort.ToString(CultureInfo.InvariantCulture)},
                {"factorLong", factorLong.ToString(CultureInfo.InvariantCulture)},
                {"targetProfit", targetProfit.ToString(CultureInfo.InvariantCulture)},
                {"zone", zone.ToString(CultureInfo.InvariantCulture)}
            });
        }
        #endregion

        #region Bot Specific

        public HaasonlineClientResponse<bool> FlashCrashBotQuickStart(string botGuid)
        {
            return Get<bool>("/QuickStartFlashCrashBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }
        public HaasonlineClientResponse<bool> FlashCrashBotQuickStartAll()
        {
            return Get<bool>("/QuickStartAllFlashCrashBots");
        }

        public HaasonlineClientResponse<FlashCrashBot> FlashCrashBotAddBuyOrder(string botGuid)
        {
            return FlashCrashBotLiveEdit(botGuid, true, true);
        }
        public HaasonlineClientResponse<FlashCrashBot> FlashCrashBotRemoveBuyOrder(string botGuid)
        {
            return FlashCrashBotLiveEdit(botGuid, true, false);
        }
        public HaasonlineClientResponse<FlashCrashBot> FlashCrashBotAddSellOrder(string botGuid)
        {
            return FlashCrashBotLiveEdit(botGuid, false, true);
        }
        public HaasonlineClientResponse<FlashCrashBot> FlashCrashBotRemoveSellOrder(string botGuid)
        {
            return FlashCrashBotLiveEdit(botGuid, false, false);
        }
        private HaasonlineClientResponse<FlashCrashBot> FlashCrashBotLiveEdit(string botGuid, bool isBuyOrder, bool addOrder)
        {
            return Get<FlashCrashBot>("/LiveOrderEditFlashCrashBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"isBuyOrder", isBuyOrder.ToString()},
                {"addOrder", addOrder.ToString()},
            });
        }

        public HaasonlineClientResponse<MadHatterBot> MadHatterSetIndicatorParameter(string botGuid, EnumMadHatterIndicators type, int fieldNo, object value)
        {
            return Get<MadHatterBot>("/MadHatterSetIndicatorParameter", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"type", type.ToString()},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public HaasonlineClientResponse<MadHatterBot> MadHatterSetSafetyParameter(string botGuid, EnumMadHatterSafeties type, object value)
        {
            return Get<MadHatterBot>("/MadHatterSetSafetyParameter", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"type", type.ToString()},
                {"value", value.ToString()},
            });
        }

        public HaasonlineClientResponse<bool> FlipAccumulationBot(string botGuid)
        {
            return Get<bool>("/FlipAccumulationBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
            });
        }

        public HaasonlineClientResponse<OrderBot> OrderBotAddOrder(string botGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumOrderType direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return Get<OrderBot>("/OrderBotAddOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", direction.ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public HaasonlineClientResponse<OrderBot> OrderBotEditOrder(string botGuid, string orderGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumOrderType direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return Get<OrderBot>("/OrderBotEditOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", direction.ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public HaasonlineClientResponse<OrderBot> OrderBotResetOrder(string botGuid, string orderGuid)
        {
            return Get<OrderBot>("/OrderBotResetOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
            });
        }
        public HaasonlineClientResponse<OrderBot> OrderBotRemoveOrder(string botGuid, string orderGuid)
        {
            return Get<OrderBot>("/OrderBotRemoveOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
            });
        }
        public HaasonlineClientResponse<OrderBot> OrderBotRemoveAllOrders(string botGuid)
        {
            return Get<OrderBot>("/OrderBotRemoveAllOrders", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
            });
        }

        public HaasonlineClientResponse<ScriptBot> SetupScriptBotParameters(string botGuid, int fieldNo, object value)
        {
            return Get<ScriptBot>("/SetupScriptBotParameters", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        #endregion
    }
}