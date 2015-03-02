using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RequestTracker
{
  public partial class SimpleItemDialog<T> : BaseForm where T : class, ISimpleItem, new()
  {
    private BindingList<T> list;

    public SimpleItemDialog(IList<T> items, string text = null)
    {
      InitializeComponent();
      list = new BindingList<T>(items);
      list.ListChanged += list_ListChanged;

      if (string.IsNullOrWhiteSpace(text))
      {
        text = typeof(T).Name + "s";
      }

      layoutControlGroup2.Text = text;
      Text = text;

      gridItems.DataSource = list;
    }

    private void UpdateButtons()
    {
      btnEdit.Enabled = gridViewItems.SelectedRowsCount == 1;
      btnRemove.Enabled = gridViewItems.SelectedRowsCount > 0;
      btnClear.Enabled = list.Count > 0;
    }

    private void EditItemByItem(T item)
    {
      if (item == null) return;
      using (var dlg = new InputBox())
      {
        dlg.Prompt = "Name:";
        dlg.Text = "Edit Item";
        dlg.Input = item.Name;
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          item.Name = dlg.Input;
          list.ResetItem(list.IndexOf(item));
        }
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UpdateButtons();
    }

    private void list_ListChanged(object sender, ListChangedEventArgs e)
    {
      UpdateButtons();
    }

    private void gridViewItems_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
    {
      UpdateButtons();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      using (var dlg = new InputBox())
      {
        dlg.Prompt = "Name:";
        dlg.Text = "Add Item";
        if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        {
          list.Add(new T
          {
            ID = ID.Get,
            Name = dlg.Input,
          });
        }
      }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      EditItemByItem(gridViewItems.GetFocusedRow() as T);
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
      var result = XtraMessageBox.Show(this, "Are you sure you want to remove the selected items?", "Remove",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == System.Windows.Forms.DialogResult.No) return;
      gridViewItems.DeleteSelectedRows();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      var result = XtraMessageBox.Show(this, "Are you sure you want to clear ALL the items?", "Clear",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == System.Windows.Forms.DialogResult.No) return;
      list.Clear();
    }

    private void gridItems_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if ((e.Button & System.Windows.Forms.MouseButtons.Left) != 0)
      {
        var info = gridViewItems.CalcHitInfo(e.Location);
        EditItemByItem(gridViewItems.GetRow(info.RowHandle) as T);
      }
    }
  }
}
