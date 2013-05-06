using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supervision.Controllers
{
    public class SupervisionController : Controller
    {
        //
        // GET: /Supervision/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.SPCount = 5;
            ViewBag.OrgCount = 21;            
            return View();
        }
    }
}
