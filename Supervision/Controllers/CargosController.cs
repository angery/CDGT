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
    public class CargosController : Controller
    {
        private SupervisionEntities db = new SupervisionEntities();

        //
        // GET: /Cargos/

        public ActionResult Index()
        {
            return View(db.CARGO_TYPES.ToList());
        }

        //
        // GET: /Cargos/Details/5

        public ActionResult Details(int id = 0)
        {
            CargoType cargotype = db.CARGO_TYPES.Single(c => c.CODE == id);
            if (cargotype == null)
            {
                return HttpNotFound();
            }
            return View(cargotype);
        }

        //
        // GET: /Cargos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cargos/Create

        [HttpPost]
        public ActionResult Create(CargoType cargotype)
        {
            if (ModelState.IsValid)
            {
                db.CARGO_TYPES.AddObject(cargotype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargotype);
        }

        //
        // GET: /Cargos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CargoType cargotype = db.CARGO_TYPES.Single(c => c.CODE == id);
            if (cargotype == null)
            {
                return HttpNotFound();
            }
            return View(cargotype);
        }

        //
        // POST: /Cargos/Edit/5

        [HttpPost]
        public ActionResult Edit(CargoType cargotype)
        {
            if (ModelState.IsValid)
            {
                db.CARGO_TYPES.Attach(cargotype);
                db.ObjectStateManager.ChangeObjectState(cargotype, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargotype);
        }

        //
        // GET: /Cargos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CargoType cargotype = db.CARGO_TYPES.Single(c => c.CODE == id);
            if (cargotype == null)
            {
                return HttpNotFound();
            }
            return View(cargotype);
        }

        //
        // POST: /Cargos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CargoType cargotype = db.CARGO_TYPES.Single(c => c.CODE == id);
            db.CARGO_TYPES.DeleteObject(cargotype);
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