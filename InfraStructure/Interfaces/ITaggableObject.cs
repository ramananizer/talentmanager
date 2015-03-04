using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoenix.Infrastructure.Interfaces
{
   public interface ITaggableObject
    {
         Object Tag { get; set; }
         bool IsEmpty { get; }
         bool Validate();
    }
}
