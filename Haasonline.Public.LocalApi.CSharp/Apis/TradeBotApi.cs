using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<HaasonlineClientResponse<List<TradeBot>>> GetAllBots()
        {
            return await ExecuteAsync<List<TradeBot>>("/AllTradeBots");
        }
        public async Task<HaasonlineClientResponse<TradeBot>> GetBot(string botGuid)
        {
            var res  = await ExecuteAsync<List<TradeBot>>("/AllTradeBots");
            if (res.ErrorCode != EnumErrorCode.Success)
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
                ErrorCode =  EnumErrorCode.Success,
                Result = bot
            };
        }

        public async Task<HaasonlineClientResponse<bool>> ActivateBot(string botGuid)
        {
            return await ExecuteAsync<bool>("/ActivateTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid }
            });
        }
        public async Task<HaasonlineClientResponse<bool>> DeactivateBot(string botGuid)
        {
            return await ExecuteAsync<bool>("/DeactivateBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid }
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> NewBot(string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, string groupId = "")
        {
            return await ExecuteAsync<TradeBot>("/NewTradeBot", new Dictionary<string, string>
            {
                { "botName", botName },
                { "accountGuid", accountId },
                { "primaryCoin", primairyCoin},
                { "secondaryCoin", secondairyCoin},
                { "contractName", contractName},
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                { "groupId", groupId},
            });
        }
        public async Task<HaasonlineClientResponse<bool>> RemoveBot(string botGuid)
        {
            return await ExecuteAsync<bool>("/RemoveTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> CleanBot(string botGuid)
        {
            return await ExecuteAsync<TradeBot>("/CleanTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
            });
        }
        public async Task<HaasonlineClientResponse<bool>> LockTradeBot(string botGuid, bool lockBot)
        {
            return await ExecuteAsync<bool>("/LockTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "lockBot", lockBot.ToString() },
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> BacktestBot(string botGuid, int minutesToTest)
        {
            var endUnix = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var startUnix = endUnix - minutesToTest * 60;

            return await ExecuteAsync<TradeBot>("/BackTestTradeBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> BacktestBot(string botGuid, int startUnix, int endUnix)
        {
            return await ExecuteAsync<TradeBot>("/BackTestTradeBot", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"startUnix", startUnix.ToString()},
                {"endUnix", endUnix.ToString()}
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> SetupBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, bool useConsensus, bool copyMarketToElements = true, string groupId = "")
        {
            return await ExecuteAsync<TradeBot>("/SetupTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "botName", botName },
                {"accountGuid", accountId},
                {"primaryCoin", primairyCoin},
                {"secondaryCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"groupId", groupId},
                {"useConsensus", useConsensus.ToString()},
                {"copyMarketToElements", copyMarketToElements.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SetupSpotBotTradeAmount(string botGuid, EnumCoinsPosition coinPosition, decimal tradeAmount, decimal lastBuyPrice, decimal lastSellPrice, string buyTemplateId, string sellTemplateId, bool highSpeedEnabled, bool allIn, int orderTimeout, int templateTimeout, bool maxTradeAmount, EnumLimitOrderPriceType limitOrderType, bool useHiddenOrders, decimal fee)
        {
            return await ExecuteAsync<TradeBot>("/SetupSpotBotTradeAmount", new Dictionary<string, string>
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
                { "maxTradeAmount", maxTradeAmount.ToString()},
                { "limitOrderType", limitOrderType.ToString()},
                { "useHiddenOrders", useHiddenOrders.ToString()},
                { "fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SetupLeverageBotTradeAmount(string botGuid, EnumFundsPosition fundsPosition, decimal tradeAmount, decimal lastLongPrice, decimal lastShortPrice, string enterTemplateId, string exitTemplateId, bool highSpeedEnabled, bool allIn, int orderTimeout, int templateTimeout, bool maxTradeAmount, EnumLimitOrderPriceType limitOrderType, bool useHiddenOrders, decimal fee)
        {
            return await ExecuteAsync<TradeBot>("/SetupLeverageBotTradeAmount", new Dictionary<string, string>
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
                { "maxTradeAmount", maxTradeAmount.ToString()},
                { "limitOrderType", limitOrderType.ToString()},
                { "useHiddenOrders", useHiddenOrders.ToString()},
                { "fee", fee.ToString(CultureInfo.InvariantCulture)},
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> AddSafety(string botGuid, EnumSafety safetyType)
        {
            return await ExecuteAsync<TradeBot>("/AddSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "safetyType", safetyType.ToString() },
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> AddIndicator(string botGuid, EnumIndicator indicatorType)
        {
            return await ExecuteAsync<TradeBot>("/AddIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "indicatorType", indicatorType.ToString() },
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> AddInsurance(string botGuid, EnumInsurances insuranceType)
        {
            return await ExecuteAsync<TradeBot>("/AddInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "insuranceType", insuranceType.ToString() },
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> RemoveSafety(string botGuid, string elementGuid)
        {
            return await ExecuteAsync<TradeBot>("/RemoveSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> RemoveIndicator(string botGuid, string elementGuid)
        {
            return await ExecuteAsync<TradeBot>("/RemoveIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> RemoveInsurance(string botGuid, string elementGuid)
        {
            return await ExecuteAsync<TradeBot>("/RemoveInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> SetupIndicator(string botGuid, string elementGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, int interval, EnumPriceChartType chartType, int delay)
        {
            return await ExecuteAsync<TradeBot>("/SetupTradeBotIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "priceSourceName", priceSource.ToString()},
                { "primaryCoin", primairyCoin},
                { "secondaryCoin", secondairyCoin},
                { "contractName", contractName},
                { "interval", interval.ToString(CultureInfo.InvariantCulture)},
                { "delay", delay.ToString()},
                { "priceChartType", chartType.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SetupSafety(string botGuid, string elementGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, EnumFundsPosition buySignal, EnumFundsPosition sellSignal)
        {
            return await ExecuteAsync<TradeBot>("/SetupTradeBotSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "priceSourceName", priceSource.ToString()},
                { "primaryCoin", primairyCoin},
                { "secondaryCoin", secondairyCoin},
                { "contractName", contractName},
                { "mappedBuySignal", buySignal.ToString()},
                { "mappedSellSignal", sellSignal.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> SetupIndicatorSpotSignals(string botGuid, string elementGuid, bool useBuySignal, bool useSellSignal, bool reverseSignals, bool standAlone)
        {
            return await ExecuteAsync<TradeBot>("/SetupTradeBotIndicatorSpotSignals", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                { "useBuySignal", useBuySignal.ToString()},
                { "useSellSignal", useSellSignal.ToString()},
                { "reverseSignals", reverseSignals.ToString()},
                { "standAlone", standAlone.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SetupIndicatorLeverageSignals(string botGuid, string elementGuid, bool useLongSignals, bool useNoPositionSignals, bool useShortSignals, bool reverseSignals, bool standAlone, EnumFundsPosition mappedLong, EnumFundsPosition mappedShort)
        {
            return await ExecuteAsync<TradeBot>("/SetupTradeBotIndicatorLeverageSignals", new Dictionary<string, string>
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

        public async Task<HaasonlineClientResponse<TradeBot>> EditBotIndicatorSetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return await ExecuteAsync<TradeBot>("/EditTradeBotIndicatorSetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> EditBotSafetySetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return await ExecuteAsync<TradeBot>("/EditTradeBotSafetySetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> EditBotInsuranceSetting(string botGuid, string elementGuid, int fieldNo, object value)
        {
            return await ExecuteAsync<TradeBot>("/EditTradeBotInsuranceSetting", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"elementGuid", elementGuid},
                {"fieldNo", fieldNo.ToString()},
                {"value", value.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> SwitchCoinPositions(string botGuid, EnumCoinsPosition position)
        {
            return await ExecuteAsync<TradeBot>("/SwitchTradeBotCoinPositions", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"coinPosition", position.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SwitchBotFundsPositions(string botGuid, EnumFundsPosition position)
        {
            return await ExecuteAsync<TradeBot>("/SwitchTradeBotFundsPositions", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"fundsPosition", position.ToString()},
            });
        }

        public async Task<HaasonlineClientResponse<TradeBot>> SwitchBotCoinPositionsWithOrder(string botGuid, string templateGuid)
        {
            return await ExecuteAsync<TradeBot>("/SwitchTradeBotCoinPositionsWithOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"templateGuid", templateGuid},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> SwitchBotFundsPositionsWithOrder(string botGuid, EnumFundsPosition targetPosition, string templateGuid)
        {
            return await ExecuteAsync<TradeBot>("/SwitchTradeBotFundsPositionsWithOrder", new Dictionary<string, string>
            {
                {"botGuid", botGuid},
                {"templateGuid", templateGuid},
                {"fundsPosition", targetPosition.ToString()},
            });
        }


        public async Task<HaasonlineClientResponse<TradeBot>> CloneBot(string botGuid, string botName, string accountId, string primairyCoin, string secondairyCoin, string contractName, decimal leverage, bool copySafeties, bool copyIndicators, bool copyInsurances, bool copyParameters, bool copyMarketToElements)
        {
            return await ExecuteAsync<TradeBot>("/CloneTradeBot", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "botName", botName },
                {"accountGuid", accountId},
                {"primaryCoin", primairyCoin},
                {"secondaryCoin", secondairyCoin},
                {"contractName", contractName},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
                {"copySafeties", copySafeties.ToString()},
                {"copyIndicators", copyIndicators.ToString()},
                {"copyInsurances", copyInsurances.ToString()},
                {"copyParameters", copyParameters.ToString()},
                {"copyMarketToElements", copyMarketToElements.ToString()},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> CloneIndicator(string botGuid, string elementGuid, string toBotGuid)
        {
            return await ExecuteAsync<TradeBot>("/CloneIndicator", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> CloneSafety(string botGuid, string elementGuid, string toBotGuid)
        {
            return await ExecuteAsync<TradeBot>("/CloneSafety", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid},
            });
        }
        public async Task<HaasonlineClientResponse<TradeBot>> CloneInsurance(string botGuid, string elementGuid, string toBotGuid)
        {
            return await ExecuteAsync<TradeBot>("/CloneInsurance", new Dictionary<string, string>
            {
                { "botGuid", botGuid },
                { "elementGuid", elementGuid },
                {"toBotGuid", toBotGuid },
            });
        }

    }
}