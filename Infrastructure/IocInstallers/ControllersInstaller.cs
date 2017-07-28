using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Controllers.Controllers;
using Infrastructure.AbstractFactories;
using Controllers.ControllerEvents;

namespace Infrastructure.IocInstallers
{
    static class ControllersInstaller
    {
        private static Lifestyle CacheControllerBasedOnView;
        private static IEnumerable<Type> _controllerTypes; // used to suppress errors

        public static void RegisterServices(Container _simpleContainer)
        {
            SetCustomLifetime();
            RegisterControllers(_simpleContainer);
        }

        private static void RegisterControllers(Container _simpleContainer)
        {
            var controllerAssembly = typeof(IController).Assembly;
            var controllerRegistrations =
                from type in controllerAssembly.GetExportedTypes()
                where type.Namespace == typeof(IController).Namespace
                where type.GetInterfaces().Contains(typeof(IController)) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };
            _controllerTypes = controllerRegistrations.Select(reg => reg.Implementation).ToList(); // to suppress warnings after
            foreach (var reg in controllerRegistrations)
            {
                _simpleContainer.Register(reg.Implementation, reg.Implementation, CacheControllerBasedOnView);
            }

            _simpleContainer.RegisterSingleton<IControllerFactory>(new ControllerFactory(_simpleContainer));
            _simpleContainer.Register(typeof(IControllerEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton<IControllerEventHandlerFactory>(new ControllerEventHandlerFactory(_simpleContainer));
            _simpleContainer.RegisterSingleton<IControllerEventRaiser>(new ControllerEventsRaiser(_simpleContainer));


        }

        private static void SetCustomLifetime()
        {
             CacheControllerBasedOnView = Lifestyle.CreateCustom("Cache Controller While View Not Disposed",
             instanceCreator => {
                 var syncRoot = new object();
                 object instance = null;

                 return () => {
                     lock (syncRoot)
                     {
                         var controller = instance as IController;
                         if (controller == null || controller.ViewWasDisposed)
                         {
                             instance = null;  // dispose.. hopefully
                                        instance = instanceCreator.Invoke();
                         }
                         return instance;
                     }
                 };
             });
        }


    }
}
