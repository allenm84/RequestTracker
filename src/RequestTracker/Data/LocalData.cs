using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "LocalData", Namespace = Database.Namespace)]
  public class LocalData : ExtensibleDataObject
  {
    [DataMember]
    public string CurrentUserID { get; set; }
    [DataMember]
    public HashSet<uint> KnownRequests { get; set; }
  }
}
