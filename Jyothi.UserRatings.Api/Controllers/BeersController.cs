using Jyothi.UserRatings.Api.Utilities;
using Jyothi.UserRatings.Api.Data.Entities;
using Jyothi.UserRatings.Api.Models;
using Jyothi.UserRatings.PunkApi.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Jyothi.UserRatings.Api.Controllers
{
    public class BeersController : ApiController
    {
        JsonUtility jsonUtil;
        public BeersController()
        {
            //InitializeClient
            jsonUtil = new JsonUtility(); //TODO: Will move this to Autofac DI
        }
        /// <summary>
        /// Task # 2 - Get top 25 beers matching input string from Punk API along with rating details
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(string name)//TODO:Add parameter to increase result limit
        {
            try
            {
                //1. Validate Model State
                if (ModelState.IsValid)
                {
                    List<BeersReviewsModel> results = new List<BeersReviewsModel>();
                    List<RatingsEntity> dbRatings = null;

                    //2. Get top 25 beers from Punk API that matches input string
                    var beers = await PunkProcessor.GetBeersContainingInput(name);
                    //3. Return Not Found Exception
                    if (beers == null) return NotFound();

                    //4. If Punk API returns results, Add rating details from json
                    if (beers.Any()) 
                    {
                        //5. Get Json ratings
                        dbRatings = JsonConvert.DeserializeObject<List<RatingsEntity>>(jsonUtil.Read("database.json", "Data"));//Get all ratings

                        //6. Assign ratings for each beer
                        foreach (var beer in beers)
                        {
                            //TODO: Use AutoMapper 
                            results.Add(
                                new BeersReviewsModel
                                {
                                    Id = beer.Id,
                                    Name = beer.Name,
                                    Description = beer.Description,
                                    UserRatings = dbRatings?.Where(x => x.BeerId == beer.Id).Select(x => x.UserRatings).ToList(),
                                });
                        }

                        //7. Return all matching beers with ratings
                        return Ok(results);
                    }
                }
            }
            catch (Exception ex)
            {
                //Return Internal Server Error for unhandled exceptions
                return InternalServerError(ex);
            }

            //Return Bad Request with error messages for invalid inputs
            return BadRequest();
        }
    }
}