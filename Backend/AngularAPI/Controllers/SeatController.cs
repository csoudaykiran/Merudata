using AngularAPI.Context;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AngularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSeats()
        {
            var seats = _context.seats.ToList();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public IActionResult GetSeat(int id)
        {
            var seat = _context.seats.FirstOrDefault(s => s.SeatId == id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        [HttpPost]
        public IActionResult CreateSeat([FromBody] Seat seat)
        {
            // Add validation if needed

            _context.seats.Add(seat);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSeat), new { id = seat.SeatId }, seat);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeat(int id, [FromBody] Seat updatedSeat)
        {
            // Add validation if needed

            var existingSeat = _context.seats.FirstOrDefault(s => s.SeatId == id);

            if (existingSeat == null)
            {
                return NotFound();
            }

            existingSeat.SeatType = updatedSeat.SeatType;
            existingSeat.IsBooked = updatedSeat.IsBooked;
            existingSeat.Price = updatedSeat.Price;
            existingSeat.CinemaHallId = updatedSeat.CinemaHallId;
            existingSeat.SeatName = updatedSeat.SeatName;
            // Update other properties as needed

            _context.SaveChanges();

            return Ok(existingSeat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeat(int id)
        {
            var seat = _context.seats.FirstOrDefault(s => s.SeatId == id);

            if (seat == null)
            {
                return NotFound();
            }

            _context.seats.Remove(seat);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
