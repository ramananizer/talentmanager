using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using InfraStructure;
using System.Collections;
using InfraStructure.Constants;

namespace TalentManager
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel:IShellViewModel
    {
        private ObservableCollection<ICommandObject> _NavigationItems;

        [Export(Constants.NAVIGATION_ITEMS,typeof(IList))]
        public ObservableCollection<ICommandObject> NavigationItems
        {

            get
            {
                _NavigationItems = _NavigationItems ?? new ObservableCollection<ICommandObject>();
                return _NavigationItems;
            }

          
        }


    }
}
