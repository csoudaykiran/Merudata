using AngularAPI.Context;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings.ToList();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            // Add validation if needed

            // Set the selected date (assuming it's provided from the client)
            booking.SelectedDate = DateTime.Now;

            // Calculate total cost based on selected seats and other factors
            // This logic depends on your specific requirements

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] Booking updatedBooking)
        {
            // Add validation if needed

            var existingBooking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);

            if (existingBooking == null)
            {
                return NotFound();
            }

            existingBooking.CinemaHallId = updatedBooking.CinemaHallId;
            existingBooking.Username = updatedBooking.Username;
            existingBooking.SelectedDate = DateTime.Now; // Update the selected date if needed
            existingBooking.SelectedShow = updatedBooking.SelectedShow;
            existingBooking.SelectedSeats = updatedBooking.SelectedSeats;
            existingBooking.TotalCost = updatedBooking.TotalCost;

            // Update other properties as needed

            _context.SaveChanges();

            return Ok(existingBooking);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
