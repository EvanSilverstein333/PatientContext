using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.CommandHandlers;
using PatientManager.Contract.Events;
using ApplicationServices.CrossCuttingConcerns;
using ApplicationServices.EventHandlers;
using SimpleInjector;

namespace Infrastructure.AbstractFactories
{
    public class DomainEventProcessor : IDomainEventProcessor
    {
        private Container _container;

        public DomainEventProcessor(Container container)
        {
            _container = container;
        }

        public void Process<TEvent>(TEvent e) where TEvent : IDomainEvent
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(e.GetType());
            dynamic handlers = _container.GetAllInstances(handlerType);
            foreach(var handler in handlers)
            {
                handler.Handle((dynamic)e);

            }

        }
    }
}
