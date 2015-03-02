using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace RequestTracker
{
  [DataContract(Name = "RequestItemState", Namespace = Database.Namespace)]
  public enum RequestItemState
  {
    [EnumMember]
    None,
    [EnumMember]
    Open,
    [EnumMember]
    Approved,
    [EnumMember]
    Scheduled,
    [EnumMember]
    Feedback,
    [EnumMember]
    Fixed,
  }
}
