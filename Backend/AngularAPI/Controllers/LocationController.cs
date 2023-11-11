// LocationController.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAPI.Context;
using AngularAPI.Models;

namespace AngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var locations = await _context.Locations.ToListAsync();

            if (locations == null || locations.Count == 0)
            {
                return NotFound(new { Message = "No locations found" });
            }

            return Ok(locations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocation([FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest("Invalid request. Location object is null.");
            }

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocations), new { id = location.LocationID }, location);
        }
    }
}
