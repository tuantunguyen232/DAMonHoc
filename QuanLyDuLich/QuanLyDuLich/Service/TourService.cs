using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLich.Models;
using System.Data.Entity;

namespace QuanLyDuLich.Service
{
    public class TourService
    {
        private DuLichDB db = new DuLichDB();
        public List<Tour> Search(string departure_location, string arrival_location, DateTime? departure_time, int? day_number)
        {
            var searchResults = db.Tour./*Where(t => t.is_active == true).*/ToList();
            if (!string.IsNullOrEmpty(departure_location))
            {
                // Lọc theo điểm khởi hành
                searchResults = db.Tour.Where(t => t.departure_location.Contains(departure_location)).ToList();
            }

            if (!string.IsNullOrEmpty(arrival_location))
            {
                // Lọc theo điểm đến
                searchResults = searchResults.Where(t => t.arrival_location.Contains(arrival_location)).ToList();
            }

            if (departure_time != null)
            {
                // Lọc theo ngày khởi hành
                searchResults = searchResults.Where(t => t.departure_time == departure_time).ToList();
            }

            if (day_number != null)
            {
                // Lọc theo số ngày đi
                searchResults = searchResults.Where(t => CalculateDayNumber(t) == day_number) .ToList();
            }

            // Trả về danh sách kết quả tìm kiếm
            return searchResults;
        }
        private int CalculateDayNumber(Tour tour)
        {
            TimeSpan difference = (TimeSpan)(tour.return_time - tour.departure_time);
            return (int)difference.TotalDays; // +1 để tính cả ngày đi
        }
        public List<Tour> GetTop(int x)
        {
            return db.Tour.Take(x).ToList();
        }
    }
}