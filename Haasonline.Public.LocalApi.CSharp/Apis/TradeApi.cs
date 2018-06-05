using System.Collections.Generic;
using System.Globalization;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class TradeApi : ApiBase
    {
        public TradeApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        public HaasonlineClientResponse<string> PlaceSpotBuyOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, decimal price, decimal amount, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceSpotBuyOrder", arg);
        }
        public HaasonlineClientResponse<string> PlaceSpotSellOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, decimal price, decimal amount, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceSpotSellOrder", arg);
        }

        public HaasonlineClientResponse<string> PlaceEnterLongOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceLeverageEnterLongOrder", arg);
        }
        public HaasonlineClientResponse<string> PlaceExitLongOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceLeverageExitLongOrder", arg);
        }
        public HaasonlineClientResponse<string> PlaceEnterShortOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceLeverageEnterShortOrder", arg);
        }
        public HaasonlineClientResponse<string> PlaceExitShortOrder(string accountGuid, EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, decimal price, decimal amount, decimal leverage, int? timeout = null)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"priceSourceName", priceSource.ToString()},
                {"primairyCoin", primairyCoin},
                {"secondairyCoin", secondairyCoin},
                {"contractName", contractName},
                {"price", price.ToString(CultureInfo.InvariantCulture)},
                {"amount", amount.ToString(CultureInfo.InvariantCulture)},
                {"leverage", leverage.ToString(CultureInfo.InvariantCulture)},
            };

            if (timeout.HasValue)
                arg["timeout"] = timeout.ToString();

            return Get<string>("/PlaceLeverageExitShortOrder", arg);
        }

        public HaasonlineClientResponse<bool> CancelOrder(string accountGuid, string orderGuid)
        {
            var arg = new Dictionary<string, string>()
            {
                {"account", accountGuid},
                {"order", orderGuid},
            };

            return Get<bool>("/CancelOrder", arg);
        }
        public HaasonlineClientResponse<bool> CancelTemplate(string templateGuid)
        {
            var arg = new Dictionary<string, string>()
            {
                {"templateGuid", templateGuid},
            };

            return Get<bool>("/CancelTemplate", arg);
        }

    }
}