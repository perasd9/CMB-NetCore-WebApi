using CombinationWebApp.Application.Event_Handlers.Base;

namespace CombinationWebApp.Application.Event_Bus.Base
{
    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : class;
        Task Subscribe<TEvent>(Func<TEvent, Task> handler)
            where TEvent : class;
    }
}
