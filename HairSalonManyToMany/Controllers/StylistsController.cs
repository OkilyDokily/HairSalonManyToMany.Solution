using Microsoft.AspNetCore.Mvc;
using HairSalonManyToMany.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalonManyToMany.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonManyToManyContext _db;
    public StylistsController(HairSalonManyToManyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> stylists = _db.Stylists.ToList();
      return View(stylists);
    }

    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist stylist = _db.Stylists.Include(s => s.Clients).ThenInclude(sc => sc.Client).FirstOrDefault(x => x.StylistId == id);
      return View(stylist);
    }

    public ActionResult Delete(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(x => x.StylistId == id);
      return View(stylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(x => x.StylistId == id);
      _db.Stylists.Remove(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(x => x.StylistId == id);
      return View(stylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Entry(stylist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}