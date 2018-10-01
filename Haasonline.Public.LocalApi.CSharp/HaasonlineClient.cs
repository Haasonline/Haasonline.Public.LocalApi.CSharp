using System.Threading.Tasks;
using Haasonline.Public.LocalApi.CSharp.Apis;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp
{
    public class HaasonlineClient
    {
        public MarketDataApi MarketDataApi { get; }
        public AccountDataApi AccountDataApi { get; }
        public CustomBotApi CustomBotApi { get; }
        public TradeApi TradeApi { get; }
        public TradeBotApi TradeBotApi { get; }

        public HaasonlineClient(string ip, int port, string privateKey)
        {
            MarketDataApi = new MarketDataApi($"http://{ip}:{port}", privateKey);
            AccountDataApi = new AccountDataApi($"http://{ip}:{port}", privateKey);
            TradeApi = new TradeApi($"http://{ip}:{port}", privateKey);

            TradeBotApi = new TradeBotApi($"http://{ip}:{port}", privateKey);
            CustomBotApi = new CustomBotApi($"http://{ip}:{port}", privateKey);
        }

        public async Task<bool> TestCreditials()
        {
            var res = await MarketDataApi.GetEnabledPriceSources();
            return res.ErrorCode == EnumErrorCode.Success;
        }

    }
}
