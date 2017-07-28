using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ControllerEvents;
using SimpleInjector;

namespace Infrastructure.AbstractFactories
{
    public class ControllerEventHandlerFactory : IControllerEventHandlerFactory
    {
        private Container _container;

        public ControllerEventHandlerFactory(Container container)
        {
            _container = container;
        }

        public IControllerEventHandler<TEvent> Resolve<TEvent>() where TEvent : IControllerEvent
        {
            var handler =_container.GetInstance<IControllerEventHandler<TEvent>>();
            return handler;

        }
    }
}
