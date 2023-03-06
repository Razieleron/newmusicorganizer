using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Controllers
{
  public class TrackController : Controller
  {
    [HttpGet("/cd/{id}/tracks/new")]
    public ActionResult New(int id) 
    {
      CD thisIsOurCD = CD.GetAll()[CD.Find(id)];
      return View(thisIsOurCD);
    }

    [HttpPost("/cd/{id}/tracks")]
    public ActionResult Create(int id, string trackName)
    {
      CD thisIsOurCD = CD.GetAll()[CD.Find(id)];
      Track newTrack = new Track(trackName);
      thisIsOurCD.AddTrack(newTrack);
      return Redirect($"/cd/{id}");
      // return RedirectToAction("Index");
    }
    

// '/cd/@Model["cd"].Id/tracks/@track.Id'
    [Route("/cd/{cdId}/tracks/{trackId}/delete")]
    public ActionResult Fish(int cdId, int trackId)
    {
      CD thisIsOurCD = CD.GetAll()[CD.Find(cdId)];
      Track targetTrack = Track.GetAll()[Track.Find(trackId)];
      thisIsOurCD.Tracks.Remove(targetTrack);
      return Redirect($"/cd/{cdId}");
    }
    
  }
}