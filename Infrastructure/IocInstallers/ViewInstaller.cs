using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Views;
using Controllers.ViewInterfaces;
using SimpleInjector.Diagnostics;

namespace Infrastructure.IocInstallers
{
    static class ViewInstaller
    {
        private static IEnumerable<Type> _viewServiceTypes; // used to suppress errors
        private static Container _container;


        public static void RegisterServices(Container _simpleContainer)
        {
            _container = _simpleContainer;
            var viewAssembly = typeof(MainView).Assembly;
            var viewTypes =
                from type in viewAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(typeof(IViewBase))
                select type;

            var viewServiceTypes = new List<Type>(); // to suppress warnings after
            foreach (var viewType in viewTypes)
            {
                var service = GetViewService(viewType);
                _simpleContainer.Register(service, viewType);
                viewServiceTypes.Add(service);
            }
            _viewServiceTypes = viewServiceTypes;

        }

        private static Type GetViewService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IViewBase)) && i.IsGenericType == false).Single();

            return service;


        }

        //private static void SuppressWarnings(Container _simpleContainer)
        //{
        //    Registration reg = null;

        //    foreach (var service in _viewServiceTypes)
        //    {
        //        reg = _simpleContainer.GetRegistration(service).Registration;
        //        reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
        //            "The views are expected to dispose when form is closed");
        //        reg.SuppressDiagnosticWarning(DiagnosticType.LifestyleMismatch,
        //            "A captive depedency is avoided becasue The controller lifestyle should dispose when its dependency (view) is disposed");
        //    }

        //    reg = _simpleContainer.GetRegistration(typeof(IUnitOfWork)).Registration;
        //    reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, // this should be scoped
        //        "The uow is expected to dispose after commandhandler has run");

        //    reg = _simpleContainer.GetRegistration(typeof(PatientContext)).Registration;
        //    reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, // this should be scoped
        //        "The context is expected to dispose after commandhandler has run");
        //}


        public static void SuppressIocWarnings()
        {
            Registration reg = null;

            foreach (var service in _viewServiceTypes)
            {
                reg = _container.GetRegistration(service).Registration;
                reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                    "The views are expected to dispose when form is closed");
                reg.SuppressDiagnosticWarning(DiagnosticType.LifestyleMismatch,
                    "A captive depedency is avoided becasue The controller lifestyle should dispose when its dependency (view) is disposed");
            }

        }

    }
}
