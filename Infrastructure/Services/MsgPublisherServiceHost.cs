using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.ServiceModel.Description;
using PatientManager.Contract.Commands;
using PublisherSubscriberService;

namespace Infrastructure.Services
{
    public static class MsgPublisherServiceConfig
    {
        private static ServiceHost _host;
        public static ServiceHost Host { get { return _host; } }

        static MsgPublisherServiceConfig()
        {
            Configure(Bootstrapper.Container);
            ConfigureContractTypes();
        }
        private static void Configure(Container container)
        {
            Uri baseAddress = new Uri("net.tcp://localhost:6090");
            var host = new ServiceHost(container.GetInstance<Publisher>(), baseAddress);
            var binding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(IPublisher), binding, "PublisherSubscriberService");
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });
            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = false });
            host.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexTcpBinding(), "net.tcp://localhost:6090/mex");
            _host = host;


        }


        private static void ConfigureContractTypes()
        {
            var allTypesInContractAssembly = typeof(ICommand).Assembly.GetExportedTypes();
            var contractTypes = allTypesInContractAssembly.Where(t => t.IsClass).ToArray();
            MessageWrapper.AllMessageTypes = contractTypes;
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
        //    if(_host != null) { _host.Close(); }
        //}
    }
}
