using System.Collections.Generic;
using System.Threading.Tasks;
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


        public async Task<HaasonlineClientResponse<List<string>>> GetAllPriceSources()
        {
            return await ExecuteAsync<List<string>>("/GetAllPriceSources", authorize: false);
        }
        public async Task<HaasonlineClientResponse<List<string>>> GetEnabledPriceSources()
        {
            return await ExecuteAsync<List<string>>("/GetEnabledPriceSources", authorize: false);
        }

        public async Task<HaasonlineClientResponse<List<Market>>> GetAllPriceMarkets()
        {
            return await ExecuteAsync<List<Market>>("/GetAllPriceMarkets", authorize: false);
        }

        public async Task<HaasonlineClientResponse<List<Market>>> GetPriceMarkets(EnumPriceSource priceSource)
        {
            return await ExecuteAsync<List<Market>>("/GetPriceMarkets", new Dictionary<string, string>
            {
                { "priceSourceName", priceSource.ToString() }
            }, authorize: false);
        }

        public async Task<HaasonlineClientResponse<PriceTick>> GetPriceTicker(EnumPriceSource priceSource, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await ExecuteAsync<PriceTick>("/GetPriceTicker", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
            }, authorize: false);
        }
        public async Task<HaasonlineClientResponse<PriceTick>> GetPriceTicker(Market market)
        {
            return await GetPriceTicker(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<PriceTick>> GetMinutePriceTicker(EnumPriceSource priceSource, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await ExecuteAsync<PriceTick>("/GetMinutePriceTicker", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
            }, authorize: false);
        }
        public async Task<HaasonlineClientResponse<PriceTick>> GetMinutePriceTicker(Market market)
        {
            return await GetMinutePriceTicker(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<TradeContainer>> GetLastTrades(EnumPriceSource priceSource, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await ExecuteAsync<TradeContainer>("/GetLastTrades", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
            }, authorize: false);
        }
        public async Task<HaasonlineClientResponse<TradeContainer>> GetLastTrades(Market market)
        {
            return await GetLastTrades(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<Orderbook>> GetOrderbook(EnumPriceSource priceSource, string primaryCoin, string secondaryCoin, string contractName)
        {
            return await ExecuteAsync<Orderbook>("/GetOrderbook", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName }
            }, authorize: false);
        }
        public async Task<HaasonlineClientResponse<Orderbook>> GetOrderbook(Market market)
        {
            return await GetOrderbook(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName);
        }

        public async Task<HaasonlineClientResponse<List<PriceTick>>> GetHistory(EnumPriceSource priceSource, string primaryCoin, string secondaryCoin, string contractName, int interval, int depth)
        {
            return await ExecuteAsync<List<PriceTick>>("/GetHistory", new Dictionary<string, string>
            {
                {"priceSourceName", priceSource.ToString() },
                {"primaryCoin", primaryCoin },
                {"secondaryCoin", secondaryCoin },
                {"contractName", contractName },
                {"interval", interval.ToString() },
                {"depth", depth.ToString() },
            }, authorize: false);
        }
        public async Task<HaasonlineClientResponse<List<PriceTick>>> GetHistory(Market market, int interval, int depth)
        {
            return await GetHistory(market.PriceSource, market.PrimaryCurrency, market.SecondaryCurrency, market.ContractName, interval, depth);
        }

    }
}