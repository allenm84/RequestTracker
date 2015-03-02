using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  [DataContract(Name = "RequestItemStateChange", Namespace = Database.Namespace)]
  public class RequestItemStateChange : ExtensibleDataObject
  {
    [DataMember]
    public DateTime Date { get; set; }
    [DataMember]
    public string UserID { get; set; }
    [DataMember]
    public string Notes { get; set; }
    [DataMember]
    public RequestItemState Previous { get; set; }
    [DataMember]
    public RequestItemState Current { get; set; }
  }
}
