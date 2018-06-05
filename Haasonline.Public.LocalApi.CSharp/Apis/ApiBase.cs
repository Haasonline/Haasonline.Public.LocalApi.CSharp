using System.Collections.Generic;
using System.Net;
using Haasonline.Public.LocalApi.CSharp.DataObjects;
using Newtonsoft.Json;

namespace Haasonline.Public.LocalApi.CSharp.Apis
{
    public class ApiBase
    {
        protected string BaseUrl { get; set; }
        protected string PrivateKey { get; set; }

        public ApiBase(string baseUrl, string privateKey)
        {
            BaseUrl = baseUrl;
            PrivateKey = privateKey;
        }

        protected HaasonlineClientResponse<T> Get<T>(string endPoint, Dictionary<string, string> parameters = null)
        {
            var url = $"{BaseUrl}{endPoint}?secret={PrivateKey}";
            if (parameters != null)
                foreach (var parameter in parameters)
                    url += $"&{parameter.Key}={parameter.Value}";

            using (var client = new WebClient())
            {
                var response = client.DownloadString(url);
                return JsonConvert.DeserializeObject<HaasonlineClientResponse<T>>(response);
            }
        }
    }
}