﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Reflection;

namespace Infrastructure.ServerHosts.WindowsService
{
    public partial class PatientManagerWindowsServiceDebugger : Form
    {
        private ServiceBase[] _servicesToRun;
        public PatientManagerWindowsServiceDebugger(ServiceBase[] servicesToRun):this()
        {
            _servicesToRun = servicesToRun;
            Launch();
        }

        public PatientManagerWindowsServiceDebugger()
        {
            InitializeComponent();
        }
        private void Launch()
        {
            listBox1.Items.Add("Services running in interactive mode.");
            listBox1.Items.Add("");
            

            MethodInfo onStartMethod = typeof(ServiceBase).GetMethod("OnStart",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in _servicesToRun)
            {
                listBox1.Items.Add(string.Format("Starting {0}...", service.ServiceName));
                onStartMethod.Invoke(service, new object[] { new string[] { } });
                listBox1.Items.Add("Started");
            }

            listBox1.Items.Add("");
            listBox1.Items.Add("");
            listBox1.Items.Add("Close Form to stop the services and the process...");


        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(_servicesToRun != null)
            {
                MethodInfo onStopMethod = typeof(ServiceBase).GetMethod("OnStop", BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (ServiceBase service in _servicesToRun)
                {
                    //listBox1.Items.Add(string.Format("Stopping {0}...", service.ServiceName));
                    onStopMethod.Invoke(service, null);
                    //listBox1.Items.Add("Stopped");
                    //Task.Delay(2000);
                }

            }
            base.OnClosing(e);
        }
    }
}
