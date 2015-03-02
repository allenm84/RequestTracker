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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Editors;

namespace RequestTracker
{
  public partial class SelectUserDialog : BaseForm
  {
    private bool cancelClose = false;
    private BindingList<UserItem> users;

    public string SelectedUserID
    {
      get { return cboUsers.EditValue as string; }
      set { cboUsers.EditValue = value; }
    }

    public bool AllowNullUser { get; set; }

    public SelectUserDialog(IList<UserItem> userList)
    {
      AllowNullUser = false;
      users = new BindingList<UserItem>(userList);

      InitializeComponent();

      var lookup = default(UserItem);
      cboUsers.Properties.DataSource = users;
      cboUsers.Properties.ShowAddNewButton = true;
      cboUsers.Properties.DisplayMember = lookup.GetMemberName(u => u.Name);
      cboUsers.Properties.ValueMember = lookup.GetMemberName(u => u.ID);
      cboUsers.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      cboUsers.Properties.View.OptionsView.ShowColumnHeaders = false;
      cboUsers.Properties.View.OptionsView.ShowIndicator = false;
      cboUsers.Properties.PopupFormSize = new System.Drawing.Size(220, 220);
      cboUsers.Properties.PopulateViewColumns();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      var lookup = default(UserItem);
      cboUsers.Properties.View.Columns[lookup.GetMemberName(u => u.ID)].Visible = false;
      cboUsers.Properties.View.Columns[lookup.GetMemberName(u => u.Name)].SortOrder = ColumnSortOrder.Ascending;
      cboUsers.Properties.NullText = "[Please select a user]";
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (cancelClose)
      {
        cancelClose = false;
        e.Cancel = true;
      }
      base.OnFormClosing(e);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (!AllowNullUser && string.IsNullOrWhiteSpace(SelectedUserID))
      {
        XtraMessageBox.Show(this,
          "Please select a user", "User Needed", 
          MessageBoxButtons.OK, MessageBoxIcon.Information);
        cancelClose = true;
      }
    }

    private void cboUsers_AddNewValue(object sender, AddNewValueEventArgs e)
    {
      using (var dlg = new InputBox())
      {
        dlg.Prompt = "Username:";
        dlg.Input = cboUsers.GetFindText();
        dlg.Text = "Add New User";
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          var user = new UserItem { ID = ID.Get, Name = dlg.Input };
          users.Add(user);
          e.NewValue = user.ID;
        }
        else
        {
          e.Cancel = true;
        }
      }
    }
  }
}
