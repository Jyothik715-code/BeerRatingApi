using Jyothi.UserRatings.Api.Utilities;
using Jyothi.UserRatings.Api.Data.Entities;
using Jyothi.UserRatings.Api.Filters;
using Jyothi.UserRatings.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Jyothi.UserRatings.Api.Data;

namespace Jyothi.UserRatings.Api.Controllers
{
    //[RoutePrefix("api/ratings")]
    public class RatingsController : ApiController
    {
        IBeersRepository _beerRepository;
        IJsonUtility _jsonUtility;

        public RatingsController(IBeersRepository beerRepository, IJsonUtility jsonUtility)
        {
            _beerRepository = beerRepository;
            _jsonUtility = jsonUtility;
        }

        /// <summary>
        /// Task # 1 - Save Ratings details to database.json
        /// </summary>
        /// <param name="id">Beer Id</param>
        /// <param name="userRatings">Rating details</param>
        /// <returns></returns>
        [CustomActionFilter]
        public async Task<IHttpActionResult> Post(int id, UserRatingsModel userRatings)
        {
            try
            {
                //1. Validate Model State
                if (ModelState.IsValid)
                {
                    List<BeersReviewsModel> results = new List<BeersReviewsModel>();
                    List<RatingsEntity> dbRatings = null;

                    //2. Validate if beer exisis in Punk API
                    var beer = await _beerRepository.GetBeer(id);
                    if (beer == null) return NotFound();

                    //3. If ID exists in Punk API, add rating and save to database.json
                    if (beer.Any())
                    {
                        //4. Read Json and increment Rating Id
                        dbRatings = JsonConvert.DeserializeObject<List<RatingsEntity>>(_jsonUtility.Read("database.json", "Data"));
                        var count = dbRatings?.Max(x => x.Id);
                        count = count == null ? 1 : count + 1;

                        //5. Create Ratings Entity to be saved to json
                        //   Beer ID mapping to user rating request before saving to json
                        var ratings = new RatingsEntity
                        {
                            Id = count.Value,
                            UserRatings = userRatings,
                            BeerId = id
                        };

                        //6. Add to json entity
                        dbRatings.Add(ratings);

                        //7. Write and Save to database.json
                        string dbRatingsJson = JsonConvert.SerializeObject(dbRatings);
                        _jsonUtility.Write("database.json", "Data", dbRatingsJson);

                        //8. Return Success with rating info
                        return Ok(ratings);
                    }

                }
            }
            catch (Exception ex)
            {
                //Return Internal Server Error for unhandled exceptions
                return InternalServerError(ex);
            }

            //Return Bad Request with error messages for invalid inputs
            return BadRequest(ModelState);
        }
    }
}
