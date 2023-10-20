using QuanLyDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuLich.Areas.Admin.Repository
{
    public class TourRepository
    {
        private static DuLichDB db = new DuLichDB();
        
        public bool update()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch 
            { 
                return false;
            }   
        }

        public bool save(Tour tour) 
        {
            try
            {
                db.Tour.Add(tour);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public Tour findByID(int id) {
            return db.Tour.Find(id);
        }

        public IEnumerable<Tour> getAll() {
            return db.Tour.ToList();
        }
    }
}