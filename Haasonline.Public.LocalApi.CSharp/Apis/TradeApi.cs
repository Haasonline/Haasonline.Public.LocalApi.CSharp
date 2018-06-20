using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Haasonline.Public.LocalApi.CSharp.DataObjects;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class TradeApi : ApiBase
    {
        public TradeApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        public async Task<HaasonlineClientResponse<string>> PlaceSpotBuyOrder(string accountGuid, string primaryCoin, string secondaryCoin, decimal price, decimal amount, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceSpotBuyOrder", arg);
        }
        public async Task<HaasonlineClientResponse<string>> PlaceSpotSellOrder(string accountGuid, string primaryCoin, string secondaryCoin, decimal price, decimal amount, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceSpotSellOrder", arg);
        }

        public async Task<HaasonlineClientResponse<string>> PlaceEnterLongOrder(string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceLeverageEnterLongOrder", arg);
        }
        public async Task<HaasonlineClientResponse<string>> PlaceExitLongOrder(string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceLeverageExitLongOrder", arg);
        }
        public async Task<HaasonlineClientResponse<string>> PlaceEnterShortOrder(string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceLeverageEnterShortOrder", arg);
        }
        public async Task<HaasonlineClientResponse<string>> PlaceExitShortOrder(string accountGuid, string primaryCoin, string secondaryCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"primaryCoin", primaryCoin},
                {"secondaryCoin", secondaryCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return await ExecuteAsync<string>("/PlaceLeverageExitShortOrder", arg);
        }

        public async Task<HaasonlineClientResponse<bool>> CancelOrder(string accountGuid, string orderGuid)
        {
            var arg = new Dictionary<string, string>()
            {
                {"accountGuid", accountGuid},
                {"order", orderGuid},
            };

            return await ExecuteAsync<bool>("/CancelOrder", arg);
        }
        public async Task<HaasonlineClientResponse<bool>> CancelTemplate(string templateGuid)
        {
            var arg = new Dictionary<string, string>()
            {
                {"templateGuid", templateGuid},
            };

            return await ExecuteAsync<bool>("/CancelTemplate", arg);
        }

    }
}