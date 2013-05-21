using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enterprise.Models;

namespace Enterprise.Controllers
{
    public class EnterpriseController : Controller
    {
        EnterpriseContainer db = new EnterpriseContainer();
        
        //
        // GET: /Enterprise/

        public ActionResult Index()
        {
            ViewBag.DriversCount = db.DRIVER.ToList().Count;
            ViewBag.TcoCount = db.TCO.ToList().Count;
            ViewBag.WBCount = db.WAYBILLS.ToList().Count;
            return View();
        }

    }
}
