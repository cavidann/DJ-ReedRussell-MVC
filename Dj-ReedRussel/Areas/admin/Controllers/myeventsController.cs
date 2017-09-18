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

namespace Dj_ReedRussel.Areas.admin.Controllers.eventCrud
{
    public class myeventsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: blogsCrud
        public ActionResult Index()
        {
            return View(db.myevents.ToList());
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,event_name,event_info,eventdatetime,photo,event_bk_photo")] myevent myevent, HttpPostedFileBase photo, HttpPostedFileBase event_bk_photo)
        {

            if (ModelState.IsValid)
            {
                if (photo.ContentType == "image/jpeg" || photo.ContentType == "image/png" || photo.ContentType == "image/gif")
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(photo.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    photo.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    myevent.photo = fileName;
                    //myevent.date = now;
                    //db.myevents.Add(myevent);
                    //db.SaveChanges();
                }
                else
                {
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }

                if (event_bk_photo.ContentType == "image/jpeg" || event_bk_photo.ContentType == "image/png" || event_bk_photo.ContentType == "image/gif")
                {
                    //WebImage img = new WebImage(photo.InputStream);

                    DateTime now = DateTime.Now;
                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(event_bk_photo.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    event_bk_photo.SaveAs(path);
                    //if (img.Width > 1000)
                    //    img.Resize(500, 500);
                    //img.Save(path);
                    myevent.event_bk_photo = fileName;
                    //myevent.date = now;
                    db.myevents.Add(myevent);
                    db.SaveChanges();
                }
                else
                {
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }

            }
            else
            {
                //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                ViewBag.Message = "Errorrr";
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: blogsCrud/Details/5
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

        // GET: blogsCrud/Create
        public ActionResult Create()
        {
            //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
            return View();
        }

        // POST: blogsCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create2([Bind(Include = "id,title,photo,date,category_id,dec,text")] blog blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.blogs.Add(blog);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.category_id = new SelectList(db.blog_category, "id", "name", blog.category_id);
        //    return View(blog);
        //}



        // GET: blogsCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myevent blog = db.myevents.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            //ViewBag.category_id = new SelectList(db.blog_category, "id", "name", blog.category_id);
            return View(blog);
        }


        // POST: blogsCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "id,event_name,event_info,eventdatetime,photo,event_bk_photo")] myevent myevent, string oldfile, string oldfile1)
        {

            var gelensekil = HttpContext.Request.Files["photo"];
            var gelensekil1 = HttpContext.Request.Files["event_bk_photo"];

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
                    myevent.photo = fileName;
                    //myevent.date = now;

                }
                else
                {
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                myevent.photo = oldfile;
            }

            if (gelensekil1.FileName.Length > 0)
            {

                if (gelensekil1.ContentType == "image/jpeg" || gelensekil1.ContentType == "image/png" || gelensekil1.ContentType == "image/gif")
                {

                    string fullPath = Request.MapPath("~/Uploads/" + oldfile1);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);

                    }

                    string fileName = now.ToString("yyyyMdHms") + Path.GetFileName(gelensekil1.FileName);
                    string newfile = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    gelensekil1.SaveAs(newfile);
                    myevent.event_bk_photo = fileName;
                    //myevent.date = now;

                }
                else
                {
                    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name");
                    ViewBag.Message = "You can only jpg,png or gif file upload";
                    return View();
                }
            }
            else
            {
                myevent.event_bk_photo = oldfile1;
            }
            //blog.date = now;
            if (ModelState.IsValid)
            {
                db.Entry(myevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myevent);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit2([Bind(Include = "id,title,photo,date,category_id,dec,text")] blog blog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(blog).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    //ViewBag.category_id = new SelectList(db.blog_category, "id", "name", blog.category_id);
        //    return View(blog);
        //}

        // GET: blogsCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            myevent blog = db.myevents.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: blogsCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            myevent myevent = db.myevents.Find(id);
            string fullPath = Request.MapPath("~/Uploads/" + myevent.photo);
            string fullPath1= Request.MapPath("~/Uploads/" + myevent.event_bk_photo);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                System.IO.File.Delete(fullPath1);

            }
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
