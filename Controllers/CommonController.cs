using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Common()
        {
            return Ok("Both User can Access");
        }
    }
}
