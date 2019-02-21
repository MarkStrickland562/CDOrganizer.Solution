using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string ArtistName)
    {
      Artist newArtist = new Artist(ArtistName);
      List<Artist> allArtists = Artist.GetAll();
      return View("Index", allArtists);
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<CompactDisk> artistCompactDisks = selectedArtist.GetCompactDisks();
      model.Add("artist", selectedArtist);
      model.Add("compactDisks", artistCompactDisks);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/compactDisks")]
    public ActionResult Create(int artistId, string compactDiskTitle)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      CompactDisk newCompactDisk = new CompactDisk(compactDiskTitle);
      foundArtist.AddCompactDisk(newCompactDisk);
      List<CompactDisk> artistCompactDisks = foundArtist.GetCompactDisks();
      model.Add("compactDisks", artistCompactDisks);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }
  }
}
