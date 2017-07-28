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
    public static class QueryProcessorServiceConfig
    {


        static private ServiceHost _host;
        public static ServiceHost Host { get { return _host; } }


        static QueryProcessorServiceConfig()
        {
            Configure(Bootstrapper.Container);
        }

        private static void Configure(Container container)
        {
            ////ConfigureContractTypes();
            //Uri baseAddress = new Uri("net.tcp://localhost:6070");
            //var host = new ServiceHost(typeof(PatientManagerQueryProcessor), baseAddress);
            //var binding = new NetTcpBinding();
            //host.AddServiceEndpoint(typeof(PatientManagerQueryProcessor), binding, typeof(PatientManagerQueryProcessor).Namespace);
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = false });
            //host.AddServiceEndpoint(typeof(IMetadataExchange),
            //    MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:6070/mex");
            //_host = host;


            Uri baseAddressLAN = new Uri("net.tcp://localhost:6070");
            Uri baseAddressWeb = new Uri("http://localhost:6075");
            var host = new ServiceHost(typeof(PatientManagerQueryProcessor), baseAddressLAN, baseAddressWeb);
            var bindingLAN = new NetTcpBinding();// { Name = "LAN" };
            var bindingWeb = new BasicHttpBinding();// { Name = "Web" };
            host.AddServiceEndpoint(typeof(PatientManagerQueryProcessor), bindingLAN, typeof(PatientManagerQueryProcessor).Namespace);
            host.AddServiceEndpoint(typeof(PatientManagerQueryProcessor), bindingWeb, typeof(PatientManagerQueryProcessor).Namespace);
            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
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

        //public void Dispose()
        //{
        //    if (_host != null) { _host.Close(); }
        //}

    }
}
