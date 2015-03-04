using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using InfraStructure;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using System.Collections;
using InfraStructure.Constants;

namespace Training
{
    [ModuleExport(typeof(Training))]
   public class Training:IModule
    {
        ICommandObject cmdObject;
        [ImportingConstructor]
        public Training(ICommandObject cmd)
        {
            cmdObject = cmd;
            cmdObject.CommandName = "Training";
            cmdObject.Command = new DelegateCommand<Object>(OnTrainingCommand);
            cmdObject = cmd;
        }
        public void Initialize()
        {
          //  throw new NotImplementedException();

          IList navigationItems=  ServiceLocator.Current.GetInstance(typeof(IList), Constants.NAVIGATION_ITEMS) as IList;
          navigationItems.Add(cmdObject);

        }

        private void OnTrainingCommand(Object obj)
        {
           
            Uri viewNav = new Uri("TrainingView", UriKind.Relative);
            regionManager.RequestNavigate("MainRegion", viewNav);
        }

        [Import]
        private IShellViewModel ShellViewModel;

        [Import]
        private IRegionManager regionManager;
    }
}
