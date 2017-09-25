using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.MyVideos
{
    public class MyVideosController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();
        // GET: Videos
        public ActionResult Single()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.videos = db.videos.Where(b=>b.video_types.name.Equals("single")).OrderByDescending(b=>b.id).ToList();
            return View(mymodel);
        }
        public ActionResult Remix()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.videos = db.videos.Where(b => b.video_types.name.Equals("remix")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }
        public ActionResult Lesson()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.videos = db.videos.Where(b => b.video_types.name.Equals("lesson")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }
        public ActionResult Vlog()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.videos = db.videos.Where(b => b.video_types.name.Equals("vlog")).OrderByDescending(b => b.id).ToList();
            return View(mymodel);
        }

    }
}