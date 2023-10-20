using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLich.Models;

namespace QuanLyDuLich.Repository
{
    public class TourRepository
    {
        private DuLichDB db = new DuLichDB();
        public List<Tour> GetAll()
        {
            return db.Tour.ToList();
        }
        public Tour FindByID(int id)
        {
            return db.Tour.Find(id);
        }
    }
}