using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
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
        public async Task<HaasonlineClientResponse<List<BaseCustomBot>>> GetAllBots()
        {
            return await ExecuteAsync<List<BaseCustomBot>>("/AllCustomBots");
        }

        public async Task<HaasonlineClientResponse<T>> GetBot<T>(string botGuid) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/GetCustomBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid }
            });
        }


        public async Task<HaasonlineClientResponse<bool>> ActivateBots(string botGuid, bool withExtra = false)
        {
            return await ExecuteAsync<bool>("/ActivateCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"extra", withExtra.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<bool>> DeactivateBots(string botGuid, bool withExtra = false)
        {
            return await ExecuteAsync<bool>("/DeactivateCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"extra", withExtra.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<T>> NewBot<T>(EnumCustomBotType botType, string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await ExecuteAsync<T>("/NewCustomBot", new Dictionary<string, string>
            {
                {"botType", botType.ToString()},
                {"botName", name},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
            });
        }
        public async Task<HaasonlineClientResponse<T>> NewBot<T>(EnumCustomBotType botType, string name, string accountGuid, Market market)
        {
            return await NewBot<T>(botType, name, accountGuid, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<JObject>> NewBot(EnumCustomBotType botType, string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await NewBot<JObject>(botType, name, accountGuid, primaryCoin, secondaryCoin, contractName);
        }
        public async Task<HaasonlineClientResponse<JObject>> NewBot(EnumCustomBotType botType, string name, string accountGuid, Market market)
        {
            return await NewBot<JObject>(botType, name, accountGuid, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<bool>> RemoveBot(string botGuid)
        {
            return await ExecuteAsync<bool>("/RemoveCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }

        public async Task<HaasonlineClientResponse<BaseCustomBot>> ClearBot(string botGuid)
        {
            return await ClearBot<BaseCustomBot>(botGuid);
        }
        public async Task<HaasonlineClientResponse<T>> ClearBot<T>(string botGuid) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/ClearCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }

        public async Task<HaasonlineClientResponse<T>> BacktestBot<T>(string botGuid, int minutesToTest) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/BacktestCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"minutesToTest", minutesToTest.ToString()}
            });
        }
        public async Task<HaasonlineClientResponse<T>> BacktestBot<T>(string botGuid, int startUnix, int endUnix) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/BacktestCustomBotSpecific", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }
        public async Task<HaasonlineClientResponse<T>> BacktestBot<T>(string botGuid, int minutesToTest, string accountGuid, string primaryCoin, string secondaryCoin, string contractName) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/BacktestCustomBotOnMarket", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"minutesToTest", minutesToTest.ToString()},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
            });
        }

        public async Task<HaasonlineClientResponse<T>> CloneBot<T>(EnumCustomBotType botType, string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/CloneCustomBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<T>> CloneBotSimple<T>(EnumCustomBotType botType, string botGuid, string botName, string accountGuid) where T : BaseCustomBot
        {
            return await ExecuteAsync<T>("/CloneCustomBotSimple", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
            });
        }
        #endregion

        #region Bot Setup
        public async Task<HaasonlineClientResponse<AccumulationBot>> SetupAccumulationBot(string botName, string botGuid, string accountGuid, string primaryCoin, string secondaryCoin, EnumAccumulationBotStopType stopType, decimal stopTypeValue, decimal randomOrderSizeX, decimal randomOrderSizeY, int randomOrderTimeX, int randomOrderTimeY, EnumOrderType direction, bool triggerOnPrice, bool triggerWhenHiger, decimal triggerValue)
        {
            return await ExecuteAsync<AccumulationBot>("/SetupAccumulationBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
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
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> SetupAdvancedIndexBot(string botGuid, string botName, string accountGuid, string templateGuid, string baseCoin, decimal totalIndexValue, int rebalanceInterval, EnumAdvancedIndexBotRebalanceType rebalanceType, bool allocateProfits, bool preserveBaseIndexPercentage, List<AdvancedIndexBotIndexSaveObject> index)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/SetupAdvancedIndexBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"templateGuid", templateGuid},
                {"baseCoin", baseCoin},
                {"totalIndexValue", totalIndexValue.ToString(CultureInfo.InvariantCulture)},
                {"rebalanceInterval", rebalanceInterval.ToString(CultureInfo.InvariantCulture)},
                {"rebalanceType", rebalanceType.ToString()},
                {"allocateProfits", allocateProfits.ToString()},
                {"preserveBaseIndexPercentage", preserveBaseIndexPercentage.ToString()},
                {"index", JsonConvert.SerializeObject(index)},
            });
        }
        public async Task<HaasonlineClientResponse<CryptoIndexBot>> SetupCryptoIndexBot(string botGuid, string botName, string accountGuid, string templateGuid, string baseCoin, decimal totalIndexValue, bool individualGrowth, List<CryptoIndexBotIndexSaveObject> indexes, bool allocateProfits)
        {
            return await ExecuteAsync<CryptoIndexBot>("/SetupCryptoIndexBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"templateGuid", templateGuid},
                {"baseCoin", baseCoin},
                {"totalIndexValue", totalIndexValue.ToString(CultureInfo.InvariantCulture)},
                {"individualGrowth", individualGrowth.ToString()},
                {"allocateProfits", allocateProfits.ToString()},
                {"index", JsonConvert.SerializeObject(indexes)},
            });
        }
        public async Task<HaasonlineClientResponse<EmailBot>> SetupEmailBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage, EnumBotTradeAmount amountType, decimal tradeAmount, decimal fee, string templateGuid, string position, List<EmailBotAction> actions, decimal stopLoss, decimal minChangeToBuy, decimal minChangeToSell)
        {
            return await ExecuteAsync<EmailBot>("/SetupEmailBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"position", position},
                {"templateGuid", templateGuid},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmountType", amountType.ToString()},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"stopLoss", stopLoss.ToString(CultureInfo.InvariantCulture)},
                {"minChangeToBuy", minChangeToBuy.ToString(CultureInfo.InvariantCulture)},
                {"minChangeToSell", minChangeToSell.ToString(CultureInfo.InvariantCulture)},
                {"emails", JsonConvert.SerializeObject(actions)},
            });
        }
        public async Task<HaasonlineClientResponse<FlashCrashBot>> SetupFlashCrashBot(FlashCrashBotSaveObject saveObject)
        {
            return await ExecuteAsync<FlashCrashBot>("/SetupFlashCrashBot", new Dictionary<string, string>()
            {
                {"botName", saveObject.BotName},
                {"botGuid", saveObject.BotGuid},
                {"accountGuid", saveObject.AccountId},
                {"primaryCoin", saveObject.PriceMarket.PrimaryCurrency},
                {"secondaryCoin", saveObject.PriceMarket.SecondaryCurrency},
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
        public async Task<HaasonlineClientResponse<InterExchangeArbitrageBot>> SetupInterExchangeArbitrageBot(string botGuid, string botName, string accountGuid, string accountGuid2, string primaryCoin, string secondaryCoin, string primaryCoin2, string secondaryCoin2, decimal tradeAmount, decimal triggerLevel, string templateGuid, decimal maxAmount, int maxTrades)
        {
            return await ExecuteAsync<InterExchangeArbitrageBot>("/SetupInterExchangeArbitrageBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"accountGuid2", accountGuid2},
                {"primairyCoin2", primaryCoin2},
                {"secondairyCoin2", secondaryCoin2},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"triggerLevel", triggerLevel.ToString(CultureInfo.InvariantCulture)},
                {"templateGuid", templateGuid.ToString(CultureInfo.InvariantCulture)},
                {"maxAmount", maxAmount.ToString(CultureInfo.InvariantCulture)},
                {"maxTrades", maxTrades.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<BaseCustomBot>> SetupIntellibotAlice(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, EnumBotTradeAmount amountType, decimal tradeAmount, string templateGuid, decimal fee, decimal leverage, string position)
        {
            return await ExecuteAsync<BaseCustomBot>("/SetupIntellibotAlice", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmountType", amountType.ToString()},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"templateGuid", templateGuid},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<MarketMarkingBot>> SetupMarketMakingBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, decimal tradeamount, decimal fee, decimal offset, int resetTimeout, bool usedSecondOrder, decimal secondOffset)
        {
            return await ExecuteAsync<MarketMarkingBot>("/SetupMarketMakingBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"tradeAmount", tradeamount.ToString(CultureInfo.InvariantCulture)},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"priceOffset", offset.ToString(CultureInfo.InvariantCulture)},
                {"resetTimer", resetTimeout.ToString(CultureInfo.InvariantCulture)},
                {"useSecondOrder", usedSecondOrder.ToString(CultureInfo.InvariantCulture)},
                {"secondOrderPriceOffset", secondOffset.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<MadHatterBot>> SetupMadHatterBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, EnumBotTradeAmount amountType, decimal tradeAmount, decimal fee, string templateGuid, string position, int interval, bool consensusmode, bool disableAfterStopLoss, bool includeIncompleteInterval, EnumFundsPosition mappedBuySignal, EnumFundsPosition mappedSellSignal)
        {
            return await ExecuteAsync<MadHatterBot>("/SetupMadHatterBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"templateGuid", templateGuid},
                {"position", position},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},

                {"tradeAmountType", amountType.ToString()},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"useTwoSignals", consensusmode.ToString()},
                {"disableAfterStopLoss", disableAfterStopLoss.ToString(CultureInfo.InvariantCulture)},
                {"interval", interval.ToString(CultureInfo.InvariantCulture)},
                {"includeIncompleteInterval", includeIncompleteInterval.ToString()},
                {"mappedBuySignal", mappedBuySignal.ToString()},
                {"mappedSellSignal", mappedSellSignal.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> SetupOrderBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin)
        {
            return await ExecuteAsync<OrderBot>("/SetupOrderBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
            });
        }
        public async Task<HaasonlineClientResponse<BaseCustomBot>> SetupPingPongBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage, EnumBotTradeAmount amountType, decimal tradeAmount, string templateGuid, decimal fee, string position)
        {
            return await ExecuteAsync<BaseCustomBot>("/SetupPingPongBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmountType", amountType.ToString()},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"templateGuid", templateGuid},
                {"position", position},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<ScalperBot>> SetupScalpingBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage, EnumBotTradeAmount amountType, decimal tradeAmount, decimal fee, string position, string templateGuid, decimal targetPercentage, decimal safetyValue)
        {
            return await ExecuteAsync<ScalperBot>("/SetupScalpingBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"tradeAmountType", amountType.ToString()},
                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"targetPercentage", targetPercentage.ToString(CultureInfo.InvariantCulture)},
                {"safetyThreshold", safetyValue.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"templateGuid", templateGuid},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<ScriptBot>> SetupScriptBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage, decimal tradeAmount, decimal fee, string templateGuid, string position, string scriptId)
        {
            return await ExecuteAsync<ScriptBot>("/SetupScriptBot", new Dictionary<string, string>()
            {
                {"botName", botName},
                {"botGuid", botGuid},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"templateGuid", templateGuid},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},

                {"tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                {"fee", fee.ToString(CultureInfo.InvariantCulture)},
                {"position", position},
                {"scriptId", scriptId},
            });
        }
        public async Task<HaasonlineClientResponse<ZoneRecoveryBot>> SetupZoneRecoveryBot(string botGuid, string botName, string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal leverage, decimal tradeAmount, decimal maxTradeAmount, decimal factorShort, decimal factorLong, decimal targetProfit, decimal zone)
        {
            return await ExecuteAsync<ZoneRecoveryBot>("/SetupZoneRecoveryBot", new Dictionary<string, string>()
            {
                {"botGuid", botGuid},
                {"botName", botName},
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
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
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> AdvancedIndexBotAddIndex(string botGuid, AdvancedIndexBotIndexSaveObject index, bool relocateBalance, bool raiseBalance)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/AdvancedIndexBotAddIndex", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"index", JsonConvert.SerializeObject(index)},
                {"raiseBalance", raiseBalance.ToString()},
                {"relocateBalance", relocateBalance.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> AdvancedIndexBotRemoveIndex(string botGuid, string index, bool lowerBalance)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/AdvancedIndexBotRemoveIndex", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"index", index},
                {"lowerBalance", lowerBalance.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> AdvancedIndexBotIncludeIndex(string botGuid, string index)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/AdvancedIndexBotIncludeIndex", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"index", index},
            });
        }
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> AdvancedIndexBotRebalanceBot(string botGuid)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/AdvancedIndexBotRebalanceBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
            });
        }

        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> CryptoIndexBotAddIndex(string botGuid, CryptoIndexBotIndexSaveObject index, bool relocateBalance, bool raiseBalance)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/CryptoIndexBotAddIndex", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"index", JsonConvert.SerializeObject(index)},
                {"raiseBalance", raiseBalance.ToString()},
                {"relocateBalance", relocateBalance.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<AdvancedIndexBot>> CryptoIndexBotRemoveIndex(string botGuid, string index, bool lowerBalance)
        {
            return await ExecuteAsync<AdvancedIndexBot>("/CryptoIndexBotRemoveIndex", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"index", index},
                {"lowerBalance", lowerBalance.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<bool>> FlashCrashBotQuickStart(string botGuid)
        {
            return await ExecuteAsync<bool>("/QuickStartFlashCrashBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid}
            });
        }
        public async Task<HaasonlineClientResponse<bool>> FlashCrashBotQuickStartAll()
        {
            return await ExecuteAsync<bool>("/QuickStartAllFlashCrashBots");
        }

        public async Task<HaasonlineClientResponse<FlashCrashBot>> FlashCrashBotAddBuyOrder(string botGuid)
        {
            return await FlashCrashBotLiveEdit(botGuid, true, true);
        }
        public async Task<HaasonlineClientResponse<FlashCrashBot>> FlashCrashBotRemoveBuyOrder(string botGuid)
        {
            return await FlashCrashBotLiveEdit(botGuid, true, false);
        }
        public async Task<HaasonlineClientResponse<FlashCrashBot>> FlashCrashBotAddSellOrder(string botGuid)
        {
            return await FlashCrashBotLiveEdit(botGuid, false, true);
        }
        public async Task<HaasonlineClientResponse<FlashCrashBot>> FlashCrashBotRemoveSellOrder(string botGuid)
        {
            return await FlashCrashBotLiveEdit(botGuid, false, false);
        }
        private async Task<HaasonlineClientResponse<FlashCrashBot>> FlashCrashBotLiveEdit(string botGuid, bool isBuyOrder, bool addOrder)
        {
            return await ExecuteAsync<FlashCrashBot>("/LiveOrderEditFlashCrashBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"isBuyOrder", isBuyOrder.ToString()},
                {"addOrder", addOrder.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<MadHatterBot>> MadHatterSetIndicatorParameter(string botGuid, EnumMadHatterIndicators type, int fieldNo, object value)
        {
            return await ExecuteAsync<MadHatterBot>("/MadHatterSetIndicatorParameter", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"type", type.ToString()},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<MadHatterBot>> MadHatterSetSafetyParameter(string botGuid, EnumMadHatterSafeties type, object value)
        {
            return await ExecuteAsync<MadHatterBot>("/MadHatterSetSafetyParameter", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"type", type.ToString()},
                {"value", value.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<bool>> FlipAccumulationBot(string botGuid)
        {
            return await ExecuteAsync<bool>("/FlipAccumulationBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
            });
        }

        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotAddOrder(string botGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumOrderType direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotAddOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", ((int)direction).ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotAddOrder(string botGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumFundsMovingPosition direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotAddOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", ((int)direction).ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotEditOrder(string botGuid, string orderGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumOrderType direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotEditOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", ((int)direction).ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotEditOrder(string botGuid, string orderGuid, string dependsOn, string dependsOnNotExecuted, decimal amount, decimal price, EnumFundsMovingPosition direction, string templateGuid, EnumOrderBotTriggerType triggerType, decimal triggerPrice)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotEditOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
                {"dependsOn", dependsOn},
                {"dependsOnNotExecuted", dependsOnNotExecuted},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture)},
                {"orderTemplate", templateGuid},
                {"orderType", ((int)direction).ToString()},
                {"triggerType", triggerType.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotResetOrder(string botGuid, string orderGuid)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotResetOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotRemoveOrder(string botGuid, string orderGuid)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotRemoveOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"orderGuid", orderGuid},
            });
        }
        public async Task<HaasonlineClientResponse<OrderBot>> OrderBotRemoveAllOrders(string botGuid)
        {
            return await ExecuteAsync<OrderBot>("/OrderBotRemoveAllOrders", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
            });
        }

        public async Task<HaasonlineClientResponse<ScriptBot>> SetupScriptBotParameters(string botGuid, int fieldNo, object value)
        {
            return await ExecuteAsync<ScriptBot>("/SetupScriptBotParameters", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }


        #endregion
    }
}