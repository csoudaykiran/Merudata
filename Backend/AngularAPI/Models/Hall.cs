using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieTicketBookingApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularAPI.Models
{
    public class Hall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        [Required]
        public int HallId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TheatreId { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        [Required]
        public string TheatreName { get; set; }
    }
}
