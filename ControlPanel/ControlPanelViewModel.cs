using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using InfraStructure;
using System.ComponentModel.Composition;

namespace ControlPanel
{
    [Export(typeof(ControlPanelViewModel))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]
   public class ControlPanelViewModel
    {
        private ObservableCollection<ModuleSection> _Sections;
        [Export("Sections")]
        //[PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.Shared)]
        public ObservableCollection<ModuleSection> Sections
        {
            get
            {
                _Sections = _Sections ?? new ObservableCollection<ModuleSection>();
                return _Sections;
            }
        }
    }
}
