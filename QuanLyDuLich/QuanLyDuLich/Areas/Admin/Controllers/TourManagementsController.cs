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
using QuanLyDuLich.Service;

namespace QuanLyDuLich.Areas.Admin.Controllers
{
    public class TourManagementsController : Controller
    {
        private DuLichDB db = new DuLichDB();
        private UsersService userService = new UsersService();
        private TourManagementService tourManagementService = new TourManagementService();
        private TourService tourService = new TourService();

        // GET: Admin/TourManagements
        public ActionResult Index()
        {
            var tourManagement = db.TourManagement.Include(t => t.Tour).Include(t => t.User);
            return View(tourManagement.ToList());
        }
        public ActionResult EmployeeAsignment()
        {
            using (var db = new DuLichDB())
            {
                var employee = db.User.Where(t => t.user_role == "Nhân viên").ToList();
                return View(employee);
            }
        }

        // GET: Admin/TourManagements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourManagement tourManagement = db.TourManagement.Find(id);
            if (tourManagement == null)
            {
                return HttpNotFound();
            }
            return View(tourManagement);
        }

        // GET: Admin/TourManagements/Create
        public ActionResult Create()
        {
            ViewBag.id_tour = new SelectList(db.Tour.Where(t => t.is_active == true), "id_tour", "tour_name");
            ViewBag.id_user = new SelectList(db.User.Where(u => u.user_role == "Nhân viên"), "id_user", "first_name");
            return View();
        }

        // POST: Admin/TourManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tour_manamegement,id_tour,id_user,createDate,isAsign")] TourManagement tourManagement)
        {
            if (ModelState.IsValid)
            {
                tourManagement.createDate = DateTime.Now;
                //tourManagement.departure_time = tourService.getDepartureTime((int)tourManagement.id_tour);
                db.TourManagement.Add(tourManagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tour = new SelectList(db.Tour.Where(t => t.is_active == true), "id_tour", "tour_name", tourManagement.id_tour);
            ViewBag.id_user = new SelectList(db.User.Where(u => u.user_role == "Nhân viên"), "id_user", "first_name", tourManagement.id_user);
            return View(tourManagement);
        }

        // GET: Admin/TourManagements/Edit/5
        public ActionResult Edit(int? id)
        {
            List<Tour> tours = tourService.GetActiveTour();
            User employee = db.User.Find(id);
            List<TourManagement> toursM = tourManagementService.getAll();
            return View(tours, employee, toursM);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //TourManagement tourManagement = db.TourManagement.Find(id);
            //if (tourManagement == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.id_tour = new SelectList(db.Tour, "id_tour", "tour_name", tourManagement.id_tour);
            //ViewBag.id_user = new SelectList(db.User, "id_user", "first_name", tourManagement.id_user);
            //return View(tourManagement);
        }

        // POST: Admin/TourManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int tourId)
        {
            try
            {
                bool result = userService.AssignTour(id, tourId);
                if (result)
                {
                    TempData["PCsuccess"] = "Thực hiện phân công thành công!";
                }
                else
                {
                    TempData["PCfail"] = "Thực hiện thất bại!";
                }
                return RedirectToAction("Edit", new {id = id});
            }
            catch
            {
                return RedirectToAction("EmployeeAsignment");
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tourManagement).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.id_tour = new SelectList(db.Tour, "id_tour", "tour_name", tourManagement.id_tour);
            //ViewBag.id_user = new SelectList(db.User, "id_user", "first_name", tourManagement.id_user);
            //return View(tourManagement);
        }

        // GET: Admin/TourManagements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourManagement tourManagement = db.TourManagement.Find(id);
            if (tourManagement == null)
            {
                return HttpNotFound();
            }
            return View(tourManagement);
        }

        // POST: Admin/TourManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourManagement tourManagement = db.TourManagement.Find(id);
            db.TourManagement.Remove(tourManagement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private ActionResult View(List<Tour> tours, User employee, List<TourManagement> toursM)
        {
            ViewBag.tours = tours;
            ViewBag.employee = employee;
            ViewBag.toursM = toursM;
            return View();
        }
    }
}
