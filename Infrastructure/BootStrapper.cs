using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.Windsor;
using Castle.Components;
using Castle.Windsor.Configuration;
using Persistance.UnitOfWork;
using Persistance.Context;
using Castle.MicroKernel.Registration;
using AutoMapper;
using Infrastructure.Mappers;
using ApplicationServices.MessageBus.CommandDispatcher;
using ApplicationServices.MessageBus.QueryDispatcher;
using ApplicationServices.Validation.Validators;
using ApplicationServices.CommandHandlers;
using ApplicationServices.QueryHandlers;
using ApplicationServices.EventHandlers;
using ApplicationServices.CrossCuttingConcerns;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using Views;
using Castle.Facilities.TypedFactory;
using Infrastructure.AbstractFactories;
using FluentValidation;
using ApplicationServices.Validation;
using System.Reflection;
using Controllers.ControllerEvents;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using log4net;
using System.Runtime.Caching;
using PatientManager.Contract.Commands;
using PublisherSubscriberService;
using ValueObjects.ContactInformation;
using Infrastructure.IocInstallers;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static readonly ILog Logger;
        public static readonly Container Container;
        public static Type[] AllContractTypes { get; private set; }

        

        static Bootstrapper()
        {
            
            Logger = log4net.LogManager.GetLogger("RollingFileLogger");
            var container = new Container();
            InfrastructureInstaller.RegisterServices(container);
            ApplicationServicesInstaller.RegisterServices(container);
            ControllersInstaller.RegisterServices(container);
            PersistanceInstaller.RegisterServices(container);
            ViewInstaller.RegisterServices(container);

            ViewInstaller.SuppressIocWarnings();
            PersistanceInstaller.SuppressWarnings();
            GetContractTypes();

            container.Verify();
            Container = container;

        }

        private static void GetContractTypes()
        {
            var allContractTypes = new List<Type>();
            var allTypesInContractAssembly = typeof(ICommand).Assembly.GetExportedTypes().Where(t => t.IsClass && t.IsGenericType == false).ToArray();
            var allTypesInValueObjectsAssembly = typeof(Address).Assembly.GetExportedTypes().Where(t => t.IsClass && t.IsGenericType == false).ToArray();
            allContractTypes.AddRange(allTypesInContractAssembly);
            AllContractTypes = allContractTypes.ToArray();
        }

    }
}
