using QuanLyDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuLich.Areas.Admin.Service
{
    public class TourManagementService
    {
        private DuLichDB db = new DuLichDB();

        public List<TourManagement> getAll()
        {
            return db.TourManagement.ToList();
        }

        
        //public HashSet<TourManagement> GetScheduleByEmployee(int userID)
        //{
        //    try
        //    {
        //        User u = db.User.Find(userID);
        //        if (u == null) return new HashSet<TourManagement>();
        //        return (HashSet<TourManagement>)u.
        //    }
        //    catch
        //    {
        //        return new HashSet<Schedule>();
        //    }
        //}
    }
}