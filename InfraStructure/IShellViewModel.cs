using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace InfraStructure
{
   public interface IShellViewModel
    {
       ObservableCollection<ICommandObject> NavigationItems{get;}
     //  ObservableCollection<ModuleSection> Sections { get; }
    }
}
