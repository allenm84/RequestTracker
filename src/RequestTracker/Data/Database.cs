using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestTracker
{
  [DataContract(Name = "Database", Namespace = Database.Namespace)]
  public sealed class Database : ExtensibleDataObject
  {
    public const string Namespace = "http://www.mapa.com/apps/all/RequestTracker";

    [DataMember]
    private List<UserItem> users = new List<UserItem>();
    [DataMember]
    private List<ProgramItem> programs = new List<ProgramItem>();
    [DataMember]
    private List<RequestItem> requests = new List<RequestItem>();
    [DataMember]
    private uint requestNumber = 1;

    private Database() { }

    static string filepath;
    static DataContractSerializer dcs;
    static Database instance = new Database();

    static Database()
    {
      filepath = Path.Combine(Application.StartupPath, "requestTracker.xml");
      dcs = new DataContractSerializer(typeof(Database));
    }

    public static List<UserItem> Users 
    { 
      get { return instance.users; }
      set { instance.users = value; }
    }

    public static List<ProgramItem> Programs
    {
      get { return instance.programs; }
      set { instance.programs = value; }
    }

    public static List<RequestItem> Requests
    {
      get { return instance.requests; }
      set { instance.requests = value; }
    }

    public static uint Next
    {
      get { return instance.requestNumber++; }
    }

    public static void Load()
    {
      Database loaded = null;
      if (File.Exists(filepath))
      {
        using (var stream = File.OpenRead(filepath))
        {
          loaded = dcs.ReadObject(stream) as Database;
        }
      }

      if (loaded != null)
      {
        instance.programs = loaded.programs ?? instance.programs;
        instance.requests = loaded.requests ?? instance.requests;
        instance.users = loaded.users ?? instance.users;
        instance.requestNumber = Math.Max(1, loaded.requestNumber);
      }
    }

    public static void Save()
    {
      using (var stream = File.Create(filepath))
      {
        dcs.WriteObject(stream, instance);
      }
    }

    public static UserItem GetUser(string id)
    {
      if (string.IsNullOrWhiteSpace(id))
        return null;

      return instance.users.SingleOrDefault(u => string.Equals(u.ID, id));
    }

    internal static void Reset()
    {
      instance.programs.Clear();
      instance.requests.Clear();
      instance.users.Clear();
      instance.requestNumber = 1;
    }
  }
}
