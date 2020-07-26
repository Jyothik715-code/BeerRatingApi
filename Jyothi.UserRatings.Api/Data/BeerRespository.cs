using Jyothi.UserRatings.PunkApi.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyothi.UserRatings.Api.Data
{
    public class BeerRespository : IBeersRepository
    {
        public async Task<List<BeerModel>> GetBeer(int beerId)
        {
            return await PunkProcessor.GetBeer(beerId);
        }

        public async Task<List<BeerModel>> GetBeersByName(string name)
        {
            return await PunkProcessor.GetBeersContainingInput(name);
        }
    }
}