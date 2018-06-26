using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AdvancedOrders;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class AdvancedOrderApi : ApiBase
    {
        public AdvancedOrderApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        public async Task<HaasonlineClientResponse<Dictionary<string, AdvancedOrderBase>>> GetAdvancedOrders()
        {
            return await ExecuteAsync<Dictionary<string, AdvancedOrderBase>>("/GetAdvancedOrders");
        }

        public async Task<HaasonlineClientResponse<AdvancedOrderBase>> ActivateAdvancedOrder(string guid)
        {
            return await ExecuteAsync<AdvancedOrderBase>("/ActivateAdvancedOrder", new Dictionary<string, string>
            {
                {"guid", guid }
            });
        }

        public async Task<HaasonlineClientResponse<AdvancedOrderBase>> DeactivateAdvancedOrder(string guid)
        {
            return await ExecuteAsync<AdvancedOrderBase>("/DeactivateAdvancedOrder", new Dictionary<string, string>
            {
                {"guid", guid }
            });
        }

        public async Task<HaasonlineClientResponse<bool>> RemoveAdvancedOrder(string guid)
        {
            return await ExecuteAsync<bool>("/RemoveAdvancedOrder", new Dictionary<string, string>
            {
                {"guid", guid }
            });
        }

        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> AddStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }


        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> AddStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }


        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> AddTakeProfitOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddTakeProfitOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }

        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> AddTakeProfitOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddTakeProfitOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }


        public async Task<HaasonlineClientResponse<TrailingStop>> AddTrailingStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal trailingStopPercentage, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<TrailingStop>("/AddTrailingStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"trailingStopPercentage", trailingStopPercentage.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }

        public async Task<HaasonlineClientResponse<TrailingStop>> AddTrailingStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal trailingStopPercentage, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid, bool activate)
        {
            return await ExecuteAsync<TrailingStop>("/AddTrailingStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"trailingStopPercentage", trailingStopPercentage.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
                {"activate", activate.ToString() },
            });
        }




        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> SetupStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }

        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> SetupStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }



        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> SetupTakeProfitOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddTakeProfitOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }

        public async Task<HaasonlineClientResponse<StopTakeProfitOrder>> SetupTakeProfitOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal triggerPrice, decimal executionPrice, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<StopTakeProfitOrder>("/AddTakeProfitOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"triggerPrice", triggerPrice.ToString(CultureInfo.InvariantCulture) },
                {"executionPrice", executionPrice.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }



        public async Task<HaasonlineClientResponse<TrailingStop>> SetupTrailingStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin,
            EnumOrderType direction, string executingTemplateGuid, decimal trailingStopPercentage, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<TrailingStop>("/AddTrailingStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"leverage", "0" },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"trailingStopPercentage", trailingStopPercentage.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }

        public async Task<HaasonlineClientResponse<TrailingStop>> SetupTrailingStopOrder(string name, string accountGuid, string primaryCoin, string secondaryCoin, string contractName,
            decimal leverage, EnumFundsMovingPosition direction, string executingTemplateGuid, decimal trailingStopPercentage, decimal amount,
            bool startOrderOnActivation, decimal startOrderPrice, string startTemplateGuid)
        {
            return await ExecuteAsync<TrailingStop>("/AddTrailingStopOrder", new Dictionary<string, string>
            {
                {"name", name },
                {"accountGuid", accountGuid },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture) },
                {"orderDirection", ((int)direction).ToString() },
                {"executingTemplateGuid", executingTemplateGuid },
                {"trailingStopPercentage", trailingStopPercentage.ToString(CultureInfo.InvariantCulture) },
                {"amount", amount.ToString(CultureInfo.InvariantCulture) },
                {"startOrderOnActivation", startOrderOnActivation.ToString() },
                {"startOrderPrice", startOrderPrice.ToString(CultureInfo.InvariantCulture) },
                {"startTemplateGuid", startTemplateGuid },
            });
        }
    }
}