using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Win;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace RequestTracker
{
  public static class Extensions
  {
    public static RequestItem Duplicate(this RequestItem request)
    {
      return new RequestItem
      {
        Description = request.Description.Duplicate(),
        Entered = request.Entered,
        EnteredByID = request.EnteredByID.Duplicate(),
        History = request.History.Select(h => h.Duplicate()).ToList(),
        Number = request.Number,
        ProgramID = request.ProgramID.Duplicate(),
        Reproduce = request.Reproduce.Select(r => r.Duplicate()).ToList(),
        State = request.State,
        Summary = request.Summary.Duplicate(),
      };
    }

    public static ReproduceStep Duplicate(this ReproduceStep step)
    {
      return new ReproduceStep
      {
        Text = step.Text.Duplicate(),
      };
    }

    public static RequestItemStateChange Duplicate(this RequestItemStateChange change)
    {
      return new RequestItemStateChange
      {
        Current = change.Current,
        Date = change.Date,
        Notes = change.Notes.Duplicate(),
        Previous = change.Previous,
        UserID = change.UserID.Duplicate(),
      };
    }

    public static void ChangeStateTo(this RequestItem request, RequestItemState state, string notes, string userID)
    {
      request.History.Add(new RequestItemStateChange
      {
        Current = state,
        Date = DateTime.Now,
        Notes = notes,
        Previous = request.State,
        UserID = userID,
      });
      request.State = state;
    }

    public static bool GetVisible(this BarItem item)
    {
      return item.Visibility == BarItemVisibility.Always;
    }

    public static void SetVisible(this BarItem item, bool visible)
    {
      item.Visibility = visible 
        ? BarItemVisibility.Always 
        : BarItemVisibility.Never;
    }

    public static void ReplaceWith<T>(this IList<T> list, IEnumerable<T> data)
    {
      list.Clear();
      foreach (T d in data)
        list.Add(d);
    }

    public static IEnumerable<ProgramItem> Duplicate(this IEnumerable<ProgramItem> programs)
    {
      return programs.Select(u => u.Duplicate());
    }

    public static ProgramItem Duplicate(this ProgramItem program)
    {
      return new ProgramItem
      {
        ID = program.ID.Duplicate(),
        Name = program.Name.Duplicate(),
      };
    }

    public static IEnumerable<UserItem> Duplicate(this IEnumerable<UserItem> users)
    {
      return users.Select(u => u.Duplicate());
    }

    public static UserItem Duplicate(this UserItem user)
    {
      return new UserItem
      {
        ID = user.ID.Duplicate(),
        Name = user.Name.Duplicate(),
      };
    }

    public static string Duplicate(this string text)
    {
      return string.Copy(text ?? string.Empty);
    }

    public static string GetFindText(this SearchLookUpEdit edit)
    {
      var popupControl = edit as IPopupControlEx;
      var popupWindow = (PopupSearchLookUpEditForm)popupControl.PopupWindow;
      var control = (SearchEditLookUpPopup)popupWindow.Controls[2];
      return control.FindText;
    }
  }
}
