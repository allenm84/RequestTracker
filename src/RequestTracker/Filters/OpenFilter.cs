using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  public class OpenFilter : RequestStateFilter
  {
    public override RequestItemState State
    {
      get { return RequestItemState.Open; }
    }
  }
}
