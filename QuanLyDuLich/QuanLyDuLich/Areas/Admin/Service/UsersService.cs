using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using CloudinaryDotNet;
using QuanLyDuLich.Models;
using QuanLyDuLich.Repository;
using QuanLyDuLich.Service;

namespace QuanLyDuLich.Areas.Admin.Service
{
    public class UsersService
    {
        private DuLichDB db = new DuLichDB();
        public List<User> getAll()
        {
            return db.User.ToList();
        }

        public User findByID(int id)
        {
            return db.User.Find(id);
        }

        public bool check(User user)
        {
            try
            {
                var check = db.User.FirstOrDefault(u => u.username == user.username);
                if (check == null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        [Obsolete]
        public bool CreateAccount(User user)
        {
            try
            {
                user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                db.User.Add(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(int id)
        {
            try
            {
                User target = db.User.Find(id);
                if (target != null)
                {
                    db.User.Remove(target);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(User user)
        {
            try
            {
                User target = db.User.Find(user.id_user);
                if (target == null)
                {
                    return false;
                }
                if (user.password != target.password)
                {
                    target.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                }
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool AssignTour(int id, int? tourId)
        {
            try
            {
                using (DuLichDB db = new DuLichDB())
                {
                    User employee = db.User.Find(id);
                    if (employee == null)
                        return false;
                    //List<string> currBuildingIDOfEmpl = db.ManagementBuildings
                    //                                    .Where(mb => mb.EmployeeID == id)
                    //                                    .Select(mb => mb.BuildingID).ToList();
                    // Đi delete những item có EmployeeID = id
                    // Remove the existing building assignments that are not in the new list
                    //foreach (var mb in db.ManagementBuildings.Where(mb => mb.EmployeeID == id))
                    //{
                    //    db.ManagementBuildings.Remove(mb);
                    //}
                    if (tourId == null)
                    {
                        db.SaveChanges();
                        return true;
                    }
                        TourManagement tm = new TourManagement
                        {
                            id_user = id,
                            id_tour = tourId,
                            departure_time = DateTime.Now,
                            createDate = DateTime.Now,
                        };
                    
                        db.TourManagement.Add(tm);
                    db.SaveChanges();
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }

        public List<User> GetEmployee() {
            return db.User.Where(t => t.user_role == "Nhân viên").ToList();
        }
    }
}