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

namespace Dj_ReedRussel.Areas.admin.Controllers.albumOrRadioshowCrud
{
    public class album_or_radioshowController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/album_or_radioshow
        public ActionResult Index()
        {

            var album_or_radioshow = db.album_or_radioshow.Include(a => a.tracklist).Include(a => a.page_name);
            return View(album_or_radioshow.ToList());
        }

        // GET: admin/album_or_radioshow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
            if (album_or_radioshow == null)
            {
                return HttpNotFound();
            }
            return View(album_or_radioshow);
        }

        // GET: admin/album_or_radioshow/Create
        public ActionResult Create()
        {
            ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name");
            ViewBag.page_name_id = new SelectList(db.page_name, "id", "name");
            return View();
        }

        // POST: admin/album_or_radioshow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type,src")] album_or_radioshow album_or_radioshow)
        {
            if (ModelState.IsValid)
            {
                db.album_or_radioshow.Add(album_or_radioshow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
            ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
            return View(album_or_radioshow);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type,src")] album_or_radioshow album_or_radioshow, HttpPostedFileBase cover, HttpPostedFileBase src)
        {

            if (ModelState.IsValid)
            {
                if (cover.ContentType == "image/jpeg" || cover.ContentType == "image/png" ||cover.ContentType == "image/gif")
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(cover.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    cover.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    album_or_radioshow.cover = fileName;
                    //myevent.date = now;
                    //db.musics.Add(music);
                    //db.SaveChanges();
                }
                else
                {
                    ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
                    ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
                if (1 == 1)
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(src.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    src.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    album_or_radioshow.src = fileName;
                    //myevent.date = now;
                    db.album_or_radioshow.Add(album_or_radioshow);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
                    ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
                    ViewBag.Message = "You can only music file";
                    return View();
                }
            }
            else
            {
                ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
                ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
                ViewBag.Message = "Errorrr";
                return View();
            }

            return RedirectToAction("Index");
        }


        // GET: admin/album_or_radioshow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
            if (album_or_radioshow == null)
            {
                return HttpNotFound();
            }
            ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
            ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
            return View(album_or_radioshow);
        }

        // POST: admin/album_or_radioshow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1([Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type,src")] album_or_radioshow album_or_radioshow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album_or_radioshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
            ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
            return View(album_or_radioshow);
        }



        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type,src")] album_or_radioshow album_or_radioshow, string oldfile, string oldfile1)
        {

            var gelensekil = HttpContext.Request.Files["cover"];
            var gelenmahni = HttpContext.Request.Files["src"];

            DateTime now = DateTime.Now;
            if (gelensekil.FileName.Length > 0)
            {

                if (gelensekil.ContentType == "image/jpeg" || gelensekil.ContentType == "image/png" || gelensekil.ContentType == "image/gif")
                {

                    string fullPath = Request.MapPath("~/Uploads/" + oldfile);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelensekil.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelensekil.SaveAs(newfile);
                    album_or_radioshow.cover = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
                    ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id); ;
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                album_or_radioshow.cover = oldfile;
            }


            if (gelenmahni.FileName.Length > 0)
            {

                if (1 == 1)
                {

                    string fullPath = Request.MapPath("~/Uploads/" + oldfile1);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelenmahni.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelenmahni.SaveAs(newfile);
                    album_or_radioshow.src = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.tracklist_id = new SelectList(db.tracklists, "id", "music_name", album_or_radioshow.tracklist_id);
                    ViewBag.page_name_id = new SelectList(db.page_name, "id", "name", album_or_radioshow.page_name_id);
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                album_or_radioshow.src = oldfile1;
            }

            //blog.date = now;
            if (ModelState.IsValid)
            {
                db.Entry(album_or_radioshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);

            return View(album_or_radioshow);
        }







        // GET: admin/album_or_radioshow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
            if (album_or_radioshow == null)
            {
                return HttpNotFound();
            }
            return View(album_or_radioshow);
        }

        // POST: admin/album_or_radioshow/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
        //    db.album_or_radioshow.Remove(album_or_radioshow);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + album_or_radioshow.cover);
            string fullPath1 = Request.MapPath("~/Uploads/" + album_or_radioshow.src);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                System.IO.File.Delete(fullPath1);

            }
            db.album_or_radioshow.Remove(album_or_radioshow);
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
