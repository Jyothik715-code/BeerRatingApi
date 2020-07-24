using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jyothi.UserRatings.PunkApi.Client
{
    public class PunkProcessor
    {
        /// <summary>
        /// This method checks if Id exists in Punk API
        /// </summary>
        /// <param name="beerId">Beer Id</param>
        /// <returns>Beer details</returns>
        public static async Task<List<BeerModel>> GetBeer(int beerId)
        {
            string url = "";
            if (beerId > 0)
            {
                url = $"https://api.punkapi.com/v2/beers/{ beerId }";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //BeerModel beers = await response.Content.ReadAsAsync<BeerModel>();
                    List<BeerModel> beers = await response.Content.ReadAsAsync<List<BeerModel>>();

                    return beers;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// This method returns all beers from Punk API containing input string
        /// </summary>
        /// <param name="beerName">beer name search string</param>
        /// <returns>All beers containing request string</returns>
        public static async Task<List<BeerModel>> GetBeersContainingInput(string beerName)
        {
            string url = "";
            if (beerName!=null)
            {
                url = $"https://api.punkapi.com/v2/beers?beer_name={ beerName }";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<BeerModel> beers = await response.Content.ReadAsAsync<List<BeerModel>>();
                    return beers;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
