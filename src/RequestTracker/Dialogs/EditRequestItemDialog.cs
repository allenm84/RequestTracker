using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace RequestTracker
{
  public partial class EditRequestItemDialog : BaseForm
  {
    private RequestItem request;
    private IList<ProgramItem> programs;
    private LocalData local;
    private BindingList<ReproduceStep> steps;
    private bool cancelClose = false;
    private RequestStateChanger changer;

    private bool readOnly;
    public bool ReadOnly
    {
      get { return readOnly; }
      set
      {
        readOnly = value;
        btnEdit.Visible = readOnly;
        txtSummary.Properties.ReadOnly = readOnly;
        cboPrograms.Enabled = !readOnly;
        txtDescription.Properties.ReadOnly = readOnly;
        chkImportant.Enabled = !readOnly;
        UpdateButtons();
      }
    }

    public EditRequestItemDialog(LocalData local, RequestItem request, IList<ProgramItem> programs)
    {
      this.local = local;
      this.request = request;
      this.programs = programs;

      changer = new RequestStateChanger(request, local.CurrentUserID, this);

      InitializeComponent();
      ReadOnly = false;
      UpdateToolbar();
      ReadRequest();
    }

    private void ReadRequest()
    {
      txtSummary.Text = request.Summary;

      var combo = cboPrograms.Properties;
      var lookup = default(ProgramItem);
      combo.DataSource = programs;
      combo.DisplayMember = lookup.GetMemberName(p => p.Name);
      combo.ValueMember = lookup.GetMemberName(p => p.ID);
      combo.PopulateViewColumns();
      combo.View.Columns[lookup.GetMemberName(p => p.Name)].SortOrder = ColumnSortOrder.Ascending;
      combo.View.Columns[lookup.GetMemberName(p => p.ID)].Visible = false;
      combo.NullText = "[Please select a program]";
      cboPrograms.EditValue = request.ProgramID;

      txtDescription.Text = request.Description;

      steps = new BindingList<ReproduceStep>(request.Reproduce);
      lstStepsToReproduce.DataSource = steps;
      lstStepsToReproduce.DisplayMember = "Text";
      steps.ListChanged += steps_ListChanged;

      lstHistory.DisplayMember = "Display";
      lstHistory.ValueMember = "Value";
      UpdateHistory();

      chkImportant.Checked = request.IsImportant;
    }

    private void WriteRequest()
    {
      request.Summary = txtSummary.Text;
      request.ProgramID = cboPrograms.EditValue as string;
      request.Description = txtDescription.Text;
      request.IsImportant = chkImportant.Checked;
    }

    private void UpdateHistory()
    {
      lstHistory.DataSource = request.History
        .Select(h => new { Display = GetDisplay(h), Value = h })
        .ToList();
      lstHistory.SelectedIndex = request.History.Count - 1;
    }

    private bool VerifyCanClose()
    {
      WriteRequest();

      bool valid = true;
      if (string.IsNullOrWhiteSpace(request.ProgramID))
      {
        valid = false;
        XtraMessageBox.Show(this,
          "Please select a program", "Program Needed", 
          MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      return valid;
    }

    private static string GetDisplay(RequestItemStateChange h)
    {
      var user = Database.GetUser(h.UserID);
      return string.Format("{0}: {1} => {2} by {3}",
        h.Date, h.Previous, h.Current, (user != null) ? user.Name : "Unknown");
    }

    private void UpdateToolbar()
    {
      tbbState.Caption = string.Format("State: {0}", request.State);

      tbbApprove.SetVisible(changer.CanApprove);
      tbbSchedule.SetVisible(changer.CanSchedule);
      tbbResolve.SetVisible(changer.CanResolve);
      tbbReject.SetVisible(changer.CanReject);
      tbbFixed.SetVisible(changer.CanFixed);
      tbbReOpen.SetVisible(changer.CanReOpen);

      barActions.Visible = new BarItem[]
      { 
        tbbState,
        tbbApprove,
        tbbSchedule,
        tbbResolve,
        tbbReject,
        tbbFixed,
        tbbReOpen
      }.Any(t => t.GetVisible());
    }

    private void UpdateButtons()
    {
      btnAddStep.Enabled = !readOnly;
      btnRemoveStep.Enabled = !readOnly && lstStepsToReproduce.SelectedIndex > -1;
      btnEditStep.Enabled = !readOnly && lstStepsToReproduce.SelectedIndex > -1;
    }

    private void RefreshData()
    {
      UpdateToolbar();
      UpdateHistory();
    }

    private void EditStepByIndex(int index)
    {
      EditStepByItem(lstStepsToReproduce.GetItem(index) as ReproduceStep);
    }

    private void EditStepByItem(ReproduceStep step)
    {
      if (step == null) return;
      var index = steps.IndexOf(step);

      using (var dlg = new InputBox())
      {
        dlg.Text = "Edit Reproduce Step";
        dlg.Prompt = string.Format("Step {0}:", index + 1);
        dlg.Input = step.Text;

        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          step.Text = dlg.Input;
          steps.ResetItem(index);
        }
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateButtons();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (cancelClose)
      {
        e.Cancel = true;
        cancelClose = false;
      }
      base.OnFormClosing(e);
    }

    private void tbbApprove_ItemClick(object sender, ItemClickEventArgs e)
    {
      changer.Approve();
      RefreshData();
    }

    private void tbbSchedule_ItemClick(object sender, ItemClickEventArgs e)
    {
      changer.Schedule();
      RefreshData();
    }

    private void tbbResolve_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer.Resolve())
      {
        RefreshData();
      }
    }

    private void tbbReject_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer.Reject())
      {
        RefreshData();
      }
    }

    private void tbbFixed_ItemClick(object sender, ItemClickEventArgs e)
    {
      changer.Fixed();
      RefreshData();
    }

    private void tbbReOpen_ItemClick(object sender, ItemClickEventArgs e)
    {
      if (changer.ReOpen())
      {
        RefreshData();
      }
    }

    private void cboPrograms_AddNewValue(object sender, AddNewValueEventArgs e)
    {
      using (var dlg = new InputBox())
      {
        dlg.Text = "Add Program";
        dlg.Prompt = "Name:";
        dlg.Input = cboPrograms.GetFindText();

        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          var prog = new ProgramItem { ID = ID.Get, Name = dlg.Input };
          programs.Add(prog);
          e.NewValue = prog.ID;
          e.Cancel = false;
        }
        else
        {
          e.Cancel = true;
        }
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      var result = XtraMessageBox.Show(this,
        "Are you sure you want to edit this request?",
        "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == System.Windows.Forms.DialogResult.No) return;
      ReadOnly = false;
    }

    private void steps_ListChanged(object sender, ListChangedEventArgs e)
    {
      UpdateButtons();
    }

    private void btnAddStep_Click(object sender, EventArgs e)
    {
      using (var dlg = new InputBox())
      {
        dlg.Text = "Add Reproduce Step";
        dlg.Prompt = string.Format("Step {0}:", steps.Count + 1);
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          steps.Add(new ReproduceStep { Text = dlg.Input });
        }
      }
    }

    private void btnEditStep_Click(object sender, EventArgs e)
    {
      EditStepByIndex(lstStepsToReproduce.SelectedIndex);
    }

    private void btnRemoveStep_Click(object sender, EventArgs e)
    {
      var result = XtraMessageBox.Show(this,
        "Are you sure you want to remove the selected steps?",
        "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == System.Windows.Forms.DialogResult.No) return;

      var remove = lstStepsToReproduce.SelectedIndices
        .Select(i => lstStepsToReproduce.GetItem(i))
        .Cast<ReproduceStep>()
        .ToArray();

      lstStepsToReproduce.BeginUpdate();
      foreach (var r in remove)
        steps.Remove(r);
      lstStepsToReproduce.EndUpdate();
    }

    private void lstStepsToReproduce_SelectedIndexChanged(object sender, EventArgs e)
    {
      UpdateButtons();
    }

    private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
    {
      var h = lstHistory.SelectedValue as RequestItemStateChange;
      if (h == null) return;
      txtHistoryNotes.Text = h.Notes;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      cancelClose = !VerifyCanClose();
    }

    private void lstStepsToReproduce_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if ((e.Button & System.Windows.Forms.MouseButtons.Left) != 0)
      {
        EditStepByIndex(lstStepsToReproduce.IndexFromPoint(e.Location));
      }
    }
  }
}
