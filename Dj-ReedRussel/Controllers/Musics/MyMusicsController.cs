using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.MyMusics
{
    public class MyMusicsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: Musics
        public ActionResult Single()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.musics = db.musics.Where(b => b.music_types.name.Equals("single")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }

        public ActionResult Remix()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.musics = db.musics.Where(b => b.music_types.name.Equals("remix")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }
    }
}