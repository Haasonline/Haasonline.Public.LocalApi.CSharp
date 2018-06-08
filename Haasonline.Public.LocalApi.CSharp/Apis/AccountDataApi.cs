using System.Collections.Generic;
using System.Threading.Tasks;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Haasonline.Public.LocalApi.CSharp.DataObjects.AccountData;
using Haasonline.Public.LocalApi.CSharp.Enums;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class AccountDataApi : ApiBase
    {
        public AccountDataApi(string baseUrl, string privateKey) : base(baseUrl, privateKey)
        {
        }

        public async Task<HaasonlineClientResponse<Dictionary<string, string>>> GetEnabledAccounts()
        {
            return await ExecuteAsync<Dictionary<string, string>>("/GetEnabledAccounts");
        }

        public async Task<HaasonlineClientResponse<Dictionary<string, Wallet>>> GetAllWallet()
        {
            var accounts = await GetEnabledAccounts();
            if (accounts.ErrorCode != EnumErrorCode.Success)
                return new HaasonlineClientResponse<Dictionary<string, Wallet>>();

            var result = new Dictionary<string, Wallet>();

            foreach (var account in accounts.Result)
            {
                var res = await GetWallet(account.Key);
                result[account.Key] = res.Result;
            }

            return new HaasonlineClientResponse<Dictionary<string, Wallet>>
            {
                Result = result,
                ErrorCode = EnumErrorCode.Success
            };
        }
        public async Task<HaasonlineClientResponse<Wallet>> GetWallet(string accountGuid)
        {
            return await ExecuteAsync<Wallet>("/GetWallet", new Dictionary<string, string>
            {
                {"accountGuid", accountGuid }
            });
        }

        public async Task<HaasonlineClientResponse<Dictionary<string, OrderContainer>>> GetAllOpenOrders()
        {
            var accounts = await GetEnabledAccounts();
            if (accounts.ErrorCode != EnumErrorCode.Success)
                return new HaasonlineClientResponse<Dictionary<string, OrderContainer>>();

            var result = new Dictionary<string, OrderContainer>();

            foreach (var account in accounts.Result)
            {
                var res = await GetOpenOrders(account.Key);
                result[account.Key] = res.Result;
            }

            return new HaasonlineClientResponse<Dictionary<string, OrderContainer>>
            {
                Result = result,
                ErrorCode = EnumErrorCode.Success
            };
        }
        public async Task<HaasonlineClientResponse<OrderContainer>> GetOpenOrders(string accountGuid)
        {
            return await ExecuteAsync<OrderContainer>("/GetOpenOrders", new Dictionary<string, string>
            {
                {"accountGuid", accountGuid }
            });
        }

        public async Task<HaasonlineClientResponse<EnumOrderStatus>> GetTemplateStatus(string templateGuid)
        {
            return await ExecuteAsync<EnumOrderStatus>("/GetTemplateStatus", new Dictionary<string, string>
            {
                {"templateGuid", templateGuid }
            });
        }

    }
}