using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace ApplicationStartUpService
{
    [ModuleExport(typeof(ApplicationStartUpService))]
    public class ApplicationStartUpService:IModule
    {
        public void Initialize()
        {
           // throw new NotImplementedException();
        }
    }
}
