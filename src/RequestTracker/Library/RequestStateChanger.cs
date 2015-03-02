using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestTracker
{
  public sealed class RequestStateChanger
  {
    public RequestItem Request { get; private set; }
    public string UserID { get; private set; }
    public IWin32Window Owner { get; private set; }
    public bool IsDifferentUser { get; private set; }

    public bool CanApprove { get { return GetCanApprove(Request, IsDifferentUser); } }
    public bool CanSchedule { get { return GetCanSchedule(Request, IsDifferentUser); } }
    public bool CanResolve { get { return GetCanResolve(Request, IsDifferentUser); } }
    public bool CanReject { get { return GetCanReject(Request, IsDifferentUser); } }
    public bool CanFixed { get { return GetCanFixed(Request, IsDifferentUser); } }
    public bool CanReOpen { get { return GetCanReOpen(Request, IsDifferentUser); } }

    public RequestStateChanger(RequestItem request, string userID, IWin32Window owner)
    {
      Request = request;
      UserID = userID;
      Owner = owner;
      IsDifferentUser = !string.Equals(request.EnteredByID, userID);
    }

    public bool Approve()
    {
      return DoApprove(Request, UserID);
    }

    public bool Schedule()
    {
      return DoSchedule(Request, UserID);
    }

    public bool Resolve()
    {
      return DoResolve(Request, UserID, Owner);
    }

    public bool Reject()
    {
      return DoReject(Request, UserID, Owner);
    }

    public bool Fixed()
    {
      return DoFixed(Request, UserID);
    }

    public bool ReOpen()
    {
      return DoReOpen(Request, UserID, Owner);
    }

    public static bool DoApprove(RequestItem request, string userID)
    {
      request.ChangeStateTo(RequestItemState.Approved, "Request has been seen", userID);
      return true;
    }

    public static bool DoSchedule(RequestItem request, string userID)
    {
      request.ChangeStateTo(RequestItemState.Scheduled, "Request has been scheduled", userID);
      return true;
    }

    public static bool DoResolve(RequestItem request, string userID, IWin32Window owner)
    {
      using (var dlg = new MultilineInputBox())
      {
        dlg.Text = "Resolve...";
        dlg.Prompt = "Notes:";
        if (dlg.ShowDialog(owner) == DialogResult.OK)
        {
          request.ChangeStateTo(RequestItemState.Feedback, dlg.Input, userID);
          return true;
        }
      }
      return false;
    }

    public static bool DoReject(RequestItem request, string userID, IWin32Window owner)
    {
      using (var dlg = new MultilineInputBox())
      {
        dlg.Text = "Reject...";
        dlg.Prompt = "Reason:";
        if (dlg.ShowDialog(owner) == DialogResult.OK)
        {
          request.ChangeStateTo(RequestItemState.Scheduled, dlg.Input, userID);
          return true;
        }
      }
      return false;
    }

    public static bool DoFixed(RequestItem request, string userID)
    {
      request.ChangeStateTo(RequestItemState.Fixed, "Verified as fixed", userID);
      return true;
    }

    public static bool DoReOpen(RequestItem request, string userID, IWin32Window owner)
    {
      using (var dlg = new MultilineInputBox())
      {
        dlg.Text = "Re-Open...";
        dlg.Prompt = "Reason:";
        if (dlg.ShowDialog(owner) == DialogResult.OK)
        {
          request.ChangeStateTo(RequestItemState.Open, dlg.Input, userID);
          return true;
        }
      }
      return false;
    }

    public static bool GetCanApprove(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Open && isDifferentUser;
    }

    public static bool GetCanSchedule(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Approved && isDifferentUser;
    }

    public static bool GetCanResolve(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Scheduled && isDifferentUser;
    }

    public static bool GetCanReject(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Feedback && !isDifferentUser;
    }

    public static bool GetCanFixed(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Feedback && !isDifferentUser;
    }

    public static bool GetCanReOpen(RequestItem request, bool isDifferentUser)
    {
      return request.State == RequestItemState.Fixed;
    }
  }
}
