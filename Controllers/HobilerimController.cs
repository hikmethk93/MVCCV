using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models;
using MVCCV.Repositories;


namespace MVCCV.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        GenericRepository<TBLHOBİLERİM> repo = new GenericRepository<TBLHOBİLERİM>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TBLHOBİLERİM p)
        {   
             var t =repo.Find(x=>x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}