using System.Collections.Generic;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.MarketData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class MarketDataApi : ApiBase
    {
        public MarketDataApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }


        public HaasonlineClientResponse<List<string>> GetAllPriceSources()
        {
            return Get<List<string>>("/GetAllPriceSources");
        }
        public HaasonlineClientResponse<List<string>> GetEnabledPriceSources()
        {
            return Get<List<string>>("/GetEnabledPriceSources");
        }

        public HaasonlineClientResponse<List<Market>> GetAllPriceMarkets()
        {
            return Get<List<Market>>("/GetAllPriceMarkets");
        }

        public HaasonlineClientResponse<List<Market>> GetPriceMarkets(EnumPriceSource priceSource)
        {
            return Get<List<Market>>("/GetPriceMarkets", new Dictionary<string, string>
            {
                { "priceSourceName", priceSource.ToString() }
            });
        }

        public HaasonlineClientResponse<PriceTick> GetPriceTicker(EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName)
        {
            return Get<PriceTick>("/GetPriceTicker", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primairyCoin", primairyCoin },
                {"secondairyCoin", secondairyCoin },
                {"contractName", contractName },
            });
        }
        public HaasonlineClientResponse<PriceTick> GetPriceTicker(Market market)
        {
            return GetPriceTicker(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<PriceTick> GetMinutePriceTicker(EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName)
        {
            return Get<PriceTick>("/GetMinutePriceTicker", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primairyCoin", primairyCoin },
                {"secondairyCoin", secondairyCoin },
                {"contractName", contractName },
            });
        }
        public HaasonlineClientResponse<PriceTick> GetMinutePriceTicker(Market market)
        {
            return GetMinutePriceTicker(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<TradeContainer> GetLastTrades(EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName)
        {
            return Get<TradeContainer>("/GetLastTrades", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primairyCoin", primairyCoin },
                {"secondairyCoin", secondairyCoin },
                {"contractName", contractName },
            });
        }
        public HaasonlineClientResponse<TradeContainer> GetLastTrades(Market market)
        {
            return GetLastTrades(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<Orderbook> GetOrderbook(EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName)
        {
            return Get<Orderbook>("/GetOrderbook", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primairyCoin", primairyCoin },
                {"secondairyCoin", secondairyCoin },
                {"contractName", contractName }
            });
        }
        public HaasonlineClientResponse<Orderbook> GetOrderbook(Market market)
        {
            return GetOrderbook(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public HaasonlineClientResponse<List<PriceTick>> GetHistory(EnumPriceSource priceSource, string primairyCoin, string secondairyCoin, string contractName, int interval, int depth)
        {
            return Get<List<PriceTick>>("/GetHistory", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primairyCoin", primairyCoin },
                {"secondairyCoin", secondairyCoin },
                {"contractName", contractName },
                {"interval", interval.ToString() },
                {"depth", depth.ToString() },
            });
        }
        public HaasonlineClientResponse<List<PriceTick>> GetHistory(Market market, int interval, int depth)
        {
            return GetHistory(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName, interval, depth);
        }

    }
}