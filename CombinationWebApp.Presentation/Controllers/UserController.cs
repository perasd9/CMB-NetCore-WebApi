using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return NoContent();
        }
    }
}
