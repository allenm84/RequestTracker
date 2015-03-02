using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ID
{
  public static string Get
  {
    get
    {
      return Guid.NewGuid().ToString();
    }
  }
}
