using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.MyHome
{
    public class MyHomeController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();
        // GET: MyHome
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.videos = db.videos.OrderByDescending(s=>s.id).Take(4).ToList();
            mymodel.albums = db.album_or_radioshow.Where(b => b.page_name.name.Equals("album")).OrderByDescending(b => b.id).Take(4).ToList();
            mymodel.events = db.myevents.OrderByDescending(s => s.id).Take(3).ToList();
            return View(mymodel);
        }
    }
}