using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.Events
{
    public class EventsController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();
        // GET: Event
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.events = db.myevents.ToList();
            return View(mymodel);
        }
    }
}