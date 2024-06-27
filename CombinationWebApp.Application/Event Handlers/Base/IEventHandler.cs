namespace CombinationWebApp.Application.Event_Handlers.Base
{
    public interface IEventHandler<TEvent> where TEvent : class
    {
        Task Handle(TEvent @event);
    }
}
