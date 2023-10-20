using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Repository;
using QuanLyDuLich.Service;

namespace QuanLyDuLich.Controllers
{
    public class SearchController : Controller
    {
        private TourRepository tourRepository = new TourRepository();
        private TourService tourService = new TourService();
        // GET: Search
        public ActionResult Index()
        {
            IEnumerable<Tour> tour = tourRepository.GetAll();
            ViewBag.SelectedLocations = new List<string>();
            return View(tour);
        }
        public ActionResult SearchResult(string departure_location, string arrival_location, DateTime? departure_time, int? day_number)
        {
            var result = tourService.Search(departure_location, arrival_location, departure_time, day_number);
            ViewBag.departure_location = departure_location;
            return View(result.OrderBy(b => b.tour_name));
        }
        public ActionResult SearchKW(string departure_location, string arrival_location, DateTime? departure_time, int? day_number)
        {
            return RedirectToAction("SearchResult", new
            {
                @departure_location = departure_location,
                @arrival_location = arrival_location,
                @departure_time = departure_time,
                @day_number = day_number
            });
        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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
