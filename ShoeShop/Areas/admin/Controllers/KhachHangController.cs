using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using ShoeShop.Common;
using ShoeShop.Areas.admin.Code;

namespace ShoeShop.Areas.admin.Controllers
{
    public class KhachHangController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var kh = new KhachhangDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = kh.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = kh.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/Khachhang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/KhachHang/Create
        [HttpPost]
        public ActionResult Create(KhachHang collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new KhachhangDao();
                long id = dao.Insert(collection);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.INSERT_FAIL);
                }
            }
            else
            {
                ModelState.AddModelError("", CommonConstant.INSERT_FAIL);
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase Image)
        {
            string path = Server.MapPath(Image.FileName);
            Image.SaveAs(path);
            return View("Create");
        }
        // GET: admin/NhomSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = new KhachhangDao().ViewDetail(id);
            return View(kh);
        }

        // POST: admin/Khachhang/Edit/5
        [HttpPost]
        public ActionResult Edit(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachhangDao();
                var res = dao.Update(kh);
                if (res)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            new KhachhangDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/KhachHang/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new KhachhangDao().Delete(int.Parse(id));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "có lỗi");
                return RedirectToAction("Index");
            }
        }
    }
}