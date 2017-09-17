using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

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
        public ActionResult Create([Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type")] album_or_radioshow album_or_radioshow)
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
        public ActionResult Edit([Bind(Include = "id,cover,header,author,info,tracklist_id,page_name_id,album_type")] album_or_radioshow album_or_radioshow)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            album_or_radioshow album_or_radioshow = db.album_or_radioshow.Find(id);
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
