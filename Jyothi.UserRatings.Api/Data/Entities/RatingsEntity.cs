using Jyothi.UserRatings.Api.Models;

namespace Jyothi.UserRatings.Api.Data.Entities
{
    /// <summary>
    /// Rating Entity for serializing database Json 
    /// </summary>
    public class RatingsEntity
    {
        public int Id { get; set; }
        public UserRatingsModel UserRatings { get; set; }
        public int BeerId { get; set; }
    }
}