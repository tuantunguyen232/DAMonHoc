using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Repository;
using QuanLyDuLich.Filter;

namespace QuanLyDuLich.Controllers
{
    public class LogInController : Controller
    {
        private UserRepository userRepository = new UserRepository();
        // GET: LogIn
        [HttpGet]
        [AnonymousFilter]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [AnonymousFilter]
        public ActionResult LogIn(User user)
        {
            var us = userRepository.GetUser().SingleOrDefault(u => u.username == user.username);
            if (us != null)
            {
                bool passwordMatches = BCrypt.Net.BCrypt.Verify(user.password, us.password);
                if (passwordMatches)
                {
                    ViewBag.Error = "";
                    Session["ID"] = us.id_user;
                    Session["User"] = us.last_name;
                    string userRole = us.user_role.ToString();
                    switch (userRole)
                    {
                        case "Admin":
                            return RedirectToAction("Index", "Admin");
                        case "Nhân viên":
                            return RedirectToAction("Index", "TourStaff", new { area = "Staff" });
                        case "Khách hàng":
                            return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Error = "username hoặc mật khẩu không đúng!";
                    TempData["LoginFail"] = "Username hoặc mật khẩu không đúng!";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
