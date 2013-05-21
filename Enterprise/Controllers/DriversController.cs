using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enterprise.Models;

namespace Enterprise.Controllers
{
    public class DriversController : Controller
    {
        private EnterpriseContainer db = new EnterpriseContainer();

        //
        // GET: /Drivers/

        public ActionResult Index()
        {
            return View(db.DRIVER.ToList());
        }

        //
        // GET: /Drivers/Details/5

        public ActionResult Details(int id = 0)
        {
            DRIVER driver = db.DRIVER.Single(d => d.DRIVER_ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // GET: /Drivers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Drivers/Create

        [HttpPost]
        public ActionResult Create(DRIVER driver)
        {
            if (ModelState.IsValid)
            {
                db.DRIVER.AddObject(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driver);
        }

        //
        // GET: /Drivers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DRIVER driver = db.DRIVER.Single(d => d.DRIVER_ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Drivers/Edit/5

        [HttpPost]
        public ActionResult Edit(DRIVER driver)
        {
            if (ModelState.IsValid)
            {
                db.DRIVER.Attach(driver);
                db.ObjectStateManager.ChangeObjectState(driver, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        //
        // GET: /Drivers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DRIVER driver = db.DRIVER.Single(d => d.DRIVER_ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //
        // POST: /Drivers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DRIVER driver = db.DRIVER.Single(d => d.DRIVER_ID == id);
            db.DRIVER.DeleteObject(driver);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}