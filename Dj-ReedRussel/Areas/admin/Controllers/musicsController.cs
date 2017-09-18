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

namespace Dj_ReedRussel.Areas.admin.Controllers.musics
{
    public class musicsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/musics
        public ActionResult Index()
        {
            var musics = db.musics.Include(m => m.music_types);
            return View(musics.ToList());
        }

        // GET: admin/musics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music music = db.musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        // GET: admin/musics/Create
        public ActionResult Create()
        {
            ViewBag.music_types_id = new SelectList(db.music_types, "id", "name");
            return View();
        }

        // POST: admin/musics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "id,music_cover,music_info,music_types_id,music_src")] music music)
        {
            if (ModelState.IsValid)
            {
                db.musics.Add(music);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
            return View(music);
        }



        [HttpPost]
        public ActionResult Create([Bind(Include = "id,music_cover,music_info,music_types_id,music_src")] music music, HttpPostedFileBase music_cover, HttpPostedFileBase music_src)
        {

            if (ModelState.IsValid)
            {
                if (music_cover.ContentType == "image/jpeg" || music_cover.ContentType == "image/png" || music_cover.ContentType == "image/gif")
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(music_cover.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    music_cover.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    music.music_cover = fileName;
                    //myevent.date = now;
                    //db.musics.Add(music);
                    //db.SaveChanges();
                }
                else
                {
                    ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
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
                    music.music_src = fileName;
                    //myevent.date = now;
                    db.musics.Add(music);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
                    ViewBag.Message = "You can only music file";
                    return View();
                }
            }
            else
            {
                ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
                ViewBag.Message = "Errorrr";
                return View();
            }

            return RedirectToAction("Index");
        }






        // GET: admin/musics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music music = db.musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
            return View(music);
        }

        // POST: admin/musics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1([Bind(Include = "id,music_cover,music_info,music_types_id,music_src")] music music)
        {
            if (ModelState.IsValid)
            {
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
            return View(music);
        }



        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "id,music_cover,music_info,music_types_id,music_src")] music music, string oldfile, string oldfile1)
        {

            var gelensekil = HttpContext.Request.Files["music_cover"];
            var gelenmahni = HttpContext.Request.Files["music_src"];

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
                    music.music_cover = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                music.music_cover = oldfile;
            }


            if (gelenmahni.FileName.Length > 0)
            {

                if (1==1)
                {

                    string fullPath = Request.MapPath("~/Uploads/" + oldfile1);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelenmahni.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelenmahni.SaveAs(newfile);
                    music.music_src = fileName;
                    //blog.date = now;

                }
                else
                {
                    ViewBag.music_types_id = new SelectList(db.music_types, "id", "name", music.music_types_id);
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                music.music_src = oldfile1;
            }

            //blog.date = now;
            if (ModelState.IsValid)
            {
                db.Entry(music).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.video_types_id = new SelectList(db.video_types, "id", "name", video.video_types_id);

            return View(music);
        }




        // GET: admin/musics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music music = db.musics.Find(id);
            if (music == null)
            {
                return HttpNotFound();
            }
            return View(music);
        }

        // POST: admin/musics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            music music = db.musics.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + music.music_cover);
            string fullPath1 = Request.MapPath("~/Uploads/" + music.music_src);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                System.IO.File.Delete(fullPath1);

            }
            db.musics.Remove(music);
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
