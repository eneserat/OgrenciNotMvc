using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Default
        public ActionResult Index()
        {
            var dersler = db.tblDerslers.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(tblDersler p) 
        { 
            db.tblDerslers.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.tblDerslers.Find(id);
            db.tblDerslers.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir( int id )
        {
            var ders = db.tblDerslers.Find(id);
            return View(ders);

        }
        [HttpPost]

        public ActionResult Guncelle(tblDersler p)
        {
            var ders = db.tblDerslers.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult OgrenciGetir(int id )
        {
            var ogrenci=db.tblOgrencilers.Find(id);
            return View("Index", ogrenci);

        }
    }
}