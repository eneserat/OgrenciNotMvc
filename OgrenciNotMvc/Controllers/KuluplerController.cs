using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.tblKuluplers.ToList();
            return View(kulupler);

            
        }
        [HttpGet]
        public ActionResult YeniKulup() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(tblKulupler p2)
        { 
            db.tblKuluplers.Add(p2);
            db.SaveChanges();
            return View();

        }
        public ActionResult KulupSil(int id) 
        {
            var kulup = db.tblKuluplers.Find(id);
            db.tblKuluplers.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id )
        {
            var kulup2 = db.tblKuluplers.Find(id);

            return View("Index",kulup2);
           
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kulup = db.tblKuluplers.Find(id);
            return View("KulupGetir", kulup);
        }

        [HttpPost]
        public ActionResult Guncelle(tblKulupler p)
        {
            var kulup = db.tblKuluplers.Find(p.KULUPID);
            kulup.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}