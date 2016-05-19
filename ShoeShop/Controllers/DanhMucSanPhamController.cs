using Models.Dao;
using ShoeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShop.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        public ActionResult Index(HomePageViewModel model, int id)
        {
            model.Sanphams = new SanPhamDao().SelectSanPhamByNhomSanPhamId(id);
            return View(model);
        }
    }
}