using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DataManager
{
    [ServiceContract]
   public interface IDataManager
    {
        bool login(string userName, string passWord);
    }
}
