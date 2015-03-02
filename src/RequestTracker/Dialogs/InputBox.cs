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
  public partial class InputBox : BaseForm
  {
    public string Prompt
    {
      get { return layoutControlGroup2.Text; }
      set { layoutControlGroup2.Text = value; }
    }

    public string Input
    {
      get { return textEdit1.Text; }
      set { textEdit1.Text = value; }
    }

    public InputBox()
    {
      InitializeComponent();
    }
  }
}
