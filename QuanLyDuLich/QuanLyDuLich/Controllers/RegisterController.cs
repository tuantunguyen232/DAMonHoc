using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Service;
using QuanLyDuLich.Models;
using QuanLyDuLich.Repository;
using QuanLyDuLich.Filter;

namespace QuanLyDuLich.Controllers
{
    public class RegisterController : Controller
    {
        private DuLichDB db = new DuLichDB();
        private UserService userService = new UserService();
        private UserRepository userRepository = new UserRepository();
        // GET: Register
        [AnonymousFilter]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Register(User user, HttpPostedFileBase Image)
        {
            if (userService.Check(user))
            {
                bool us = userRepository.CreateUser(user, Image);
                if (!us)
                {
                    TempData["FailMessage"] = "Đăng ký người dùng không thành công!";
                    return RedirectToAction("Register", "Register");
                }
                else
                {
                    TempData["CreatedSuccess"] = "Đăng ký người dùng thành công!";
                    return RedirectToAction("LogIn", "LogIn");
                }
            }
            else
            {
                TempData["UsernameExists"] = "Username đã tồn tại!";
                ViewBag.Error = "Đăng ký không thành công!";
                return RedirectToAction("Register", "Register");
            }
        }
    }
}

