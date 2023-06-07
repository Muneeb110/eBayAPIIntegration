using eBayAPIIntegration.APIParams;
using eBayAPIIntegration.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eBayAPIIntegration
{
    public class GetItems
    {
        private string affiliateCampaignID;
        private string affiliateReferenceId;
        private string country;
        private string zip;
        private string deviceId;
        public GetItems(string _affiliateCampaignID, string _affiliateReferenceId, string _country,string _zip, string _deviceId)
        {
            this.affiliateCampaignID = _affiliateCampaignID;
            this.affiliateReferenceId = _affiliateReferenceId;
            this.country = _country;
            this.zip = _zip;
            this.deviceId = _deviceId;
        }

        private GetItems()
        {

        }

        public async Task<string> SearchItems(string URL,string keyword, int limit, int offset, Filter filter, bool auto_correct)
        {

            limit = limit <= 0 ? 100 : limit;
            limit = limit > 200 ? 100 : limit;

            URL += String.Format("?q={0}", keyword);
            URL += String.Format("&limit={0}&offset={1}", limit, offset);

            string sFilter = filter.ToString();
            if (filter != null && !string.IsNullOrEmpty(sFilter))
                URL += String.Format("&filter={0}", filter.ToString());

            if (auto_correct)
                URL += String.Format("&auto_correct={0}", keyword);

            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Format("Bearer {0}", GlobalTokenInfo.acess_token));
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-EBAY-C-ENDUSERCTX",
                string.Format("affiliateCampaignId={0},affiliateReferenceId={1},contextualLocation=country={2},zip={3},deviceId={4}",
                               affiliateCampaignID, affiliateReferenceId, country, zip, deviceId));
            var result = await client.GetAsync(URL);
            if (result.IsSuccessStatusCode)
            {
                var customerJsonString = await result.Content.ReadAsStringAsync();
                return customerJsonString;

            }
            else
            {
                var errorMsg = await result.Content.ReadAsStringAsync();
                return errorMsg;
            }
        }

    }
}
