using AngularAPI.Context;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaHallController :ControllerBase
    {
        private readonly AppDbContext _context;

        public CinemaHallController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCinemaHalls()
        {
            var cinemaHalls = _context.CinemaHalls.ToList();
            return Ok(cinemaHalls);
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaHall(int id)
        {
            var cinemaHall = _context.CinemaHalls.FirstOrDefault(ch => ch.CinemaHallId == id);

            if (cinemaHall == null)
            {
                return NotFound();
            }

            return Ok(cinemaHall);
        }

        [HttpPost]
        public IActionResult CreateCinemaHall([FromBody] CinemaHall cinemaHall)
        {
            // Add validation if needed

            _context.CinemaHalls.Add(cinemaHall);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCinemaHall), new { id = cinemaHall.CinemaHallId }, cinemaHall);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinemaHall(int id, [FromBody] CinemaHall updatedCinemaHall)
        {
            // Add validation if needed

            var existingCinemaHall = _context.CinemaHalls.FirstOrDefault(ch => ch.CinemaHallId == id);

            if (existingCinemaHall == null)
            {
                return NotFound();
            }

            existingCinemaHall.CinemaHallName = updatedCinemaHall.CinemaHallName;
            existingCinemaHall.MovieId = updatedCinemaHall.MovieId;
            existingCinemaHall.TicketCost = updatedCinemaHall.TicketCost;
            // Update other properties as needed

            _context.SaveChanges();

            return Ok(existingCinemaHall);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinemaHall(int id)
        {
            var cinemaHall = _context.CinemaHalls.FirstOrDefault(ch => ch.CinemaHallId == id);

            if (cinemaHall == null)
            {
                return NotFound();
            }

            _context.CinemaHalls.Remove(cinemaHall);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
