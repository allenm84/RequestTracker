using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace RequestTracker
{
  public partial class MainForm : BaseForm
  {
    const string AllProgramsFilter = "{ALL}";

    private DataContractFile<LocalData> dcf;
    private LocalData localData;
    private BindingList<ProgramItem> programs;
    private BindingList<UserItem> users;
    private BindingList<RequestItem> requests;
    private RequestStateChanger changer;

    public MainForm()
    {
      InitializeComponent();
      dcf = new DataContractFile<LocalData>(
        Environment.SpecialFolder.ApplicationData,
        ".requesttracker",
        "local.xml");
    }

    private void SetCurrentUser(UserItem user)
    {
      if (user == null)
      {
        tbbSignInOut.PaintStyle = BarItemPaintStyle.Caption;
        tbbSignInOut.Caption = "Sign In";
        localData.CurrentUserID = null;
      }
      else
      {
        tbbSignInOut.PaintStyle = BarItemPaintStyle.CaptionGlyph;
        tbbSignInOut.Caption = user.Name;
        localData.CurrentUserID = user.ID;
      }
    }

    private bool DoSignIn(string userID)
    {
      var user = Database.GetUser(userID);
      SetCurrentUser(user);
      return (user != null);
    }

    private void DoSignOut()
    {
      SetCurrentUser(null);
    }

    private bool AskUserToSignIn(bool allowNullUser)
    {
      using (var dlg = new SelectUserDialog(Database.Users))
      {
        if (allowNullUser)
        {
          dlg.Text = "Please sign in/out";
        }
        else
        {
          dlg.Text = "Please sign in";
        }

        dlg.SelectedUserID = localData.CurrentUserID;
        dlg.AllowNullUser = allowNullUser;

        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          return DoSignIn(dlg.SelectedUserID);
        }
      }

      return false;
    }

    private void InitializeGridLookUps()
    {
      var program = default(ProgramItem);
      cboPrograms.DataSource = programs;
      cboPrograms.DisplayMember = program.GetMemberName(p => p.Name);
      cboPrograms.ValueMember = program.GetMemberName(p => p.ID);
      cboPrograms.Columns.Add(new LookUpColumnInfo(program.GetMemberName(p => p.Name))
      {
        SortOrder = ColumnSortOrder.Ascending,
      });

      var user = default(UserItem);
      cboUsers.DataSource = users;
      cboUsers.DisplayMember = user.GetMemberName(p => p.Name);
      cboUsers.ValueMember = user.GetMemberName(p => p.ID);
      cboUsers.Columns.Add(new LookUpColumnInfo(user.GetMemberName(p => p.Name))
      {
        SortOrder = ColumnSortOrder.Ascending,
      });

      var summaries = RequestStateFilter.Summaries;
      foreach (var kvp in summaries)
      {
        var state = kvp.Key;
        cboImages.Items.Add(new ImageComboBoxItem(kvp.Value, state, (int)state));
      }
    }

    private void InitializeRequestFilters()
    {
      var type = typeof(RequestFilter);
      var types = type.Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(type) && !t.IsAbstract)
        .Select(t => (RequestFilter)Activator.CreateInstance(t))
        .OrderBy(f => f.Order);

      foreach (var t in types)
      {
        cboRequestFilters.Properties.Items.Add(t);
      }
      cboRequestFilters.SelectedIndex = 0;
      cboRequestFilters.SelectedIndexChanged += cboRequestFilters_SelectedIndexChanged;
    }

    private void InitializeProgramFilters()
    {
      RefreshProgramFilters();

      var combo = cboProgramFilters.Properties;
      combo.DisplayMember = "Display";
      combo.ValueMember = "Value";
      combo.ShowHeader = false;
      combo.Columns.Add(new LookUpColumnInfo("Display")
      {
        SortOrder = ColumnSortOrder.Ascending,
      });
      cboProgramFilters.EditValue = AllProgramsFilter;
      cboProgramFilters.EditValueChanged += cboProgramFilters_EditValueChanged;
    }

    private void RefreshProgramFilters()
    {
      var current = cboProgramFilters.EditValue as string;
      var dataSource = programs
        .Select(p => new { Display = p.Name, Value = p.ID })
        .ToList();
      dataSource.Insert(0, new { Display = "[All Programs]", Value = AllProgramsFilter });
      cboProgramFilters.Properties.DataSource = dataSource;
      cboProgramFilters.EditValue = current;
    }

    private void AutoSignOutIfNeeded()
    {
      if (!string.IsNullOrWhiteSpace(localData.CurrentUserID))
      {
        var user = Database.GetUser(localData.CurrentUserID);
        if (user == null)
        {
          XtraMessageBox.Show(this,
            "The currently logged in user no longer exists. Signing out",
            "Auto sign out", MessageBoxButtons.OK, MessageBoxIcon.Information);
          DoSignOut();
        }
      }
    }

    private void EditRequestByRow(int rowHandle)
    {
      var item = gridViewRequests.GetRow(rowHandle) as RequestItem;
      EditRequestByItem(item);
    }

    private void EditRequestByItem(RequestItem item)
    {
      if (item == null) return;

      var copy = item.Duplicate();
      using (var dlg = new EditRequestItemDialog(localData, copy, programs))
      {
        dlg.Text = string.Format("Edit Request {0}", copy.Number);
        dlg.ReadOnly = true;
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          var index = requests.IndexOf(item);
          requests[index] = copy;
        }
      }
    }

    private void RefreshRequest(RequestItem request)
    {
      var index = requests.IndexOf(request);
      requests.ResetItem(index);
    }

    private void InitializeData()
    {
      Database.Load();

      dcf.TryRead(out localData);
      if (localData == null)
      {
        localData = new LocalData();
      }

      if (localData.KnownRequests == null)
      {
        localData.KnownRequests = new HashSet<uint>();
      }

      users = new BindingList<UserItem>(Database.Users);
      programs = new BindingList<ProgramItem>(Database.Programs);
      programs.ListChanged += programs_ListChanged;

      InitializeGridLookUps();
      InitializeRequestFilters();
      InitializeProgramFilters();

      requests = new BindingList<RequestItem>(Database.Requests);
      gridRequests.DataSource = requests;

      DoSignIn(localData.CurrentUserID);
    }

    protected override void OnLoad(EventArgs e)
    {
      InitializeData();
      base.OnLoad(e);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      base.OnFormClosing(e);
      if (!e.Cancel)
      {
        localData.KnownRequests.UnionWith(requests.Select(r => r.Number));
        dcf.Write(localData);
      }
    }

    private void programs_ListChanged(object sender, ListChangedEventArgs e)
    {
      RefreshProgramFilters();
    }

    private void cboRequestFilters_SelectedIndexChanged(object sender, EventArgs e)
    {
      gridViewRequests.RefreshData();
    }

    private void cboProgramFilters_EditValueChanged(object sender, EventArgs e)
    {
      gridViewRequests.RefreshData();
    }

    private void gridViewRequests_CustomRowFilter(object sender, RowFilterEventArgs e)
    {
      var requestFilter = cboRequestFilters.SelectedItem as RequestFilter;
      if (requestFilter != null)
      {
        var programFilter = cboProgramFilters.EditValue as string;
        if (!string.IsNullOrWhiteSpace(programFilter))
        {
          var item = requests[e.ListSourceRow];
          e.Visible = requestFilter.IsRequestVisible(localData, item)
            && (programFilter.Equals(AllProgramsFilter)
            || string.Equals(item.ProgramID, programFilter));
          e.Handled = true;
        }
      }
    }

    private void tbbSignInOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      AskUserToSignIn(true);
    }

    private void tbbSave_ItemClick(object sender, ItemClickEventArgs e)
    {
      Database.Save();
    }

    private void tbbUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      var data = users.Duplicate().ToList();
      using (var dlg = new SimpleItemDialog<UserItem>(data, "Users"))
      {
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          gridViewRequests.BeginDataUpdate();
          users.ReplaceWith(data);
          gridViewRequests.EndDataUpdate();
          AutoSignOutIfNeeded();
        }
      }
    }

    private void tbbPrograms_ItemClick(object sender, ItemClickEventArgs e)
    {
      var data = programs.Duplicate().ToList();
      using (var dlg = new SimpleItemDialog<ProgramItem>(data, "Programs"))
      {
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          gridViewRequests.BeginDataUpdate();
          programs.ReplaceWith(data);
          gridViewRequests.EndDataUpdate();
        }
      }
    }

    private void tbbNewRequest_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (string.IsNullOrWhiteSpace(localData.CurrentUserID) && !AskUserToSignIn(false))
      {
        XtraMessageBox.Show(this,
          "You must be signed in to create a request. Please sign in",
          "Sign In Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      var request = new RequestItem
      {
        Description = string.Empty,
        Entered = DateTime.Now,
        EnteredByID = localData.CurrentUserID,
        History = new List<RequestItemStateChange>(),
        Number = Database.Next,
        ProgramID = null,
        Reproduce = new List<ReproduceStep>(),
        State = RequestItemState.None,
        Summary = string.Empty,
      };
      request.ChangeStateTo(RequestItemState.Open, "New Request", localData.CurrentUserID);

      using (var dlg = new EditRequestItemDialog(localData, request, programs))
      {
        dlg.Text = "Add Request";
        dlg.ReadOnly = false;
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          requests.Add(request);
        }
      }
    }

    private void gridViewRequests_RowClick(object sender, RowClickEventArgs e)
    {
      if (e.Clicks == 2 && (e.Button & System.Windows.Forms.MouseButtons.Left) != 0)
      {
        EditRequestByRow(e.RowHandle);
      }
    }

    private void gridViewRequests_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
    {
      if (e.HitInfo.InRow)
      {
        var request = gridViewRequests.GetRow(e.HitInfo.RowHandle) as RequestItem;
        if (request != null)
        {
          changer = new RequestStateChanger(request, localData.CurrentUserID, this);
          popupMenu1.ShowPopup(gridRequests.PointToScreen(e.Point));
        }
        else
        {
          changer = null;
        }
      }
    }

    private void popupMenu1_BeforePopup(object sender, CancelEventArgs e)
    {
      if (changer != null)
      {
        mnuApprove.SetVisible(changer.CanApprove);
        mnuSchedule.SetVisible(changer.CanSchedule);
        mnuResolve.SetVisible(changer.CanResolve);
        mnuReject.SetVisible(changer.CanReject);
        mnuFixed.SetVisible(changer.CanFixed);
        mnuReOpen.SetVisible(changer.CanReOpen);
      }
      else
      {
        e.Cancel = true;
      }
    }

    private void mnuApprove_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.Approve())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void mnuSchedule_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.Schedule())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void mnuResolve_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.Resolve())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void mnuReject_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.Reject())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void mnuFixed_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.Fixed())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void mnuReOpen_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer != null && changer.ReOpen())
      {
        RefreshRequest(changer.Request);
      }
    }

    private void gridViewRequests_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete && gridViewRequests.SelectedRowsCount>0)
      {
        var result = XtraMessageBox.Show(this,
          "Are you sure you want to delete the selected requests?",
          "Delete Requests", MessageBoxButtons.OK, MessageBoxIcon.Question);
        if (result == System.Windows.Forms.DialogResult.No) return;
        gridViewRequests.DeleteSelectedRows();
      }
    }
  }
}