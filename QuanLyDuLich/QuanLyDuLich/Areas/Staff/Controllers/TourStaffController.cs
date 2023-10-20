using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Areas.Staff.Repository;
using QuanLyDuLich.Models;
using QuanLyDuLich.Areas.Staff.Service;

namespace QuanLyDuLich.Areas.Staff.Controllers
{
    public class TourStaffController : Controller
    {
        private TourRepository tourRepository = new TourRepository();
        private TourService tourService = new TourService();
        // GET: Staff/TourStaff
        public ActionResult Index()
        {
            List<Tour> tour = tourRepository.GetAll().ToList();
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View(tour);
        }

        // GET: Staff/TourStaff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/TourStaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/TourStaff/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Tour tour, HttpPostedFileBase Image, List<HttpPostedFileBase> Images)
        {
            bool crtour = tourRepository.CreateTour(tour, Image, Images);
            if (!crtour)
            {
                TempData["TourFail"] = "Thêm tour không thành công!";
                return RedirectToAction("Create");
            }
            else
            {
                TempData["TourSuccess"] = "Thêm tour thành công!";
                return RedirectToAction("Index");
            }
        }

        // GET: Staff/TourStaff/Edit/5
        public ActionResult Edit(int id)
        {
            Tour tour = tourRepository.FindByID(id);
            return View(tour);
        }

        public ActionResult View(Tour tour)
        {
            ViewBag.tour = tour;
            return View();
        }

        // POST: Staff/TourStaff/Edit/5
        [HttpPost]
        [Obsolete]
        [OutputCache(Duration = 0, VaryByParam = "none")]
        public ActionResult Edit(Tour newTour, HttpPostedFileBase Image, List<HttpPostedFileBase> Images)
        {
            try
            {
                if (newTour == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    bool result = tourService.EditTour(newTour);
                    bool updateIamge = tourService.UpdateImage(newTour, Image, Images);
                    if (result)
                    {
                        TempData["EditSuccess"] = "Chỉnh sửa thành công!";
                    }
                    else
                    {
                        TempData["EditFail"] = "Chỉnh sửa thất bại!";
                    }
                }
                return RedirectToAction("Edit", new {id = newTour.id_tour});
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Staff/TourStaff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/TourStaff/Delete/5
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
