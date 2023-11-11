namespace AngularAPI.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CinemaHallId { get; set; }
        public string Username { get; set; }
        public DateTime SelectedDate { get; set; }
        public string SelectedShow { get; set; }
        public string SelectedSeats { get; set; }
        public decimal TotalCost { get; set; }

        // Navigation properties
        public CinemaHall CinemaHall { get; set; }
    }
}
