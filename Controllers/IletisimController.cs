using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<TBLİLETİSİM> repo = new GenericRepository<TBLİLETİSİM>();
        public ActionResult Index()
        {
            var Mesajlar = repo.List();
            return View(Mesajlar);
        }
    }
}