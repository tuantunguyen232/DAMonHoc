using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLich.Models;
using QuanLyDuLich.Controllers;

namespace QuanLyDuLich.Repository
{
    public class UserRepository
    {
        private static DuLichDB db = new DuLichDB();

        public List<User> GetUser()
        {
            return db.User.ToList();
        }
        public User FindByID(int id)
        {
            return db.User.Find(id);
        }

        [Obsolete]
        public bool CreateUser(User user, HttpPostedFileBase Image)
        {
            try
            {
                user.username = user.username;
                user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
                user.first_name = user.first_name;
                user.last_name = user.last_name;
                user.email = user.email;
                user.user_role = "Khách hàng";
                if (Image != null)
                {
                    user.image = CloudinaryController.UploadImage(Image);
                }
                db.User.Add(user); 
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}