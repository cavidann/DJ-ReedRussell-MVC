using Dj_ReedRussel.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dj_ReedRussel.Controllers.EvenItem
{
    public class EventItemController : Controller
    {
        private dj_reedrussellEntities db = new dj_reedrussellEntities();

        // GET: EventItem
        public ActionResult Index(int? id)
        {
            dynamic mymodel = new ExpandoObject();
            myevent event_id = db.myevents.Find(id);
            mymodel.event_item = event_id;
            mymodel.otherevents = db.myevents.Where(o => o.id != event_id.id).Take(3).ToList();
            return View(mymodel);
        }
    }
}