using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class NotHesaplaController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: NotHesapla
        [HttpGet]
        public ActionResult notHesapla()
        {
            var notlar = db.tblNotlars.ToList();
            return View(notlar);
        }
        [HttpPost]
        public ActionResult notHesapla(decimal sinav1=0, decimal sinav2=0 , decimal sinav3 = 0, decimal projeNotu = 0,decimal ortalama   = 0) 
        {
            
            ortalama = (sinav1 + sinav2 + sinav3 + projeNotu) / 4;
            ViewBag.Ortalama = ortalama;
            ViewBag.Durum = ortalama >= 50 ? "Geçti" : "Kaldı";
            return View();




        }

    }
}