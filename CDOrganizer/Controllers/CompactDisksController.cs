using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;
using System.Collections.Generic;

namespace CDOrganizer.Controllers
{
  public class CompactDisksController : Controller
  {

    [HttpGet("/artists/{artistId}/compactDisks/new")]
    public ActionResult New(int artistId)
    {
       Artist artist = Artist.Find(artistId);
       return View(artist);
    }

    [HttpGet("/artists/{artistId}/compactDisks/{compactDiskId}")]
    public ActionResult Show(int artistId, int compactDiskId)
    {
      CompactDisk compactDisk = CompactDisk.Find(compactDiskId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist artist = Artist.Find(artistId);
      model.Add("compactdisk", compactDisk);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpPost("/compactDisks/delete")]
     public ActionResult DeleteAll()
     {
       CompactDisk.ClearAll();
       return View();
     }
  }
}
