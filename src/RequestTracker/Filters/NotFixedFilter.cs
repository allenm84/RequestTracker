using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  public class NotFixedFilter : RequestFilter
  {
    public override int Order
    {
      get { return 2; }
    }

    public override string Description
    {
      get { return "Not fixed"; }
    }

    public override bool IsRequestVisible(LocalData local, RequestItem item)
    {
      return item.State != RequestItemState.Fixed;
    }
  }
}
