using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuLich.Models;

namespace QuanLyDuLich.Controllers
{
    public class OrderController : Controller
    {
        private DuLichDB db = new DuLichDB();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder(int? id_tour, decimal? price, int? id_user, int? quantity)
        {
            // Kiểm tra tính hợp lệ của dữ liệu, ví dụ: xem xét việc sử dụng Try...Catch

            Order order = new Order
            {
                id_tour = id_tour,
                created_date = DateTime.Now, // Sử dụng thuộc tính chính xác
                price = price,
                id_user = id_user,
                state = "chưa thanh toán", // Đặt trạng thái mặc định nếu cần
                quantity = quantity,
                
            };
            Tour tour = db.Tour.Find(id_tour);
            tour.quantity = tour.quantity - quantity;
            if(tour.quantity == 0 || tour.quantity < 0)
            {
                tour.status = "Outtime";
                if(tour.quantity < 0)
                {
                    tour.quantity = 0;
                }
                tour.quantity = tour.quantity;
                tour.price = price;
                db.SaveChanges();
                return View();
            }
            // Lưu đối tượng Order vào cơ sở dữ liệu
            db.Order.Add(order);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        //public ActionResult CreateOrder(int? id_tour, decimal? price, int? id_user, int? quantity)
        //{
        //    try
        //    {
        //        if (id_tour == null || price == null || id_user == null || quantity == null)
        //        {
        //            // Xử lý trường hợp dữ liệu không hợp lệ, có thể trả về một view thông báo lỗi
        //            return View(); // Đảm bảo bạn có view "Error" để hiển thị thông báo lỗi
        //        }

        //        Order order = new Order
        //        {
        //            id_tour = id_tour,
        //            created_date = DateTime.Now,
        //            price = price,
        //            id_user = id_user,
        //            state = "chưa thanh toán",
        //            quantity = quantity,
        //        };

        //        Tour tour = db.Tour.Find(id_tour);
        //        tour.quantity = tour.quantity - quantity;

        //        if (tour.quantity <= 0)
        //        {
        //            tour.status = "Out of Stock";
        //            tour.quantity = 0;
        //            tour.price = price;
        //            db.SaveChanges();
        //        }

        //        db.Order.Add(order);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý lỗi ở đây, ví dụ: ghi log lỗi
        //        // Sau đó, có thể trả về view thông báo lỗi hoặc chuyển hướng đến một trang lỗi
        //        return View(); // Đảm bảo bạn có view "Error" để hiển thị thông báo lỗi
        //    }
        //}
    }
}
