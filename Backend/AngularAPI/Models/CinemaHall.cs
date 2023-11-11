using MovieTicketBookingApp.Models;

namespace AngularAPI.Models
{
    public class CinemaHall
    {
        public int CinemaHallId { get; set; }
        public string CinemaHallName { get; set; }
        
        public decimal TicketCost { get; set; }

        public int MovieId { get; set; }

        // Navigation property
        public Movie Movie { get; set; }
    }
}
