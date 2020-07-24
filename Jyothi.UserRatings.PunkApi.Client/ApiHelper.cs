using System.Net.Http;
using System.Net.Http.Headers;

namespace Jyothi.UserRatings.PunkApi.Client
{
    /// <summary>
    /// API Helper class to create client instance
    /// </summary>
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        /// <summary>
        /// Initialize Client
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
