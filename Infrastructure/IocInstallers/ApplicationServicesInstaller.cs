using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using ApplicationServices.CommandHandlers;
using ApplicationServices.QueryHandlers;
using ApplicationServices.CrossCuttingConcerns;
using ApplicationServices.EventHandlers;
using Infrastructure.AbstractFactories;
using ApplicationServices.MessageBus.QueryDispatcher;
using ApplicationServices.MessageBus.CommandDispatcher;

namespace Infrastructure.IocInstallers
{
    static class ApplicationServicesInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {
            //Commands
            _simpleContainer.Register(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies(), Lifestyle.Transient);
            _simpleContainer.RegisterSingleton<ICommandService>(new PatientManagerCommandProcessor());
            _simpleContainer.RegisterSingleton<PostCommitRegistratorImpl>();
            _simpleContainer.RegisterSingleton<IPostCommitRegistrator>(() => _simpleContainer.GetInstance<PostCommitRegistratorImpl>());

            //Queries
            _simpleContainer.Register(typeof(IQueryHandler<,>), AppDomain.CurrentDomain.GetAssemblies(), Lifestyle.Transient);
            _simpleContainer.RegisterSingleton<IQueryService>(new PatientManagerQueryProcessor());

            // CommandDecorators
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(PerformanceMetricsCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnRequestCompletedCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ToWcfFaultTranslatorCommandHandlerDecorator<>));


            //QueryDecorators
            _simpleContainer.RegisterDecorator(typeof(IQueryHandler<,>), typeof(CachingQueryHandlerDecorator<,>));


            //Events
            _simpleContainer.RegisterCollection(typeof(IDomainEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton<DomainEventStoreImpl>();
            _simpleContainer.RegisterSingleton<IDomainEventStore>(() => _simpleContainer.GetInstance<DomainEventStoreImpl>());
            _simpleContainer.Register<IDomainEventProcessor, DomainEventProcessor>();
            _simpleContainer.Register<IExternalMessagePublisher, ExternalMessagePublisher>();


            ////DomainEvents
            //_simpleContainer.RegisterCollection(typeof(IDomainEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            //_simpleContainer.RegisterSingleton<IDomainEventProcessor>(new DomainEventProcessor(_simpleContainer));
            //_simpleContainer.RegisterSingleton<DomainEventStore>();
            //_simpleContainer.RegisterSingleton<IDomainEventStore>(() => _simpleContainer.GetInstance<DomainEventStore>());

        }
    }
}
