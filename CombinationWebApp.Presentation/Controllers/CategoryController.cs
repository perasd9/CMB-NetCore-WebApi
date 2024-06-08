using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return NoContent();
        }
    }
}
