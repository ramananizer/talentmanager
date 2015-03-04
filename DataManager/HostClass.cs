using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.ServiceModel;

namespace DataManager
{
  public  class HostClass : ServiceBase
    {
      public ServiceHost serviceHost = null;
      public HostClass()
      {
          ServiceName = "TalentManagerService";
      }

      public static void Main()
      {
          ServiceBase.Run(new HostClass());
      }

      protected override void OnStart(string[] args)
      {
          //base.OnStart(args);
          if (serviceHost != null)
              serviceHost.Close();
          serviceHost = new ServiceHost(typeof(IDataManagerImplementation));
          serviceHost.Open();
      }

      protected override void OnStop()
      {
          base.OnStop();
          if (serviceHost != null)
          {
              serviceHost.Close();
              serviceHost = null;
          }
      }
    }
}
