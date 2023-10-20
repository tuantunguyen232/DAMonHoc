using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Controllers;
using QuanLyDuLich.Models;

namespace QuanLyDuLich.Areas.Staff.Service
{
    public class TourService
    {
        private static DuLichDB db = new DuLichDB();
        public bool EditTour(Tour tour)
        {
            try
            {
                using (var db = new DuLichDB())
                {
                    Tour t = db.Tour.Find(tour.id_tour);
                    t.tour_name = tour.tour_name;
                    t.tour_description = tour.tour_description;
                    t.price = tour.price;
                    t.status = tour.status;
                    t.departure_time = tour.departure_time;
                    t.return_time = tour.return_time;
                    t.departure_location = tour.departure_location;
                    t.arrival_location = tour.arrival_location;
                    t.quantity = tour.quantity;
                    t.rating = 0;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        [Obsolete]
        public bool UpdateImage(Tour tour, HttpPostedFileBase Image, List<HttpPostedFileBase> Images)
        {
            try
            {
                using (var db = new DuLichDB())
                {
                    Tour t = db.Tour.Find(tour.id_tour);
                    // Xóa hình cũ trên cloudinary
                    //if (b.Image != null)
                    //{
                    //    CloudinaryController.DeleteImage(b.Image);
                    //}
                    if (Image != null)
                    {
                        t.image = CloudinaryController.UploadImage(Image);
                    }

                    if (Images.Count > 0 && Images.First() != null)
                    {

                        var imagesToRemove = t.Tour_image.ToList();
                        foreach (var img in imagesToRemove)
                        {
                            db.Tour_image.Remove(img);
                        }
                        for (int i = 0; i < Images.Count; i++)
                        {
                            Tour_image img = new Tour_image();
                            img.id_tour = t.id_tour;
                            img.image_link = CloudinaryController.UploadImage(Images[i]);
                            t.Tour_image.Add(img);
                        }
                    }
                    db.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}