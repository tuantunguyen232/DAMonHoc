using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLich.Models;
using QuanLyDuLich.Controllers;

namespace QuanLyDuLich.Areas.Staff.Repository
{
    public class TourRepository
    {
        private static DuLichDB db = new DuLichDB();
        public List<Tour> GetAll()
        {
            return db.Tour.ToList();
        }
        public Tour FindByID(int id)
        {
            return db.Tour.Find(id);
        }

        [Obsolete]
        public bool CreateTour(Tour tour, HttpPostedFileBase Image, List<HttpPostedFileBase> Images)
        {
            try
            {
                tour.id_tour = 1;
                tour.price = tour.price;
                tour.rating = 0;
                tour.is_active = false;
                if (Images[0] != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        Tour_image img = new Tour_image();
                        img.id_tour = tour.id_tour;
                        img.image_link = CloudinaryController.UploadImage(Images[i]);
                        tour.Tour_image.Add(img);
                    }
                }
                if (Image != null) // Đoạn này kiểm tra có hình không 
                {
                    tour.image = CloudinaryController.UploadImage(Image);
                    if (tour.image != "")
                    {
                        // Thành công 
                    }
                    else
                    {
                        // Thất bại
                    }
                }
                db.Tour.Add(tour);
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