using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.TradeBot;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class TradeBotApi : ApiBase
    {
        public TradeBotApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        public HaasonlineClientResponse<List<TradeBot>> GetAllBots()
        {
            return Get<List<TradeBot>>("/AllTradeBots");
        }
        public HaasonlineClientResponse<TradeBot> GetBot(string botGuid)
        {
            var res  = Get<List<TradeBot>>("/AllTradeBots");
            if (!res.IsSuccess)
                return new HaasonlineClientResponse<TradeBot>
                {
                    ErrorMessage = res.ErrorMessage
                };

            var bot = res.Result.FirstOrDefault(c => c.GUID == botGuid);
            if (bot == null)
                return new HaasonlineClientResponse<TradeBot>
                {
                    ErrorMessage = "Invalid bot guid"
                };

            return new HaasonlineClientResponse<TradeBot>
            {
                IsSuccess = true,
                Result = bot
            };
        }

        public HaasonlineClientResponse<bool> ActivateBot(string botGuid)
        {
            return Get<bool>("/ActivateTradeBot", new Dictionary<string, string>
            {
                { "botid", botGuid }
            });
        }
        public HaasonlineClientResponse<bool> DeactivateBot(string botGuid)
        {
            return Get<bool>("/DeactivateBot", new Dictionary<string, string>
            {
                { "botid", botGuid }
            });
        }

        public HaasonlineClientResponse<TradeBot> NewBot(string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, string groupId = "")
        {
            return Get<TradeBot>("/NewTradeBot", new Dictionary<string, string>
            {
                { "botName", botName },
                { "accountId", accountId },
                { "primairyCoin", primairyCoin},
                { "secondairyCoin", secondairyCoin},
                { "contractName", contractName},
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                { "groupId", groupId},
            });
        }
        public HaasonlineClientResponse<bool> RemoveBot(string botGuid)
        {
            return Get<bool>("/RemoveTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
            });
        }
        public HaasonlineClientResponse<TradeBot> CleanBot(string botGuid)
        {
            return Get<TradeBot>("/CleanTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
            });
        }
        public HaasonlineClientResponse<bool> LockTradeBot(string botGuid, bool lockBot)
        {
            return Get<bool>("/LockTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "lockBot", lockBot.ToString() },
            });
        }

        public HaasonlineClientResponse<TradeBot> BacktestBot(string botGuid, int minutesToTest)
        {
            var endUnix = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var startUnix = endUnix - minutesToTest * 60;

            return Get<TradeBot>("/BackTestTradeBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }
        public HaasonlineClientResponse<TradeBot> BacktestBot(string botGuid, int startUnix, int endUnix)
        {
            return Get<TradeBot>("/BackTestTradeBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }

        public HaasonlineClientResponse<TradeBot> SetupBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, bool useConsensus, bool copyMarketToElements = true, string groupId = "")
        {
            return Get<TradeBot>("/SetupTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "botName", botName },
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"groupId", groupId},
                {"useConsensus", useConsensus.ToString()},
                {"copyMarketToElements", copyMarketToElements.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> SetupSpotBotTradeAmount(string botGuid, EnumCoinsPosition coinPosition, decimal tradeAmount, decimal lastBuyPrice, decimal lastSellPrice, string buyTemplateId, string sellTemplateId, bool highSpeedEnabled, bool allIn, int orderTimeout, int templateTimeout, bool maxTradeAmount, EnumLimitOrderPriceType limitOrderType, bool useHiddenOrders, decimal fee)
        {
            return Get<TradeBot>("/SetupSpotBotTradeAmount", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "coinPosition", coinPosition.ToString() },
                { "tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                { "lastBuyPrice", lastBuyPrice.ToString(CultureInfo.InvariantCulture)},
                { "lastSellPrice", lastSellPrice.ToString(CultureInfo.InvariantCulture)},
                { "buyTemplateId", buyTemplateId},
                { "sellTemplateId", sellTemplateId},
                { "highSpeedEnabled", highSpeedEnabled.ToString()},
                { "allIn", allIn.ToString()},
                { "orderTimeout", orderTimeout.ToString()},
                { "templateTimeout", templateTimeout.ToString()},
                { "allowAdjustDown", maxTradeAmount.ToString()},
                { "limitOrderType", limitOrderType.ToString()},
                { "useHiddenOrders", useHiddenOrders.ToString()},
                { "fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public HaasonlineClientResponse<TradeBot> SetupLeverageBotTradeAmount(string botGuid, EnumFundsPosition fundsPosition, decimal tradeAmount, decimal lastLongPrice, decimal lastShortPrice, string enterTemplateId, string exitTemplateId, bool highSpeedEnabled, bool allIn, int orderTimeout, int templateTimeout, bool maxTradeAmount, EnumLimitOrderPriceType limitOrderType, bool useHiddenOrders, decimal fee)
        {
            return Get<TradeBot>("/SetupLeverageBotTradeAmount", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "fundsPosition", fundsPosition.ToString() },
                { "tradeAmount", tradeAmount.ToString(CultureInfo.InvariantCulture)},
                { "lastLongPrice", lastLongPrice.ToString(CultureInfo.InvariantCulture)},
                { "lastShortPrice", lastShortPrice.ToString(CultureInfo.InvariantCulture)},
                { "enterTemplateId", enterTemplateId},
                { "exitTemplateId", exitTemplateId},
                { "highSpeedEnabled", highSpeedEnabled.ToString()},
                { "allIn", allIn.ToString()},
                { "orderTimeout", orderTimeout.ToString()},
                { "templateTimeout", templateTimeout.ToString()},
                { "allowAdjustDown", maxTradeAmount.ToString()},
                { "limitOrderType", limitOrderType.ToString()},
                { "useHiddenOrders", useHiddenOrders.ToString()},
                { "fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }

        public HaasonlineClientResponse<TradeBot> AddSafety(string botGuid, EnumSafety safetyType)
        {
            return Get<TradeBot>("/AddSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "safetyType", safetyType.ToString() },
            });
        }
        public HaasonlineClientResponse<TradeBot> AddIndicator(string botGuid, EnumIndicator indicatorType)
        {
            return Get<TradeBot>("/AddIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "indicatorType", indicatorType.ToString() },
            });
        }
        public HaasonlineClientResponse<TradeBot> AddInsurance(string botGuid, EnumInsurances insuranceType)
        {
            return Get<TradeBot>("/AddInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "insuranceType", insuranceType.ToString() },
            });
        }

        public HaasonlineClientResponse<TradeBot> RemoveSafety(string botGuid, string elementGuid)
        {
            return Get<TradeBot>("/RemoveSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }
        public HaasonlineClientResponse<TradeBot> RemoveIndicator(string botGuid, string elementGuid)
        {
            return Get<TradeBot>("/RemoveIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }
        public HaasonlineClientResponse<TradeBot> RemoveInsurance(string botGuid, string elementGuid)
        {
            return Get<TradeBot>("/RemoveInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }

        public HaasonlineClientResponse<TradeBot> SetupIndicator(string botGuid, string elementGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, int interval, EnumPriceChartType chartType, int delay)
        {
            return Get<TradeBot>("/SetupTradeBotIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "priceSourceName", priceSource.ToString()},
                { "primairyCoin", primairyCoin},
                { "secondairyCoin", secondairyCoin},
                { "contractName", contractName},
                { "interval", interval.ToString(CultureInfo.InvariantCulture)},
                { "delay", delay.ToString()},
                { "priceChartType", chartType.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> SetupSafety(string botGuid, string elementGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, EnumFundsPosition buySignal, EnumFundsPosition sellSignal)
        {
            return Get<TradeBot>("/SetupTradeBotSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "priceSourceName", priceSource.ToString()},
                { "primairyCoin", primairyCoin},
                { "secondairyCoin", secondairyCoin},
                { "contractName", contractName},
                { "mappedBuySignal", buySignal.ToString()},
                { "mappedSellSignal", sellSignal.ToString()},
            });
        }

        public HaasonlineClientResponse<TradeBot> SetupIndicatorSpotSignals(string botGuid, string elementGuid, bool useBuySignal, bool useSellSignal, bool reverseSignals, bool standAlone)
        {
            return Get<TradeBot>("/SetupTradeBotIndicatorSpotSignals", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "useBuySignal", useBuySignal.ToString()},
                { "useSellSignal", useSellSignal.ToString()},
                { "reverseSignals", reverseSignals.ToString()},
                { "standAlone", standAlone.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> SetupIndicatorLeverageSignals(string botGuid, string elementGuid, bool useLongSignals, bool useNoPositionSignals, bool useShortSignals, bool reverseSignals, bool standAlone, EnumFundsPosition mappedLong, EnumFundsPosition mappedShort)
        {
            return Get<TradeBot>("/SetupTradeBotIndicatorLeverageSignals", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "useLongSignals", useLongSignals.ToString()},
                { "useNoPositionSignals", useNoPositionSignals.ToString()},
                { "useShortSignals", useShortSignals.ToString()},
                { "reverseSignals", reverseSignals.ToString()},
                { "standAlone", standAlone.ToString()},
                { "mappedLongSignal", mappedLong.ToString()},
                { "mappedShortSignal", mappedShort.ToString()},
            });
        }

        public HaasonlineClientResponse<TradeBot> EditBotIndicatorSetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return Get<TradeBot>("/EditTradeBotIndicatorSetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> EditBotSafetySetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return Get<TradeBot>("/EditTradeBotSafetySetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> EditBotInsuranceSetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return Get<TradeBot>("/EditTradeBotInsuranceSetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }

        public HaasonlineClientResponse<TradeBot> SwitchCoinPositions(string botGuid, EnumCoinsPosition position)
        {
            return Get<TradeBot>("/SwitchTradeBotCoinPositions", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"coinPosition", position.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> SwitchBotFundsPositions(string botGuid, EnumFundsPosition position)
        {
            return Get<TradeBot>("/SwitchTradeBotFundsPositions", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"fundsPosition", position.ToString()},
            });
        }

        public HaasonlineClientResponse<TradeBot> SwitchBotCoinPositionsWithOrder(string botGuid, string templateGuid)
        {
            return Get<TradeBot>("/SwitchTradeBotCoinPositionsWithOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"templateGuid", templateGuid},
            });
        }
        public HaasonlineClientResponse<TradeBot> SwitchBotFundsPositionsWithOrder(string botGuid, EnumFundsPosition targetPosition, string templateGuid)
        {
            return Get<TradeBot>("/SwitchTradeBotFundsPositionsWithOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"templateGuid", templateGuid},
                {"fundsPosition", targetPosition.ToString()},
            });
        }


        public HaasonlineClientResponse<TradeBot> CloneBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, bool copySafeties, bool copyIndicators, bool copyInsurances, bool copyParameters, bool copyMarketToElements)
        {
            return Get<TradeBot>("/CloneTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "botName", botName },
                {"accountId", accountId},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"copySafeties", copySafeties.ToString()},
                {"copyIndicators", copyIndicators.ToString()},
                {"copyInsurances", copyInsurances.ToString()},
                {"copyParameters", copyParameters.ToString()},
                {"copyMarketToElements", copyMarketToElements.ToString()},
            });
        }
        public HaasonlineClientResponse<TradeBot> CloneIndicator(string botGuid, string elementGuid, string toBotGuid)
        {
            return Get<TradeBot>("/CloneIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid},
            });
        }
        public HaasonlineClientResponse<TradeBot> CloneSafety(string botGuid, string elementGuid, string toBotGuid)
        {
            return Get<TradeBot>("/CloneSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid},
            });
        }
        public HaasonlineClientResponse<TradeBot> CloneInsurance(string botGuid, string elementGuid, string toBotGuid)
        {
            return Get<TradeBot>("/CloneInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid },
            });
        }

    }
}