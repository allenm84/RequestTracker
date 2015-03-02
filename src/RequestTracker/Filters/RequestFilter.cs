using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTracker
{
  public abstract class RequestFilter
  {
    public virtual int Order { get { return int.MaxValue; } }
    public abstract string Description { get; }
    public abstract bool IsRequestVisible(LocalData local, RequestItem item);

    public override string ToString()
    {
      return Description;
    }
  }
}
