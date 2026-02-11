using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class CanliDersController : Controller
    {
        
        // GET: CanliDers
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var liste = db.tblCanliDerslers.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.Dersler = new SelectList(db.tblDerslers, "DERSID", "DERSAD");

            return View();
        }
        [HttpPost]
        public  ActionResult Ekle(tblCanliDersler p)
        {
            p.ISACTIVE = true;
            db.tblCanliDerslers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}