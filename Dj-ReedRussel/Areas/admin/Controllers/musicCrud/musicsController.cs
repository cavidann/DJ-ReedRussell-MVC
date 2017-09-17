using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

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
        public ActionResult Create([Bind(Include = "id,music_cover,music_info,music_types_id")] music music)
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
        public ActionResult Edit([Bind(Include = "id,music_cover,music_info,music_types_id")] music music)
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
