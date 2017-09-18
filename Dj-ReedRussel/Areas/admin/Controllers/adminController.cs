using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Areas.admin.Controllers.Admins
{
    public class adminController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: admin/admin
        public ActionResult Index(int? id)
        {
            if (Session["myadmin"] != null)
            {
                dynamic mymodel = new ExpandoObject();
                myadmin admin_id = db.myadmins.Find(id);
                mymodel.adminID = admin_id;
                mymodel.myadmin = db.myadmins.ToList();
                return View(mymodel);
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(myadmin adm)
        {
            if (adm.adminnme != null && adm.password != null)
            {
                myadmin admin = db.myadmins.FirstOrDefault(a => a.adminnme == adm.adminnme && a.password == adm.password);
                if (admin != null)
                {
                    Session["myadmin"] = true;
                    Session["myadmin"] = new myadmin() { adminnme = adm.adminnme};
                    return RedirectToAction("index", "admin");
                }
                else
                {
                    Session["error_input"] = "Username ve ya password yalnisdir";
                    return RedirectToAction("login");
                }
            }
            else
            {
                Session["error_message"] = "Bosluq buraxma";
                return RedirectToAction("login");
            }

        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "admin");
        }
    }
}