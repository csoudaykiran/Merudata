using AngularAPI.Context;
using AngularAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HallController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Hall
        [HttpGet]
        public IActionResult GetHalls()
        {
            var halls = _context.Halls.Include(h => h.City).ToList();
            return Ok(halls);
        }

        // GET: api/Hall/{id}
        [HttpGet("{id}")]
        public IActionResult GetHall(int id)
        {
            var hall = _context.Halls.Include(h => h.City).FirstOrDefault(h => h.HallId == id);

            if (hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        // GET: api/Hall/GetHallsByCities/{cityId}
        [HttpGet("GetHallsByCities/{cityId}")]
        public IActionResult GetHallsByCities(int cityId)
        {
            var halls = _context.Halls.Include(h => h.City).Where(h => h.CityId == cityId).ToList();
            return Ok(halls);
        }

        // POST: api/Hall
        [HttpPost]
        public IActionResult CreateHall([FromBody] Hall hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Halls.Add(hall);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHall), new { id = hall.HallId }, hall);
        }

        // PUT: api/Hall/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateHall(int id, [FromBody] Hall updatedHall)
        {
            if (id != updatedHall.HallId)
            {
                return BadRequest();
            }

            _context.Entry(updatedHall).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Hall/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHall(int id)
        {
            var hall = _context.Halls.Find(id);

            if (hall == null)
            {
                return NotFound();
            }

            _context.Halls.Remove(hall);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
