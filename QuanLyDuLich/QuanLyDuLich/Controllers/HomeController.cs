using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Service;

namespace QuanLyDuLich.Controllers
{
    public class HomeController : Controller
    {
        private static TourService tourService = new TourService();
        public ActionResult Index(int x = 3)
        {
            IEnumerable<Tour> tour = tourService.GetTop(x);
            return View(tour);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}