using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RequestTracker
{
  public static class Importer
  {
    [Conditional("DEBUG")]
    public static void Import()
    {
      Database.Reset();

      string path = @"C:\Users\mallen\Dropbox\Downloads\Archive\[bin]\RequestTracker\saved.xml";
      var doc = XDocument.Parse(File.ReadAllText(path));
      var ns = XNamespace.Get("http://www.mapa.com/apps/RequestTracker");

      var products = doc.Descendants(ns + "Product");
      foreach (var p in products)
      {
        Database.Programs.Add(new ProgramItem
        {
          ID = p.Element(ns + "ID").Value,
          Name = p.Element(ns + "Name").Value,
        });
      }

      var users = doc.Descendants(ns + "User");
      foreach (var u in users)
      {
        Database.Users.Add(new UserItem
        {
          ID = u.Element(ns + "ID").Value,
          Name = u.Element(ns + "Username").Value,
        });
      }

      var requests = doc.Descendants(ns + "Request");
      foreach (var r in requests)
      {
        var request = new RequestItem
        {
          Description = r.Element(ns + "Description").Value,
          Entered = (DateTime)r.Element(ns + "DateEntered"),
          EnteredByID = r.Element(ns + "CreatedByID").Value,
          History = new List<RequestItemStateChange>(),
          Number = Database.Next,
          ProgramID = r.Element(ns + "ProductID").Value,
          Reproduce = new List<ReproduceStep>(),
          State = RequestItemState.None,
          Summary = r.Element(ns + "Summary").Value,
        };
        request.ChangeStateTo(RequestItemState.Open, "Imported from previous program", request.EnteredByID);
        Database.Requests.Add(request);
      }
    }
  }
}
