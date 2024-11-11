using LocationTracker.Data;
using LocationTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LocationController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> SaveLocation(Location location)
        {
            _appDbContext.Locations.Add(location);
            await _appDbContext.SaveChangesAsync();
            return Ok(location);
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _appDbContext.Locations.ToListAsync();
            return Ok(locations);
        }
    }
}
