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
    public class page_nameController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/page_name
        public ActionResult Index()
        {
            return View(db.page_name.ToList());
        }

        // GET: admin/page_name/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page_name page_name = db.page_name.Find(id);
            if (page_name == null)
            {
                return HttpNotFound();
            }
            return View(page_name);
        }

        // GET: admin/page_name/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/page_name/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] page_name page_name)
        {
            if (ModelState.IsValid)
            {
                db.page_name.Add(page_name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page_name);
        }

        // GET: admin/page_name/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page_name page_name = db.page_name.Find(id);
            if (page_name == null)
            {
                return HttpNotFound();
            }
            return View(page_name);
        }

        // POST: admin/page_name/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] page_name page_name)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page_name).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page_name);
        }

        // GET: admin/page_name/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            page_name page_name = db.page_name.Find(id);
            if (page_name == null)
            {
                return HttpNotFound();
            }
            return View(page_name);
        }

        // POST: admin/page_name/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            page_name page_name = db.page_name.Find(id);
            db.page_name.Remove(page_name);
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
