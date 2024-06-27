using CombinationWebApp.Application.Event_Bus.Base;
using CombinationWebApp.Core.Events.Users;
using Microsoft.AspNetCore.Mvc;

namespace CombinationWebApp.Presentation.Event_Controllers
{
    [ApiController]
    [Route("api/v2/user")]
    public class UserEventController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public UserEventController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var getAllUsersEvent = new GetAllUsersEvent();

            await _eventBus.Publish(getAllUsersEvent);

            var users = getAllUsersEvent.TaskCompletionSource.Task;

            return Ok(users);
        }
    }
}
