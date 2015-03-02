using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "RequestItem", Namespace = Database.Namespace)]
  public class RequestItem : ExtensibleDataObject
  {
    [DataMember]
    public uint Number { get; set; }
    [DataMember]
    public string ProgramID { get; set; }
    [DataMember]
    public string EnteredByID { get; set; }
    [DataMember]
    public DateTime Entered { get; set; }
    [DataMember]
    public string Summary { get; set; }
    [DataMember]
    public string Description { get; set; }
    [DataMember]
    public RequestItemState State { get; set; }
    [DataMember]
    public List<ReproduceStep> Reproduce { get; set; }
    [DataMember]
    public List<RequestItemStateChange> History { get; set; }
    [DataMember]
    public bool IsImportant { get; set; }
  }
}
