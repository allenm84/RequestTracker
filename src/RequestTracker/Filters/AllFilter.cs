using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace RequestTracker
{
  public class AllFilter : RequestFilter
  {
    public override int Order
    {
      get { return 0; }
    }

    public override string Description
    {
      get { return "[All requests]"; }
    }

    public override bool IsRequestVisible(LocalData local, RequestItem item)
    {
      return true;
    }
  }
}
