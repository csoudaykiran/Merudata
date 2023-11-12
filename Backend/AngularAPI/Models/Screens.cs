using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularAPI.Models
{
    public class Screens
    {
        [Key] // Add this attribute to specify the primary key
        public int ScreenId { get; set; }

        public string ScreenName { get; set; }

        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int TheaterId { get; set; }

        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }

        public List<Seating> seatings { get; set; }

    }
}
