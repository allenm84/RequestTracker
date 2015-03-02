using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  public class ApprovedFilter : RequestStateFilter
  {
    public override RequestItemState State
    {
      get { return RequestItemState.Approved; }
    }
  }
}
