using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace RequestTracker
{
  public abstract class RequestStateFilter : RequestFilter
  {
    public readonly static Dictionary<RequestItemState, string> Descriptions;
    public readonly static Dictionary<RequestItemState, string> Summaries;

    static RequestStateFilter()
    {
      Descriptions = new Dictionary<RequestItemState, string>();
      Descriptions[RequestItemState.Approved] = "Requests which have been approved";
      Descriptions[RequestItemState.Feedback] = "Requests that need feedback";
      Descriptions[RequestItemState.Fixed] = "Requests which have been fixed";
      Descriptions[RequestItemState.None] = "You cheated somehow";
      Descriptions[RequestItemState.Open] = "Requests awaiting approval";
      Descriptions[RequestItemState.Scheduled] = "Requests currently being worked on";

      Summaries = new Dictionary<RequestItemState, string>();
      Summaries[RequestItemState.Approved] = "Approved";
      Summaries[RequestItemState.Feedback] = "In Feedback";
      Summaries[RequestItemState.Fixed] = "Fixed";
      Summaries[RequestItemState.None] = "You cheated somehow";
      Summaries[RequestItemState.Open] = "New";
      Summaries[RequestItemState.Scheduled] = "Being Fixed";
    }

    public override int Order { get { return 10 + (int)State; } }

    public abstract RequestItemState State { get; }

    public override string Description
    {
      get { return Descriptions[State]; }
    }

    public override bool IsRequestVisible(LocalData local, RequestItem item)
    {
      return (item.State == State);
    }
  }
}
