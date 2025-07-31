using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JWTAuthImplement.Models;

namespace JWTAuthImplement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureEndpointController : ControllerBase
    {
        [HttpGet("get-data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok(new
            {
                Message = "This is a secure endpoint!",
                Username = User.Identity?.Name,
            });
        }
    }
}
