﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supervision.Controllers
{
    public class OrganizationsController : Controller
    {
        //
        // GET: /Organizations/

        public ActionResult Index()
        {
            return View(new Supervision.Models.SupervisionEntities().ORGANIZATIONS.ToList());
        }

        public ActionResult Sample()
        {
            return View();
        }

        //
        // GET: /Organizations/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Organizations/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Organizations/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                int a = 5;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Organizations/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Organizations/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                int a = 5;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Organizations/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Organizations/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
