using System.Collections.Generic;
namespace MusicOrganizer.Models;

public class CD
{
  private static List<CD> _instances = new List<CD> { };
  public static int Index { get; set; } =0;
  public string Name { get; set; }
  public string Artist { get; set; }
  public List<Track> Tracks { get; set; }
  public int Id { get; set; }

  public CD(string cdName, string cdArtist)
  {
    Name = cdName;
    Artist = cdArtist;
    _instances.Add(this);
    Id = Index;
    Tracks = new List<Track> { };
    Index ++;
  }

  public static List<CD> GetAll()
  {
    return _instances;
  }

  public static void ClearAll()
  {
    _instances.Clear();
  }

  public void AddTrack(Track track)
  {
    Tracks.Add(track);
  }

  public static int Find(int searchId)
  {
    int index = -1;
    foreach (CD item in _instances)
    {
      if (item.Id == searchId)
      {
        index = _instances.IndexOf(item);
      }
    }

    return index;
  }

  public static List<CD> FindByArtist(string artist)
  {
    List<CD> list = new List<CD> { };
    foreach (CD cd in _instances) 
    {
      if (cd.Artist == artist) 
      {
        list.Add(cd);
      }
    }
    return list;
  }
}
