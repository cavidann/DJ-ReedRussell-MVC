using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dj_ReedRussel.Models;

namespace Dj_ReedRussel.Areas.admin.Controllers.eventCrud
{
    public class myeventsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/myevents
        public ActionResult Index()
        {
            return View(db.myevents.ToList());
        }

        // GET: admin/myevents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myevent myevent = db.myevents.Find(id);
            if (myevent == null)
            {
                return HttpNotFound();
            }
            return View(myevent);
        }

        // GET: admin/myevents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/myevents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,event_name,event_info,eventdatetime,event_cover,event_bk_photo")] myevent myevent)
        {
            if (ModelState.IsValid)
            {
                db.myevents.Add(myevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myevent);
        }

        // GET: admin/myevents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myevent myevent = db.myevents.Find(id);
            if (myevent == null)
            {
                return HttpNotFound();
            }
            return View(myevent);
        }

        // POST: admin/myevents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,event_name,event_info,eventdatetime,event_cover,event_bk_photo")] myevent myevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myevent);
        }

        // GET: admin/myevents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myevent myevent = db.myevents.Find(id);
            if (myevent == null)
            {
                return HttpNotFound();
            }
            return View(myevent);
        }

        // POST: admin/myevents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            myevent myevent = db.myevents.Find(id);
            db.myevents.Remove(myevent);
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
