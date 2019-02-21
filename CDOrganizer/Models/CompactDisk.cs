using System.Collections.Generic;

namespace CDOrganizer.Models
{
  public class CompactDisk
  {
    private string _title;
    private int _id;
    private static List<CompactDisk> _instances = new List<CompactDisk> {};

    public CompactDisk (string title)
    {
      _title = title;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }

    public static List<CompactDisk> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public int GetId()
    {
      return _id;
    }

    public static CompactDisk Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
