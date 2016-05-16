using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult giaydep()
        {
            ViewBag.Message = "Bán giày dép";
            return View();
        }
        public ActionResult quanao()
        {
            ViewBag.Message = "Bán Quần Áo";
            return View();
        }
        public ActionResult dongho()
        {
            ViewBag.Message = "Bán Đồng hồ";
            return View();
        }
        public ActionResult phukien()
        {
            ViewBag.Message = "Bán phụ kiện";
            return View();
        }
        public ActionResult trangchu(HomePageViewModel model)
        {
            model.Danhmucsanphams = new NhomsanphamDao().ListAll();
            return View(model);

        }
    }
}