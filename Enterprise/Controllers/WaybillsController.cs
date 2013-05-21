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
    public class WaybillsController : Controller
    {
        private EnterpriseContainer db = new EnterpriseContainer();

        //
        // GET: /Waybills/

        public ActionResult Index()
        {
            var waybills = db.WAYBILLS.Include("DRIVER1").Include("TCO1");
            return View(waybills.ToList());
        }

        //
        // GET: /Waybills/Details/5

        public ActionResult Details(int id = 0)
        {
            WAYBILLS waybills = db.WAYBILLS.Single(w => w.WAYBILL_ID == id);
            if (waybills == null)
            {
                return HttpNotFound();
            }
            return View(waybills);
        }

        //
        // GET: /Waybills/Create

        public ActionResult Create()
        {
            ViewBag.DRIVER = new SelectList(db.DRIVER, "DRIVER_ID", "NAME");
            ViewBag.TCO = new SelectList(db.TCO, "STATE_NUMBER", "STATE_NUMBER");
            return View();
        }

        //
        // POST: /Waybills/Create

        [HttpPost]
        public ActionResult Create(WAYBILLS waybills)
        {
            if (ModelState.IsValid)
            {
                db.WAYBILLS.AddObject(waybills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DRIVER = new SelectList(db.DRIVER, "DRIVER_ID", "NAME", waybills.DRIVER);
            ViewBag.TCO = new SelectList(db.TCO, "STATE_NUMBER", "AT_ID", waybills.TCO);
            return View(waybills);
        }

        //
        // GET: /Waybills/Edit/5

        public ActionResult Edit(int id = 0)
        {
            WAYBILLS waybills = db.WAYBILLS.Single(w => w.WAYBILL_ID == id);
            if (waybills == null)
            {
                return HttpNotFound();
            }
            ViewBag.DRIVER = new SelectList(db.DRIVER, "DRIVER_ID", "NAME", waybills.DRIVER);
            ViewBag.TCO = new SelectList(db.TCO, "STATE_NUMBER", "STATE_NUMBER", waybills.TCO);
            return View(waybills);
        }

        //
        // POST: /Waybills/Edit/5

        [HttpPost]
        public ActionResult Edit(WAYBILLS waybills)
        {
            if (ModelState.IsValid)
            {
                db.WAYBILLS.Attach(waybills);
                db.ObjectStateManager.ChangeObjectState(waybills, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DRIVER = new SelectList(db.DRIVER, "DRIVER_ID", "NAME", waybills.DRIVER);
            ViewBag.TCO = new SelectList(db.TCO, "STATE_NUMBER", "STATE_NUMBER", waybills.TCO);
            return View(waybills);
        }

        //
        // GET: /Waybills/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WAYBILLS waybills = db.WAYBILLS.Single(w => w.WAYBILL_ID == id);
            if (waybills == null)
            {
                return HttpNotFound();
            }
            return View(waybills);
        }

        //
        // POST: /Waybills/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WAYBILLS waybills = db.WAYBILLS.Single(w => w.WAYBILL_ID == id);
            db.WAYBILLS.DeleteObject(waybills);
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