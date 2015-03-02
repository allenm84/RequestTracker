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
  public partial class MultilineInputBox : BaseForm
  {
    public string Prompt
    {
      get { return layoutControlGroup2.Text; }
      set { layoutControlGroup2.Text = value; }
    }

    public string Input
    {
      get { return memoEdit1.Text; }
      set { memoEdit1.Text = value; }
    }

    public MultilineInputBox()
    {
      InitializeComponent();
    }
  }
}
