using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TalentManager;
using System.Windows.Forms;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using InfraStructure;

namespace ApplicationStartUpService
{
     [Export(typeof(IApplicationStartUpService))]
  public  class AppStartUp:IApplicationStartUpService
    {
         IShellView shell;
         [ImportingConstructor]
         public AppStartUp(IShellView shell)
         {
             this.shell = shell;
         }

         public AppStartUp()
         {
         }
        public void Start()
        {
           // throw new NotImplementedException();
          UserControl1 l = new UserControl1();
          bool? result=  l.ShowDialog();
          if (result == true)
              shell.Display();

              
        }
    }
}
