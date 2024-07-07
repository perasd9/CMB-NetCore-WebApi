using CombinationWebApp.Application.Services;
using CombinationWebApp.Core.Model;
using CombinationWebApp.DataTransferModel.User;
using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userServiceGrpc)
        {
            _userService = userServiceGrpc;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
                List<User> users = await _userService.GetUsers();
            List<GetUserDTO> usersDTO = users.Select(user => new GetUserDTO
            {
                Username = user.Username,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address
            }).ToList();

            return Ok(usersDTO);
        }
    }
}
