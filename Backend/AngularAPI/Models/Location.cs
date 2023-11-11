// Location.cs
using MovieTicketBookingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace AngularAPI.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        public string LocationName { get; set; }
        // Add other location-related properties as needed

        // Navigation property to link back to movies
        
    }
}
