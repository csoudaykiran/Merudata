// Theater.cs

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AngularAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularAPI.Models
{
    public class Theater
    {
        [Key]
        public int TheaterId { get; set; }

        [Required]
        [StringLength(100)]
        public string TheaterName { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        // Foreign key for City
        public int CityID { get; set; }

        // Navigation property to City
        [ForeignKey("CityID")]
        public City City { get; set; }

        // Other theater-related properties can be added here
    }
}
