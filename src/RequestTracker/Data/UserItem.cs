using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "UserItem", Namespace = Database.Namespace)]
  public class UserItem : ExtensibleDataObject, ISimpleItem
  {
    [DataMember]
    public string ID { get; set; }
    [DataMember]
    public string Name { get; set; }
  }
}
