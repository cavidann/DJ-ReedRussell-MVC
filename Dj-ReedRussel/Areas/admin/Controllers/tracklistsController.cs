using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;
using System.IO;

namespace Dj_ReedRussel.Areas.admin.Controllers
{
    public class tracklistsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/tracklists
        public ActionResult Index()
        {
            var tracklists = db.tracklists.Include(t => t.album_or_radioshow);
            return View(tracklists.ToList());
        }

        // GET: admin/tracklists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tracklist tracklist = db.tracklists.Find(id);
            if (tracklist == null)
            {
                return HttpNotFound();
            }
            return View(tracklist);
        }

        // GET: admin/tracklists/Create
        public ActionResult Create()
        {
            ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover");
            return View();
        }

        // POST: admin/tracklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,music_name,music_time,music_src,album_or_radishow_id")] tracklist tracklist, HttpPostedFileBase music_src)
        {
            if (ModelState.IsValid)
            {
                if (1==1)
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(music_src.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    music_src.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    tracklist.music_src = fileName;
                    //myevent.date = now;
                    //db.musics.Add(music);
                    db.tracklists.Add(tracklist);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover", tracklist.album_or_radishow_id);
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }

            }
            else
            {
                ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover", tracklist.album_or_radishow_id);
                ViewBag.Message = "Errorrr";
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: admin/tracklists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tracklist tracklist = db.tracklists.Find(id);
            if (tracklist == null)
            {
                return HttpNotFound();
            }
            ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover", tracklist.album_or_radishow_id);
            return View(tracklist);
        }

        // POST: admin/tracklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "id,music_name,music_time,music_src,album_or_radishow_id")] tracklist tracklist, string oldfile)
        {

            var gelenmahni = HttpContext.Request.Files["music_src"];

            DateTime now = DateTime.Now;
            if (gelenmahni.FileName.Length > 0)
            {

                if (1==1)
                {

                    string fullPath = Request.MapPath("~/Uploads/" + oldfile);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelenmahni.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelenmahni.SaveAs(newfile);
                    tracklist.music_src = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover", tracklist.album_or_radishow_id);
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                tracklist.music_src= oldfile;
            }



            //blog.date = now;
            if (ModelState.IsValid)
            {
                db.Entry(tracklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);

            return View(tracklist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1([Bind(Include = "id,music_name,music_time,music_src,album_or_radishow_id")] tracklist tracklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.album_or_radishow_id = new SelectList(db.album_or_radioshow, "id", "cover", tracklist.album_or_radishow_id);
            return View(tracklist);
        }

        // GET: admin/tracklists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tracklist tracklist = db.tracklists.Find(id);
            if (tracklist == null)
            {
                return HttpNotFound();
            }
            return View(tracklist);
        }

        // POST: admin/tracklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tracklist tracklist = db.tracklists.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + tracklist.music_src);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.tracklists.Remove(tracklist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
