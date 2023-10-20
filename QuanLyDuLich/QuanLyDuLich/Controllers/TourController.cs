using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Repository;
using PagedList;

namespace QuanLyDuLich.Controllers
{
    public class TourController : Controller
    {
        private TourRepository tourRepository = new TourRepository();
        // GET: Tour
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = (page ?? 1);
            int size = 9;
            IEnumerable<Tour> tour = tourRepository.GetAll();
            var pageTour = tour.ToPagedList(pageNumber, size);
            ViewBag.SelectedLocations_departure = new List<string>();
            ViewBag.SelectedLocations_arrival = new List<string>();
            return View(pageTour);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            var pageDetails = tourRepository.FindByID(id);
            return View(pageDetails);
        }

    }
}
