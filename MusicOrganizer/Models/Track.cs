using System.Collections.Generic;
namespace MusicOrganizer.Models;

public class Track
{
  public string TrackName { get; set; }
  public static int Index { get; set; } = 0;
  private static List<Track> _instances = new List<Track> { };
  public int Id { get; set; }


  public Track(string trackName)
  {
    TrackName = trackName;
    _instances.Add(this);
    Id = Index;
    Track.Index ++;
  }

  public static List<Track> GetAll()
  {
    return _instances;
  }

  public static void ClearAll()
  {
    _instances.Clear();
  }

  public static int Find(int searchId)
  {
    int index = -1;
    foreach (Track item in _instances)
    {
      if (item.Id == searchId)
      {
        index = _instances.IndexOf(item);
      }
    }

    return index;
  }
}

