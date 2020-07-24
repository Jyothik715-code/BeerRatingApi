using System.Collections.Generic;

namespace Jyothi.UserRatings.Api.Models
{
    /// <summary>
    /// Task # 2 - Output object to return beer along with ratings details
    /// </summary>
    public class BeersReviewsModel //create Base model and move common properties to base Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<UserRatingsModel> UserRatings { get; set; }
    }
}