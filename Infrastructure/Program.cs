using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistance.UnitOfWork;
using Persistance.Context;
using AutoMapper;
using Infrastructure.Mappers;
//using Castle.Windsor;
using SimpleInjector;
using log4net;
using Infrastructure.Services;
using System.Diagnostics;
using Infrastructure.ErrorHandlers;
using System.ServiceProcess;
using Infrastructure.ServerHosts.WindowsService;

namespace Infrastructure
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, e) => FatalExceptionObject.Handle(e.ExceptionObject);
                Application.ThreadException += (sender, e) => FatalExceptionHandler.Handle(e.Exception);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += Application_ApplicationExit;
                var container = Bootstrapper.Container;
                var logger = container.GetInstance<ILog>();


                ServiceBase[] servicesToRun;
                servicesToRun = new ServiceBase[]
                {
                    new PatientManagerWindowsService()
                };

                if (Environment.UserInteractive) //debug mode: simulate windows service
                {
                    Application.Run(new PatientManagerWindowsServiceDebugger(servicesToRun));
                }
                else
                {
                    ServiceBase.Run(servicesToRun);
                }


                //using (var publisherhost = new MsgPublisherServiceHost(container))
                //{
                //    using (var QueryProcessorHost = new QueryProcessorServiceConfig())
                //    {
                //        using (var commandProcessorHost = new CommandProcessorServiceHost())
                //        {
                //            publisherhost.Open();
                //            QueryProcessorHost.Open();
                //            commandProcessorHost.Open();
                            
                //            logger.Info("Application session initiated");
                //            var controller = container.GetInstance<ViewHostController>();
                //            controller.StartApplication();

                //        }

                //    }
                   
                //}
               

            }
            catch (Exception e)
            {
                FatalExceptionHandler.Handle(e);
            }
            
                
        }

 

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (Bootstrapper.Container != null)
            {
                var logger = Bootstrapper.Container.GetInstance<ILog>();
                logger.Info("Application session terminated");
                Bootstrapper.Container.Dispose();
            }
        }
    }
}
