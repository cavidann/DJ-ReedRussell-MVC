using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

namespace Dj_ReedRussel.Areas.admin.Controllers.tracklistCrud
{
    public class tracklistsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/tracklists
        public ActionResult Index()
        {
            return View(db.tracklists.ToList());
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
            return View();
        }

        // POST: admin/tracklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,music_name,music_time,music_src")] tracklist tracklist)
        {
            if (ModelState.IsValid)
            {
                db.tracklists.Add(tracklist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tracklist);
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
            return View(tracklist);
        }

        // POST: admin/tracklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,music_name,music_time,music_src")] tracklist tracklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
