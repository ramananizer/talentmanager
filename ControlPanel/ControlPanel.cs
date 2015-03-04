using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using InfraStructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace ControlPanel
{
    [ModuleExport(typeof(ControlPanel))]
   public class ControlPanel:IModule
    {
        [ImportingConstructor]
        public ControlPanel(ICommandObject cmd)
        {
            cmdObject = cmd;
            cmdObject.CommandName = "Control Panel";
            cmdObject.Command = new DelegateCommand<Object>(OnControlPanelCommand);
        }
        public void Initialize()
        {
           // throw new NotImplementedException();
            ShellViewModel.NavigationItems.Add(cmdObject);
        }

        [Import]
        private IShellViewModel ShellViewModel;
        [Import]
        private IRegionManager regionManager;
        private ICommandObject cmdObject;

        private void OnControlPanelCommand(Object obj)
        {
            Uri viewNav = new Uri("ControlPanelView", UriKind.Relative);
            regionManager.RequestNavigate("MainRegion", viewNav);
        }
    }
}
