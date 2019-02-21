using System.Collections.Generic;

namespace CDOrganizer.Models
{
  public class Artist
  {
    private string _name;
    private int _id;
    private static List<Artist> _instances = new List<Artist> {};
    private List<CompactDisk> _compactDisks;

    public Artist(string artistName)
     {
       _name = artistName;
       _instances.Add(this);
       _id = _instances.Count;
       _compactDisks = new List<CompactDisk>{};
     }

     public string GetName()
     {
       return _name;
     }

     public int GetId()
     {
       return _id;
     }

     public static void ClearAll()
     {
       _instances.Clear();
     }

     public static List<Artist> GetAll()
     {
       return _instances;
     }

     public static Artist Find(int searchId)
     {
       return _instances[searchId-1];
     }

     public List<CompactDisk> GetCompactDisks()
     {
       return _compactDisks;
     }

     public void AddCompactDisk(CompactDisk compactDisk)
     {
       _compactDisks.Add(compactDisk);
     }
  }
}
