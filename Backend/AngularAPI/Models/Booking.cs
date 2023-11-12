using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace AngularAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public string SelectedSeatsText { get; set; }
        public string SelectedDate { get; set; }
        public string SelectedTime { get; set; }
        public decimal TotalFare { get; set; }
    }
}
