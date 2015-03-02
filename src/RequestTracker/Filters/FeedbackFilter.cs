using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;

namespace RequestTracker
{
  public class FeedbackFilter : RequestStateFilter
  {
    public override RequestItemState State
    {
      get { return RequestItemState.Feedback; }
    }
  }
}
