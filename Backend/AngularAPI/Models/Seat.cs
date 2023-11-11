namespace AngularAPI.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatType { get; set; }
        public bool IsBooked { get; set; }
        public decimal Price { get; set; }
        public int CinemaHallId { get; set; }
        public string SeatName { get; set; }

        // Navigation property
        public CinemaHall CinemaHall { get; set; }
    }
}
