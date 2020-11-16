using Microsoft.AspNetCore.Mvc;
using HairSalonManyToMany.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace HairSalonManyToMany.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonManyToManyContext _db;
    public ClientsController(HairSalonManyToManyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> clients = _db.Clients.Include(x => x.Stylists).ThenInclude(x => x.Stylist).ToList();
      return View(clients);
    }

    public ActionResult Create()
    {
      ViewBag.AnyStylists = _db.Stylists.ToList().Count != 0;
      ViewBag.StylistId = new SelectList(_db.Stylists.Select(s => new { StylistId = s.StylistId, FullName = (s.FirstName + " " + s.LastName) }), "StylistId", "FullName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client, int stylistid)
    {
      _db.Clients.Add(client);
      _db.ClientStylists.Add(new ClientStylist { ClientId = client.ClientId, StylistId = stylistid });
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAnotherStylist(int id)
    {
      ViewBag.StylistId = new SelectList(_db.Stylists.Select(s => new { StylistId = s.StylistId, FullName = (s.FirstName + " " + s.LastName) }), "StylistId", "FullName");
      Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
      return View(client);
    }

    [HttpPost]
    public ActionResult AddAnotherStylist(int id, int stylistid)
    {
      _db.ClientStylists.Add(new ClientStylist { ClientId = id, StylistId = stylistid });
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
      return View(client);
    }

    public ActionResult Delete(int id)
    {
      Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
      return View(client);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
      _db.Clients.Remove(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "LastName");
      Client client = _db.Clients.FirstOrDefault(x => x.ClientId == id);
      return View(client);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}