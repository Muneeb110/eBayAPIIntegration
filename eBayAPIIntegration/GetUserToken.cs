using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eBayAPIIntegration
{
    public class GetUserToken
    {
        public async Task<TokenInfo> GetAccessToken(string URL, string ClientID, string ClientSecret)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", ClientID, ClientSecret));
            var encodedCreds = Convert.ToBase64String(plainTextBytes);

            var client = new HttpClient();
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            nvc.Add(new KeyValuePair<string, string>("scope", "https://api.ebay.com/oauth/api_scope"));
            var msg = new HttpRequestMessage(HttpMethod.Post, URL) { Content = new FormUrlEncodedContent(nvc) };
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Format("Basic {0}", encodedCreds));
            var result = await client.SendAsync(msg);
            if (result.IsSuccessStatusCode)
            {
                var customerJsonString = await result.Content.ReadAsStringAsync();
                TokenInfo info = JsonConvert.DeserializeObject<TokenInfo>(custome‌​rJsonString);
                info.expires_at = DateTime.Now.AddMinutes(110);

                GlobalTokenInfo.expires_at = DateTime.Now.AddMinutes(110);
                GlobalTokenInfo.acess_token = info.access_token;
                return info;

            }
            else
            {
                var errorMsg = await result.Content.ReadAsStringAsync();
                return null;
            }
        }
    }
}
