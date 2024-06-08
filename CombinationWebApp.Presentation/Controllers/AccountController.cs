using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return NoContent();
        }
    }
}
