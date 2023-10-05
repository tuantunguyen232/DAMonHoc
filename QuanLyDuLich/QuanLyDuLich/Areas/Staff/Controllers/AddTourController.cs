using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuLich.Areas.Staff.Controllers
{
    public class AddTourController : Controller
    {
        // GET: Staff/AddTour
        public ActionResult Index()
        {
            return View();
        }

        // GET: Staff/AddTour/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/AddTour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/AddTour/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/AddTour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/AddTour/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/AddTour/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/AddTour/Delete/5
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
