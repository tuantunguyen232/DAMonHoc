using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using QuanLyDuLich.Areas.Admin.Service;
using QuanLyDuLich.Models;

namespace QuanLyDuLich.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private DuLichDB db = new DuLichDB();
        private TourService tourService = new TourService();

        // GET: Admin/Tours
        public ActionResult TourList()
        {
            List<Tour> tours = tourService.getAll();
            return View(tours);
        }

        public ActionResult TourReview()
        {
            using (var db = new DuLichDB())
            {
                var inactiveTours = db.Tour.Where(t => t.is_active == false).ToList();
                return View(inactiveTours);
            }
        }

        // GET: Admin/Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tour tour)
        {
            try 
            {
                bool check = tourService.save(tour);

                if (check)
                {
                    TempData["SuccessMessage"] = "Lưu thành công!";
                    return RedirectToAction("TourList");
                }
                else
                {
                    TempData["FailMessage"] = "Lưu không thành công!";
                    return RedirectToAction("Create");
                }
            }
            catch 
            {
                return View();
            }
        }

        // GET: Admin/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        //private ActionResult View(Tour tour)
        //{
        //    ViewBag.tour = tour;
        //    return View();
        //}

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "id_tour,tour_name,tour_description,tour_schedule,price,status,departure_time,return_time,departure_location,arrival_location,image,quantity,is_active")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TourList");
            }
            return View(tour);
        }

        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tour.Find(id);
            db.Tour.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("TourList");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ActiveTour(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tour.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        [HttpPost, ActionName("ActiveTour")]
        [ValidateAntiForgeryToken]
        public ActionResult ActiveConfirm(int id)
        {
            try
            {
                TempData["ActiveSuccess"] = "Đã duyệt thành công!";
                Tour tour = db.Tour.Find(id);
                tour.is_active = true;
                db.SaveChanges();
                return RedirectToAction("TourReview");
            } 
            catch   
            {
                 TempData["ActiveFail"] = "Duyệt thất bại!";
                 return RedirectToAction("TourReview");

            }
        }

    }
}
