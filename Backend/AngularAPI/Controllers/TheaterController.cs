using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAPI.Context; // Update the namespace
using AngularAPI.Models;

namespace MovieTicketBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TheaterController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Theater
        [HttpGet]
        public IActionResult GetTheaters()
        {
            var theaters = _context.Theater;
            return Ok(theaters);
        }

        // GET: api/Theater/{id}
        [HttpGet("{id}")]
        public IActionResult GetTheater(int id)
        {
            var theater = _context.Theater.Find(id);

            if (theater == null)
            {
                return NotFound();
            }

            return Ok(theater);
        }

        // POST: api/Theater
        [HttpPost]
        public IActionResult CreateTheater([FromBody] Theater theater)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Theater.Add(theater);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTheater), new { id = theater.TheaterId }, theater);
        }

        // PUT: api/Theater/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTheater(int id, [FromBody] Theater theater)
        {
            if (id != theater.TheaterId)
            {
                return BadRequest();
            }

            _context.Entry(theater).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Theater/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            var theater = _context.Theater.Find(id);

            if (theater == null)
            {
                return NotFound();
            }

            _context.Theater.Remove(theater);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
