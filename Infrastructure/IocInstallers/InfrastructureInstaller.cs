using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublisherSubscriberService;
using SimpleInjector;
//using System.Data.Entity;
using AutoMapper;
using log4net;
using ApplicationServices.CrossCuttingConcerns;
using Infrastructure.AbstractFactories;
using FluentValidation;
using ApplicationServices.MessageBus.QueryDispatcher;
using ApplicationServices.Validation.Validators;
using System.Runtime.Caching;
using Infrastructure.Mappers;
//using FinanceManager.Contract.Services;


namespace Infrastructure.IocInstallers
{
    static class InfrastructureInstaller
    {
        public static void RegisterServices(Container _simpleContainer)
        {
            _simpleContainer.RegisterSingleton<MapperConfiguration>(AutoMapperConfiguration.MapConfig);
            _simpleContainer.RegisterSingleton<ObjectCache>(new MemoryCache("MyCache"));
            _simpleContainer.RegisterSingleton<ILog>(Bootstrapper.Logger);
            _simpleContainer.Register<ILogger, Logger>();

            //Validators
            _simpleContainer.Register(typeof(IValidator<>), AppDomain.CurrentDomain.GetAssemblies(), Lifestyle.Singleton);
            _simpleContainer.RegisterConditional(typeof(IValidator<>), typeof(EmptyValidator<>), Lifestyle.Singleton,
            c => !c.Handled);

            //Services
            _simpleContainer.RegisterSingleton<Publisher>();
            _simpleContainer.Register<IPublisher, Publisher>(Lifestyle.Singleton);


        }
    }
}
