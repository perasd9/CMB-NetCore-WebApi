using CombinationWebApp.Core.Model;

namespace CombinationWebApp.Core.Events.Users
{
    public class GetAllUsersEvent
    {
        public TaskCompletionSource<List<User>> TaskCompletionSource { get; set; }

        public GetAllUsersEvent()
        {
            TaskCompletionSource = new TaskCompletionSource<List<User>>();
        }

    }
}
