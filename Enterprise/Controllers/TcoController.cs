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
    public class TcoController : Controller
    {
        private EnterpriseContainer db = new EnterpriseContainer();

        //
        // GET: /Tco/

        public ActionResult Index()
        {
            return View(db.TCO.ToList());
        }

        //
        // GET: /Tco/Details/5

        public ActionResult Details(string id = null)
        {
            TCO tco = db.TCO.Single(t => t.STATE_NUMBER == id);
            if (tco == null)
            {
                return HttpNotFound();
            }
            return View(tco);
        }

        //
        // GET: /Tco/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tco/Create

        [HttpPost]
        public ActionResult Create(TCO tco)
        {
            if (ModelState.IsValid)
            {
                db.TCO.AddObject(tco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tco);
        }

        //
        // GET: /Tco/Edit/5

        public ActionResult Edit(string id = null)
        {
            TCO tco = db.TCO.Single(t => t.STATE_NUMBER == id);
            if (tco == null)
            {
                return HttpNotFound();
            }
            return View(tco);
        }

        //
        // POST: /Tco/Edit/5

        [HttpPost]
        public ActionResult Edit(TCO tco)
        {
            if (ModelState.IsValid)
            {
                db.TCO.Attach(tco);
                db.ObjectStateManager.ChangeObjectState(tco, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tco);
        }

        //
        // GET: /Tco/Delete/5

        public ActionResult Delete(string id = null)
        {
            TCO tco = db.TCO.Single(t => t.STATE_NUMBER == id);
            if (tco == null)
            {
                return HttpNotFound();
            }
            return View(tco);
        }

        //
        // POST: /Tco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            TCO tco = db.TCO.Single(t => t.STATE_NUMBER == id);
            db.TCO.DeleteObject(tco);
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