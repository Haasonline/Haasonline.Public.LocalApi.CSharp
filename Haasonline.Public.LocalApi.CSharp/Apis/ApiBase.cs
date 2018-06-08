using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Newtonsoft.Json;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class ApiBase
    {
        private HMACSHA256 _hmac;
        protected string BaseUrl { get; set; }
        protected string PrivateKey { get; set; }

        public ApiBase(string baseUrl, string privateKey)
        {
            BaseUrl = baseUrl;
            PrivateKey = privateKey;

            _hmac = new HMACSHA256(Encoding.UTF8.GetBytes(privateKey));
        }

        protected async Task<HaasonlineClientResponse<T>> ExecuteAsync<T>(string endPoint, Dictionary<string, string> parameters = null, bool authorize = true)
        {
            var url = $"{BaseUrl}{endPoint}";

            if (parameters == null)
                parameters = new Dictionary<string, string>();

            var parametersString = string.Empty;
            foreach (var parameter in parameters.OrderBy(c => c.Key))
                parametersString += $"&{parameter.Key}={parameter.Value}";

            parametersString = parametersString.TrimStart('&');

            if (!string.IsNullOrEmpty(parametersString))
                url += $"?{parametersString}";

            Console.WriteLine(parametersString);

            if (authorize)
            {
                var hash = _hmac.ComputeHash(Encoding.UTF8.GetBytes(parametersString));
                var sig = BitConverter.ToString(hash).Replace("-", "");

                if (!parameters.Any())
                    url += "?";
                else
                    url += "&";

                url += $"sig={sig}";
            }

            using (var client = new WebClient())
            {
                var response = await client.DownloadStringTaskAsync(url);
                return JsonConvert.DeserializeObject<HaasonlineClientResponse<T>>(response);
            }
        }
    }
}