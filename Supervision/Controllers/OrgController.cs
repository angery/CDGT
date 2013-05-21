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
    public class OrgController : Controller
    {
        private SupervisionEntities db = new SupervisionEntities();

        //
        // GET: /Org/

        public ActionResult Index()
        {
            return View(db.ORGANIZATIONS.ToList());
        }

        //
        // GET: /Org/Details/5

        public ActionResult Details(int id = 0)
        {
            Organization organization = db.ORGANIZATIONS.Single(o => o.ORGANIZATION_ID == id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // GET: /Org/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Org/Create

        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.ORGANIZATIONS.AddObject(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        //
        // GET: /Org/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.ORGANIZATIONS.Single(o => o.ORGANIZATION_ID == id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Org/Edit/5

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.ORGANIZATIONS.Attach(organization);
                db.ObjectStateManager.ChangeObjectState(organization, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        //
        // GET: /Org/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Organization organization = db.ORGANIZATIONS.Single(o => o.ORGANIZATION_ID == id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        //
        // POST: /Org/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.ORGANIZATIONS.Single(o => o.ORGANIZATION_ID == id);
            db.ORGANIZATIONS.DeleteObject(organization);
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