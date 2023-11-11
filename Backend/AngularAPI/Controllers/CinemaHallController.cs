using AngularAPI.Context;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        

        [HttpGet("getmoviesbycities/{cityId}")]
        public IActionResult GetMoviesByCities(int cityId)
        {
            var movies = _context.Movies.Where(m => m.CityId == cityId).ToList();
            return Ok(movies);
        }

        


        [HttpPost("addseats/{cinemaHallId}")]
        public IActionResult AddSeats(int cinemaHallId, [FromBody] List<Seat> seats)
        {
            var cinemaHall = _context.CinemaHalls.FirstOrDefault(ch => ch.CinemaHallId == cinemaHallId);

            if (cinemaHall == null)
            {
                return NotFound();
            }

            foreach (var seat in seats)
            {
                seat.CinemaHallId = cinemaHallId;
                _context.seats.Add(seat);
            }

            _context.SaveChanges();

            return Ok(seats);
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
