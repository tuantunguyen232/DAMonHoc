using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLich.Repository;
using QuanLyDuLich.Models;

namespace QuanLyDuLich.Service
{
    public class UserService
    {
        private static DuLichDB db = new DuLichDB();
        private UserRepository userRepository = new UserRepository();
        public bool Check(User user)
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
    }
}