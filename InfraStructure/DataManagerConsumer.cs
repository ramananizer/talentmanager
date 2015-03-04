using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace InfraStructure
{
  public  class DataManagerConsumer 
    {
      public bool Login(string userName, string password)
      {
          using(ServiceHost host = new ServiceHost(typeof(DataManager.IDataManagerImplementation)))
          return false;
      }
    }
}
