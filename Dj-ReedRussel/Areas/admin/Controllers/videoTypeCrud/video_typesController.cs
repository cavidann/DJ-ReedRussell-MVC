using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

namespace Dj_ReedRussel.Areas.admin.Controllers.NewFolder1
{
    public class video_typesController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/video_types
        public ActionResult Index()
        {
            return View(db.video_types.ToList());
        }

        // GET: admin/video_types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video_types video_types = db.video_types.Find(id);
            if (video_types == null)
            {
                return HttpNotFound();
            }
            return View(video_types);
        }

        // GET: admin/video_types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/video_types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] video_types video_types)
        {
            if (ModelState.IsValid)
            {
                db.video_types.Add(video_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video_types);
        }

        // GET: admin/video_types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video_types video_types = db.video_types.Find(id);
            if (video_types == null)
            {
                return HttpNotFound();
            }
            return View(video_types);
        }

        // POST: admin/video_types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] video_types video_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video_types);
        }

        // GET: admin/video_types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video_types video_types = db.video_types.Find(id);
            if (video_types == null)
            {
                return HttpNotFound();
            }
            return View(video_types);
        }

        // POST: admin/video_types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            video_types video_types = db.video_types.Find(id);
            db.video_types.Remove(video_types);
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
