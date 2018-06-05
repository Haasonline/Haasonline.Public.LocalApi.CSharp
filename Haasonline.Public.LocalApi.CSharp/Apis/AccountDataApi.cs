using System.Collections.Generic;
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

        public HaasonlineClientResponse<Dictionary<string, string>> GetEnabledAccounts()
        {
            return Get<Dictionary<string, string>>("/GetEnabledAccounts");
        }

        public HaasonlineClientResponse<Dictionary<string, Wallet>> GetAllWallet()
        {
            var accounts = GetEnabledAccounts();
            if (!accounts.IsSuccess)
                return new HaasonlineClientResponse<Dictionary<string, Wallet>>();

            var result = new Dictionary<string, Wallet>();

            foreach (var account in accounts.Result)
                result[account.Key] = GetWallet(account.Key).Result;

            return new HaasonlineClientResponse<Dictionary<string, Wallet>>
            {
                Result = result,
                IsSuccess = true
            };
        }
        public HaasonlineClientResponse<Wallet> GetWallet(string accountGuid)
        {
            return Get<Wallet>("/GetWallet", new Dictionary<string, string>
            {
                {"account", accountGuid }
            });
        }

        public HaasonlineClientResponse<Dictionary<string, OrderContainer>> GetAllOpenOrders()
        {
            var accounts = GetEnabledAccounts();
            if (!accounts.IsSuccess)
                return new HaasonlineClientResponse<Dictionary<string, OrderContainer>>();

            var result = new Dictionary<string, OrderContainer>();

            foreach (var account in accounts.Result)
                result[account.Key] = GetOpenOrders(account.Key).Result;

            return new HaasonlineClientResponse<Dictionary<string, OrderContainer>>
            {
                Result = result,
                IsSuccess = true
            };
        }
        public HaasonlineClientResponse<OrderContainer> GetOpenOrders(string accountGuid)
        {
            return Get<OrderContainer>("/GetOpenOrders", new Dictionary<string, string>
            {
                {"account", accountGuid }
            });
        }

        public HaasonlineClientResponse<EnumOrderStatus> GetTemplateStatus(string templateGuid)
        {
            return Get<EnumOrderStatus>("/GetTemplateStatus", new Dictionary<string, string>
            {
                {"templateGuid", templateGuid }
            });
        }

    }
}