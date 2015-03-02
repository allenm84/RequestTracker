using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "ExtensibleDataObject", Namespace = Database.Namespace)]
  public abstract class ExtensibleDataObject : IExtensibleDataObject
  {
    #region IExtensibleDataObject Members

    ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }

    #endregion
  }
}
