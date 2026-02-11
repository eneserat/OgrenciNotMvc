using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var notlar = db.tblNotlars.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav() 
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniSinav(tblNotlar tbn) 
        {
            db.tblNotlars.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult NotGetir(int id) 
        {
            var notlar = db.tblNotlars.Find(id);
            return View("NotGetir",notlar);

            
        }
    }
}