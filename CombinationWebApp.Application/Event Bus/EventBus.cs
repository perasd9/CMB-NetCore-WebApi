using CombinationWebApp.Application.Event_Bus.Base;
using CombinationWebApp.Application.Event_Handlers;
using CombinationWebApp.Application.Event_Handlers.Base;
using CombinationWebApp.Core.Events.Users;

namespace CombinationWebApp.Application.Event_Bus
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Func<object, Task>>> _handlers = new();
        private readonly IServiceProvider _serviceProvider;

        public EventBus(IServiceProvider serviceProvider, IEventHandler<GetAllUsersEvent> eh) 
        {
            _serviceProvider = serviceProvider;
            Subscribe<GetAllUsersEvent>(eh.Handle);
        }

        public Task Publish<TEvent>(TEvent @event) where TEvent : class
        {
            //or just you can add genrics for TEvent and have type
            var eventType = @event.GetType();

            if (_handlers.ContainsKey(eventType))
            {
                foreach(var item in _handlers[eventType])
                {
                    //var handler = _serviceProvider.GetService(item) as IEventHandler<TEvent>;
                    item(@event);
                }
            }

            return Task.CompletedTask;
        }

        public Task Subscribe<TEvent>(Func<TEvent, Task> handler)
            where TEvent : class
        {
            var eventType = typeof(TEvent);

            _handlers.Add(eventType, null);

            if (_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<Func<object, Task>>();
            }
            _handlers[eventType].Add(e => handler((TEvent)e));

            return Task.CompletedTask;
        }
    }
}
