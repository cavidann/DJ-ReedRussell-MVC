using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;
using System.Web.Helpers;
using System.IO;





namespace Dj_ReedRussel.Areas.admin.Controllers.videoCrud
{
    public class videosController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/videos
        public ActionResult Index()
        {
            var videos = db.videos.Include(v => v.video_types);
            return View(videos.ToList());
        }

        // GET: admin/videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: admin/videos/Create
        public ActionResult Create()
        {
            ViewBag.video_types_id = new SelectList(db.video_types, "id", "name");
            return View();
        }

        // POST: admin/videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "id,cover,link,video_types_id")] video video)
        {
            if (ModelState.IsValid)
            {
                db.videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);
            return View(video);
        }


        [HttpPost]
        public ActionResult Create([Bind(Include = "id,cover,link,video_types_id")] video video, HttpPostedFileBase cover)
        {

            if (ModelState.IsValid)
            {
                if (cover.ContentType == "image/jpeg" || cover.ContentType == "image/png" || cover.ContentType == "image/gif")
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(cover.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    cover.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    video.cover = fileName;
                    //myevent.date = now;
                    db.videos.Add(video);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);
                ViewBag.Message = "Errorrr";
                return View();
            }

            return RedirectToAction("Index");
        }








        // GET: admin/videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);
            return View(video);
        }

        // POST: admin/videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1([Bind(Include = "id,cover,link,video_types_id")] video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);
            return View(video);
        }



        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "id,cover,link,video_types_id")] video video, string oldfile)
        {

            var gelensekil = HttpContext.Request.Files["cover"];
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
                    video.cover = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);

                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                video.cover = oldfile;
            }
            //blog.date = now;
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);

            return View(video);
        }



        // GET: admin/videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: admin/videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            video video = db.videos.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + video.cover);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);

            }
            db.videos.Remove(video);
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
