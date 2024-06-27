using CombinationWebApp.Application.Event_Handlers.Base;
using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;
using CombinationWebApp.Core.Events.Users;

namespace CombinationWebApp.Application.Event_Handlers
{
    public class GetAllUsersEventHandler : IEventHandler<GetAllUsersEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(GetAllUsersEvent @event)
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();
            
            @event.TaskCompletionSource.SetResult(users);

            return Task.CompletedTask;
        }
    }
}
