using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAPI.Context; // Import your DbContext
using MovieTicketBookingApp.Models; // Import your City model

namespace MovieTicketBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly AppDbContext _context; // Your DbContext instance

        public CityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/City
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _context.Cities;
            return Ok(cities);
        }

        // GET: api/City/{id}
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = _context.Cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // POST: api/City
        [HttpPost]
        public IActionResult CreateCity([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cities.Add(city);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCity), new { id = city.CityId }, city);
        }

        // PUT: api/City/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] City city)
        {
            if (id != city.CityId)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/City/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var city = _context.Cities.Find(id);

            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
