using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SimpleInjector;
using ApplicationServices.MessageBus.CommandDispatcher;
using System.ServiceModel.Description;
using PatientManager.Contract.Commands;
using Infrastructure.AbstractFactories;

namespace Infrastructure.Services
{
    public static class CommandProcessorServiceConfig
    {
        private static ServiceHost _host;
        public static ServiceHost Host { get { return _host; } }

        static CommandProcessorServiceConfig()
        {
            Configure(Bootstrapper.Container);
        }
        private static void Configure(Container container)
        {
            ////ConfigureContractTypes();
            //Uri baseAddress = new Uri("net.tcp://localhost:6080");
            //var host = new ServiceHost(typeof(PatientManagerCommandProcessor), baseAddress);
            //var binding = new NetTcpBinding();
            //host.AddServiceEndpoint(typeof(PatientManagerCommandProcessor), binding, typeof(PatientManagerCommandProcessor).Namespace);
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = false });
            //host.AddServiceEndpoint(typeof(IMetadataExchange),
            //    MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:6080/mex");
            //_host = host;


            Uri baseAddressLAN = new Uri("net.tcp://localhost:6080");
            Uri baseAddressWeb = new Uri("http://localhost:6085");
            var host = new ServiceHost(typeof(PatientManagerCommandProcessor), baseAddressLAN, baseAddressWeb);
            var bindingLAN = new NetTcpBinding(); //{ Name = "LAN"};
            var bindingWeb = new BasicHttpBinding(); //{ Name = "Web"};
            host.AddServiceEndpoint(typeof(PatientManagerCommandProcessor), bindingLAN, typeof(PatientManagerCommandProcessor).Namespace);
            host.AddServiceEndpoint(typeof(PatientManagerCommandProcessor), bindingWeb, typeof(PatientManagerCommandProcessor).Namespace);
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            _host = host;

        }

        //public void Open()
        //{
        //    _host.Open();
        //}

        //public void Close()
        //{
        //    _host.Close();
        //}

        ////private static void ConfigureContractTypes()
        ////{
        ////    var allTypesInContractAssembly = typeof(ICommand).Assembly.GetExportedTypes();
        ////    var contractTypes = allTypesInContractAssembly.Where(t => t.GetInterfaces().Contains(typeof(ICommand))).ToArray();
        ////    CommandProcessor.CommandTypes = contractTypes;
        ////}

        //public void Dispose()
        //{
        //    if (_host != null) { _host.Close(); }
        //}
    }
}
