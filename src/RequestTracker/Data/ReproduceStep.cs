using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "ReproduceStep", Namespace = Database.Namespace)]
  public class ReproduceStep : ExtensibleDataObject
  {
    [DataMember]
    public string Text { get; set; }
  }
}
