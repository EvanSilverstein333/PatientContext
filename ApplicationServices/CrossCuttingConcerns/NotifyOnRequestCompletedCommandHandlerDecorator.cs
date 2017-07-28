using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;
using ApplicationServices.CommandHandlers;

namespace ApplicationServices.CrossCuttingConcerns
{
    public class NotifyOnRequestCompletedCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private ICommandHandler<T> _decorated;
        private readonly PostCommitRegistratorImpl _registrator;
        private DomainEventStoreImpl _eventStore;
        private IDomainEventProcessor _eventProcessor;
        private IExternalMessagePublisher _externalPublisher;

        public NotifyOnRequestCompletedCommandHandlerDecorator(ICommandHandler<T> cmdHandler, PostCommitRegistratorImpl registrator, DomainEventStoreImpl eventStore, IDomainEventProcessor eventProcessor, IExternalMessagePublisher externalPublisher)
        {
            _decorated = cmdHandler;
            _registrator = registrator;
            _eventStore = eventStore;
            _eventProcessor = eventProcessor;
            _externalPublisher = externalPublisher;

        }

        public void Execute(T command)
        {
            
            try
            {
                _decorated.Execute(command);
                DispatchEvents();
            }
            catch
            {
                throw;
            }
            finally
            {
               
                _registrator.Reset();
                _eventStore.ClearEvents();
                
            }


        }

        private void DispatchEvents()
        {
            _registrator.ExecuteActions(); // callback to controller ** needs to be called first
            var events = _eventStore.GetEventQueue();
            foreach (var e in events)
            {
                _eventProcessor.Process(e);
                _externalPublisher.Publish(e);
            }
        }

    }
}
