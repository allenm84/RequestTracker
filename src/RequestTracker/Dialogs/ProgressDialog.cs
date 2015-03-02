using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestTracker
{
  public partial class ProgressDialog : BaseForm
  {
    public ProgressDialog()
    {
      InitializeComponent();
    }

    public static Form Create(Form parent)
    {
      ProgressDialog child = new ProgressDialog();
      child.StartPosition = FormStartPosition.Manual;
      child.Location = new Point(parent.Location.X + (parent.Width - child.Width) / 2, parent.Location.Y + (parent.Height - child.Height) / 2);
      return child;
    }
  }
}
