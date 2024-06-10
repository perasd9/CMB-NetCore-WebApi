using CombinationWebApp.Application.GrpcServices;
using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserServiceGrpc _userServiceGrpc;

        public UserController(UserServiceGrpc userServiceGrpc)
        {
            _userServiceGrpc = userServiceGrpc;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            //return Ok(await _userService.GetUsers());
            return Ok(await _userServiceGrpc.GetUsers());
        }
    }
}
