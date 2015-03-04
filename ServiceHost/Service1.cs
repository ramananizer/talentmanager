using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using TalentManagerservice;

namespace ServiceHost
{
    public partial class Service1 : ServiceBase
    {
        public System.ServiceModel.ServiceHost serviceHost = null;
        public Service1()
        {
            InitializeComponent();
            ServiceName = "TalentManagerService";
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
                serviceHost.Close();
            serviceHost = new System.ServiceModel.ServiceHost(typeof(IDataService));
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
