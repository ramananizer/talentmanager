using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phoenix.Infrastructure.Interfaces;
using System.Collections.ObjectModel;

namespace InfraStructure.Entities
{
   public class Requirement
    {
       public Company Company { get; set; }
       public string Designation { get; set; }
       public int MinExperience { get; set; }
       public int MaxExperience { get; set; }
       public string Education { get; set; }
       public bool inProcess { get; set; }
    }

   public class Company
   {
       public string Name { get; set; }
       public string Address { get; set; }
       private ObservableCollection<ITaggableObject> _PhoneNumbers;
       public ObservableCollection<ITaggableObject> PhoneNumbers
       {
           get
           {
               _PhoneNumbers = _PhoneNumbers ?? new ObservableCollection<ITaggableObject>();
               return _PhoneNumbers;
           }
      
      }
       public string ContactPerson { get; set; }
   }

   public class PhoneNumber:ITaggableObject
   {
       public string Extension { get; set; }
       public string Number { get; set; }

       private Object _Tag;
       public object Tag
       {
           get
           {
               return _Tag;
           }
           set
           {
               _Tag = value;
           }
       }

       public bool IsEmpty
       {
           get { return String.IsNullOrEmpty(Extension) && string.IsNullOrEmpty(Number); }
       }

       public bool Validate()
       {
           return true;
       }
   }
}
