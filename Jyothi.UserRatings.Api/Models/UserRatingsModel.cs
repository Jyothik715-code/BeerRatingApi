using System.ComponentModel.DataAnnotations;

namespace Jyothi.UserRatings.Api.Models
{
    /// <summary>
    /// Task # 1 - User Rating Model
    /// </summary>
    public class UserRatingsModel
    {
        //public int Id { get; set; }
        [Required]
        //[StringLength(1000, MinimumLength = 7)]
        public string Username { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [StringLength(2000)]
        public string Comments { get; set; }
        //TODO:Add Created Date field if required
    }
}