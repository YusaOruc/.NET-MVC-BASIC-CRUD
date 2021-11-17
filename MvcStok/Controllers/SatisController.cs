using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStockEntities db = new MvcDbStockEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLSATISLAR.ToList();
            return View(degerler);
        }
        public ActionResult SatisSil(int id)
        {
            var deger = db.TBLSATISLAR.Find(id);
            db.TBLSATISLAR.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSatis() { return View(); }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p1)
        {
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult SatisGetir(int id)
        {
            var satis = db.TBLSATISLAR.Find(id);
            return View("SatisGetir",satis);
        }
        public ActionResult Guncelle(TBLSATISLAR p1)
        {
            var satis = db.TBLSATISLAR.Find(p1.SATISID);
            satis.SATISID = p1.SATISID;
            satis.URUN = p1.URUN;
            satis.MUSTERI = p1.MUSTERI;
            satis.ADET = p1.ADET;
            satis.FIYAT = p1.FIYAT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}