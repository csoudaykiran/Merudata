using System.ComponentModel.DataAnnotations;

namespace MovieTicketBookingApp.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        // Other city-related properties can be added here
    }
}
