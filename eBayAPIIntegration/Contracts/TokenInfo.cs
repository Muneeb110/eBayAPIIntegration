using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace eBayAPIIntegration
{
    /// <summary>
    /// This class is for deserializing token information into it
    /// </summary>
    public class TokenInfo
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public DateTime expires_at { get; set; }
    }

    /// <summary>
    /// Global Token Infomartion is to be stored in this class - this is a recommended approach to store tokens in static members
    /// </summary>
    public static class GlobalTokenInfo
    {
        public static string acess_token{get;set;}
        public static DateTime expires_at { get; set; }
    }
}
