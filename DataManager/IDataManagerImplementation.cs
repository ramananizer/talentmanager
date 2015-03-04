using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataManager
{
    public class IDataManagerImplementation:IDataManager
    {
        public bool login(string userName, string passWord)
        {
            if (userName == "Raman" && passWord == "a80tude")
                return true;
            return false;
        }
    }
}
