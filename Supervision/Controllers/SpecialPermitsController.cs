using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supervision.Models;

namespace Supervision.Controllers
{
    public class SpecialPermitsController : Controller
    {
        private SupervisionEntities db = new SupervisionEntities();

        //
        // GET: /SpecialPermits/

        public ActionResult Index()
        {
            var special_permits = db.SPECIAL_PERMITS.Include("CARGO_TYPES").Include("ORGANIZATION");
            return View(special_permits.ToList());
        }

        //
        // GET: /SpecialPermits/Details/5

        public ActionResult Details(int id = 0)
        {
            SpecialPermit specialpermit = db.SPECIAL_PERMITS.Single(s => s.SP_ID == id);
            if (specialpermit == null)
            {
                return HttpNotFound();
            }
            return View(specialpermit);
        }

        //
        // GET: /SpecialPermits/Create

        public ActionResult Create()
        {
            ViewBag.CARGO_TYPE = new SelectList(db.CARGO_TYPES, "CODE", "TITLE");
            ViewBag.ORGANIZATION_ID = new SelectList(db.ORGANIZATIONS, "ORGANIZATION_ID", "TITLE");
            return View();
        }

        //
        // POST: /SpecialPermits/Create

        [HttpPost]
        public ActionResult Create(SpecialPermit specialpermit)
        {
            if (ModelState.IsValid)
            {
                db.SPECIAL_PERMITS.AddObject(specialpermit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CARGO_TYPE = new SelectList(db.CARGO_TYPES, "CODE", "TITLE", specialpermit.CARGO_TYPE);
            ViewBag.ORGANIZATION_ID = new SelectList(db.ORGANIZATIONS, "ORGANIZATION_ID", "TITLE", specialpermit.ORGANIZATION_ID);
            return View(specialpermit);
        }

        //
        // GET: /SpecialPermits/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SpecialPermit specialpermit = db.SPECIAL_PERMITS.Single(s => s.SP_ID == id);
            if (specialpermit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CARGO_TYPE = new SelectList(db.CARGO_TYPES, "CODE", "TITLE", specialpermit.CARGO_TYPE);
            ViewBag.ORGANIZATION_ID = new SelectList(db.ORGANIZATIONS, "ORGANIZATION_ID", "TITLE", specialpermit.ORGANIZATION_ID);
            return View(specialpermit);
        }

        //
        // POST: /SpecialPermits/Edit/5

        [HttpPost]
        public ActionResult Edit(SpecialPermit specialpermit)
        {
            if (ModelState.IsValid)
            {
                db.SPECIAL_PERMITS.Attach(specialpermit);
                db.ObjectStateManager.ChangeObjectState(specialpermit, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CARGO_TYPE = new SelectList(db.CARGO_TYPES, "CODE", "TITLE", specialpermit.CARGO_TYPE);
            ViewBag.ORGANIZATION_ID = new SelectList(db.ORGANIZATIONS, "ORGANIZATION_ID", "TITLE", specialpermit.ORGANIZATION_ID);
            return View(specialpermit);
        }

        //
        // GET: /SpecialPermits/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SpecialPermit specialpermit = db.SPECIAL_PERMITS.Single(s => s.SP_ID == id);
            if (specialpermit == null)
            {
                return HttpNotFound();
            }
            return View(specialpermit);
        }

        //
        // POST: /SpecialPermits/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialPermit specialpermit = db.SPECIAL_PERMITS.Single(s => s.SP_ID == id);
            db.SPECIAL_PERMITS.DeleteObject(specialpermit);
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