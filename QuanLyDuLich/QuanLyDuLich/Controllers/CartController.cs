using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Filter;

namespace QuanLyDuLich.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [AuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }
       
    }
}
