using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ControllerEvents;
using SimpleInjector;

namespace Infrastructure.AbstractFactories
{
    public class ControllerEventsRaiser : IControllerEventRaiser
    {
        //private readonly IServiceProvider _locator;
        //public static IControllerEventHandlerFactory _handlerFactory;

        private readonly Container _container;

        public ControllerEventsRaiser(Container container)
        {
            _container = container;
        }
        //internal ControllerEventsRaiser(IControllerEventHandlerFactory handlerFactory)
        //{
        //    _handlerFactory = handlerFactory;
        //    //_locator = locator;
        //}

        /// <summary>
        /// Raises the given domain event
        /// </summary>
        /// <typeparam name="TEvent">Domain event type</typeparam>
        /// <param name="ControllerEvent">Controller event</param>
        public void Raise<TEvent>(TEvent ControllerEvent) where TEvent : class, IControllerEvent
        {
            //Get all the handlers that handle events of type T
            //IHandles<T>[] allHandlers = (IHandles<T>[])_locator.GetService(typeof(IHandles<T>[]));
            //var handler = _handlerFactory.Resolve<T>();
            var handler = _container.GetInstance<IControllerEventHandler<TEvent>>();
            handler.Handle(ControllerEvent);

            //if (allHandlers != null && allHandlers.Length > 0)
            //    foreach (var handler in allHandlers)
            //        handler.Handle(ControllerEvent);
        }
    }
}
