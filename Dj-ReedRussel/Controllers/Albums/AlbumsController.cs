using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.Albums
{
    public class AlbumsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();
        // GET: Albums
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.albums = db.album_or_radioshow.Where(b => b.page_name.name.Equals("album")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }
        public ActionResult Radioshow()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.albums = db.album_or_radioshow.Where(b => b.page_name.name.Equals("radioshow")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }
    }
}