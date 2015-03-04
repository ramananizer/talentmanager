using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfraStructure.Entities;
using System.ComponentModel.Composition;


namespace Recruitment.ViewModel
{
    [Export(typeof(AllRequirementsViewModel))]
  public  class AllRequirementsViewModel
    {
      public List<Requirement> AllRequirements
      {
          get
          {
              return AllRequirements;
          }
      }
    }
}
