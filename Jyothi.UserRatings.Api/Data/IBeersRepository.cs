using Jyothi.UserRatings.PunkApi.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyothi.UserRatings.Api.Data
{
    public interface IBeersRepository
    {
        Task<List<BeerModel>> GetBeersByName(string name);

        Task<List<BeerModel>> GetBeer(int beerId);
    }
}
