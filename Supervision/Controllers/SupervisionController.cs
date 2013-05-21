using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supervision.Models;

namespace Supervision.Controllers
{
    public class SupervisionController : Controller
    {
        SupervisionEntities db = new SupervisionEntities();
        //
        // GET: /Supervision/

        public ActionResult Index()
        {
            ViewBag.SPCount = db.SPECIAL_PERMITS.ToList().Count;
            ViewBag.OrgCount = db.ORGANIZATIONS.ToList().Count; 
            return View();
        }
    }
}
