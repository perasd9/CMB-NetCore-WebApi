using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/transaction")]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            return NoContent();
        }

    }
}
