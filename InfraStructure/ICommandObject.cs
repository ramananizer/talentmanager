using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel.Composition;

namespace InfraStructure
{
   public interface ICommandObject
    {
       string CommandName { get; set; }
       ICommand Command { get; set; }
    }

   [Export(typeof(ICommandObject))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
   public class CommandObject : ICommandObject
   {

       public string CommandName
       {
           get;
           set;
       }

       public ICommand Command
       {
           get;
           set;
       }
   }

   public interface IModuleSection
   {
       string SectionHeader { get; set; }
       List<ICommandObject> SectionItems { get;  }
   }

   public class ModuleSection : IModuleSection
   {
       private List<ICommandObject> _SectionItems;
       public List<ICommandObject> SectionItems
       {
           get
           {
               _SectionItems = _SectionItems ?? new List<ICommandObject>();
               return _SectionItems;
           }
           
       }
       public string SectionHeader { get; set; }
   }
}
