using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

namespace Dj_ReedRussel.Areas.admin.Controllers.musicTypeCrud
{
    public class music_typesController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/music_types
        public ActionResult Index()
        {
            return View(db.music_types.ToList());
        }

        // GET: admin/music_types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music_types music_types = db.music_types.Find(id);
            if (music_types == null)
            {
                return HttpNotFound();
            }
            return View(music_types);
        }

        // GET: admin/music_types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/music_types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] music_types music_types)
        {
            if (ModelState.IsValid)
            {
                db.music_types.Add(music_types);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(music_types);
        }

        // GET: admin/music_types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music_types music_types = db.music_types.Find(id);
            if (music_types == null)
            {
                return HttpNotFound();
            }
            return View(music_types);
        }

        // POST: admin/music_types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] music_types music_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(music_types).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(music_types);
        }

        // GET: admin/music_types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            music_types music_types = db.music_types.Find(id);
            if (music_types == null)
            {
                return HttpNotFound();
            }
            return View(music_types);
        }

        // POST: admin/music_types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            music_types music_types = db.music_types.Find(id);
            db.music_types.Remove(music_types);
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
