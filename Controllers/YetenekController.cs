using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class YetenekController : Controller
    {

        GenericRepository<TBLYETENEK> repo = new GenericRepository<TBLYETENEK>();
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLYETENEK p)

        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TBLYETENEK p)
        {   
            var y = repo.Find(x => x.ID == p.ID);
            y.Yetenek = p.Yetenek;
            y.Oran = p.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }

    }

}