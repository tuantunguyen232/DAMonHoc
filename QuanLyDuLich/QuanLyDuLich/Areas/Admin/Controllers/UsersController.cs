using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;
using QuanLyDuLich.Areas.Admin.Service;
using CloudinaryDotNet;

namespace QuanLyDuLich.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private DuLichDB db = new DuLichDB();
        private UsersService userService = new UsersService();

        // GET: Admin/Users
        public ActionResult Index()
        {
            List<User> users = userService.getAll();
            return View(users);
        }


        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.UserRoles = new List<string> { "Admin", "Nhân viên", "Khách hàng" };

            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        //public ActionResult Create([Bind(Include = "id_user,first_name,last_name,username,password,date_of_birth,user_role,image,email,is_active")] User user)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //user.password = BCrypt.Net.BCrypt.HashPassword(user.password);  chua co tac dung, tim cach fix sau
        //        db.User.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}
        public ActionResult Create(User user)
        {
            // TODO: Add insert logic here
            if (userService.check(user))
            {
                bool result = userService.CreateAccount(user);
                if (result)
                {
                    TempData["AddSuccess"] = "Tạo thành công!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AddError"] = "Tạo tài khoản không thành công!";
                    return RedirectToAction("Create");
                }
            }
            else
            {
                TempData["SavevError"] = "Tài khoản đã tồn tại!";
                return RedirectToAction("Create");
            }
            
            //if (userService.check(user))
            //{
            //    bool us = userService.CreateUser(user);
            //    if (!us)
            //    {
            //        TempData["FailMessage"] = "Đăng ký người dùng không thành công!";
            //        return RedirectToAction("Register", "Register");
            //    }
            //    else
            //    {
            //        TempData["CreatedSuccess"] = "Đăng ký người dùng thành công!";
            //        return RedirectToAction("Index");
            //    }
            //}
            //else
            //{
            //    TempData["UsernameExists"] = "Username đã tồn tại!";
            //    ViewBag.Error = "Đăng ký không thành công!";
            //    return RedirectToAction("Register", "Register");
            //}
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.UserRoles = new List<string> { "Admin", "Nhân viên", "Khách hàng" };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,first_name,last_name,username,password,date_of_birth,user_role,image,email,phone")] User user)
        {

            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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

    }
}
