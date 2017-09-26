using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.AlbumItem
{
    public class AlbumItemController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();
        // GET: AlbumItem
        public ActionResult Index(int? id)
        {
            dynamic mymodel = new ExpandoObject();
            album_or_radioshow album_id = db.album_or_radioshow.Find(id);
            mymodel.tracklists = db.tracklists.Where(i => i.album_or_radishow_id == album_id.id).ToList();
            mymodel.album_item = album_id;
            mymodel.otheralbums = db.album_or_radioshow.Where(o => o.id != album_id.id && o.page_name.name.Equals("album")).Take(4).OrderByDescending(o => o.id).ToList();
            return View(mymodel);
        }
        public ActionResult Radioshow_item(int? id)
        {
            dynamic mymodel = new ExpandoObject();
            album_or_radioshow album_id = db.album_or_radioshow.Find(id);
            mymodel.tracklists = db.tracklists.Where(i => i.album_or_radishow_id == album_id.id).ToList();
            mymodel.album_item = album_id;
            mymodel.otheralbums = db.album_or_radioshow.Where(o => o.id != album_id.id && o.page_name.name.Equals("radioshow")).Take(4).OrderByDescending(o => o.id).ToList();
            return View(mymodel);
        }
    }
}