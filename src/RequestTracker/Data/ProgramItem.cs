using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "ProgramItem", Namespace = Database.Namespace)]
  public class ProgramItem : ExtensibleDataObject, ISimpleItem
  {
    [DataMember]
    public string ID { get; set; }
    [DataMember]
    public string Name { get; set; }
  }
}
