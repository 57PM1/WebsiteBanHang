using Models.Dao;
using Models.EF;
using ShoeShop.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ShoeShop.Common;
using ShoeShop.Areas.admin.Code;

namespace ShoeShop.Areas.admin.Controllers
{
    public class NhomSanPhamController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var nhomsp = new NhomsanphamDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = nhomsp.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                    var model = nhomsp.ListAll(page, pagesize);
                    return View(model);    
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/NhomSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/NhomSanPham/Create
        [HttpPost]
        public ActionResult Create(NhomSanPham collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            collection.CreateBy = session.UserName;
            collection.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
                {
                    var dao = new NhomsanphamDao();
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
            var cate = new NhomsanphamDao().ViewDetail(id);
            return View(cate);
        }

        // POST: admin/NhomSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(NhomSanPham cate)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhomsanphamDao();
                var res = dao.Update(cate);
                if (res)
                {
                    return RedirectToAction("Index", "NhomSanPham");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/NhomSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            new NhomsanphamDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/NhomSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new NhomsanphamDao().Delete(int.Parse(id));
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
