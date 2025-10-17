using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TBLSERTİFİKALARIM> repo= new GenericRepository<TBLSERTİFİKALARIM>();
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var Sertifika=repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(Sertifika);
        }
        [HttpPost]

        public ActionResult SertifikaGetir(TBLSERTİFİKALARIM p) /*Güncelleme işlemi */
        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TBLSERTİFİKALARIM t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
           repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}