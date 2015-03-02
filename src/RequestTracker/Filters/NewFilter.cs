using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  public class NewFilter : RequestFilter
  {
    public override int Order
    {
      get { return 1; }
    }

    public override string Description
    {
      get { return "New requests"; }
    }

    public override bool IsRequestVisible(LocalData local, RequestItem item)
    {
      return !local.KnownRequests.Contains(item.Number);
    }
  }
}
