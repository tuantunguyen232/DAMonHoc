using QuanLyDuLich.Areas.Admin.Repository;
using QuanLyDuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace QuanLyDuLich.Areas.Admin.Service
{
    public class TourService
    {
        private DuLichDB db = new DuLichDB();
        private TourRepository tourRepository = new TourRepository();

        public List<Tour> getAll() {
            return db.Tour.ToList();
        }

        public bool save(Tour tour)
        {
            return tourRepository.save(tour);
        }

        public bool update(Tour tour)
        {
            return tourRepository.update();
        }

        public Tour findByID(int id)
        {
            return tourRepository.findByID(id);
        }

        public bool EditTourInfo(Tour tour)
        {
            try
            {
                if (tour == null)
                {
                    return false;
                }
                using (var db = new DuLichDB())
                {
                    Tour t = db.Tour.Find(tour.id_tour);
                    if (t != null)
                    {
                        t.tour_name = tour.tour_name;
                        t.tour_description = tour.tour_description;
                        t.tour_schedule = tour.tour_schedule;
                        t.price = tour.price;
                        t.quantity = tour.quantity;
                        t.departure_location = tour.departure_location;
                        t.arrival_location = tour.arrival_location;
                        t.departure_time = tour.departure_time;
                        t.return_time = tour.return_time;
                        t.status = tour.status;
                        t.image = tour.image;
                        db.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
    
        public List<Tour> GetActiveTour()
        {
            try
            {
                List<Tour> tours = db.Tour.Where(t => t.is_active == true).ToList();
                return tours;
            }
            catch
            {
                return null;
            }
        }

        public DateTime getDepartureTime(int id)
        {
            var tour = tourRepository.findByID(id);
            if (tour != null)
            {
                if (tour.departure_time != null)
                    return tour.departure_time.Value;
                else
                {
                    throw new Exception("departure_time is null for the specified tour.");
                }
            }
            else
            {
                throw new Exception("Tour with ID " + id + " not found.");
            }
        }

    }
}