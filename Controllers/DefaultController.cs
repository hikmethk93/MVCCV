using MVCCV.Models;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {

            var degerler = db.TBLHAKKİMDA.ToList();

            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TBLSOSYALMEDYA.Where(x=>x.durum==true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBLDENEYİMLERİM.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TBLEGİTİMLERİM.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TBLYETENEK.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TBLHOBİLERİM.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TBLSERTİFİKALARIM.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(TBLİLETİSİM t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLİLETİSİM.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
     
}