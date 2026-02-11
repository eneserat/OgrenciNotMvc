using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;    

namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.tblOgrencilers.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci() 
        {
            List<SelectListItem> degerler = (from i in db.tblKuluplers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.KULUPAD,
                                                 Value=i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr=degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(tblOgrenciler p3) 
        {
            var klp = db.tblKuluplers.Where(m => m.KULUPID == p3.tblKulupler.KULUPID).FirstOrDefault();
            p3.tblKulupler = klp;
            db.tblOgrencilers.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
            //İndex e Yönlendirildi//

        }
        public ActionResult Sil(int id )
        {
            var ogrenci = db.tblOgrencilers.Find(id);
            db.tblOgrencilers.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Ogrenci/OgrenciGetir/5
        public ActionResult OgrenciGetir(int? id) // nullable yaptık
        {
            if (id == null)
                return RedirectToAction("Index"); // id gelmezse anasayfaya at

            var ogrenci = db.tblOgrencilers.Find(id);
            if (ogrenci == null)
                return HttpNotFound();

            return View(ogrenci);
        }

        // POST: Ogrenci/OgrenciGetir
        [HttpPost]
        public ActionResult OgrenciGetir(tblOgrenciler model)
        {
            if (ModelState.IsValid)
            {
                var ogrenci = db.tblOgrencilers.Find(model.OGRENCIID);
                if (ogrenci != null)
                {
                    ogrenci.OGRENCIAD = model.OGRENCIAD;
                    ogrenci.OGRENCISOYADI = model.OGRENCISOYADI;
                    ogrenci.OGRENCIFOTOGRAF = model.OGRENCIFOTOGRAF;
                    ogrenci.OGRENCIKULUP = model.OGRENCIKULUP;
                    ogrenci.OGRENCICINSIYET = model.OGRENCICINSIYET;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
        
    }
}