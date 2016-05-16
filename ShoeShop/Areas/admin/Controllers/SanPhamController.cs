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
    public class SanPhamController : BaseController
    {
        // GET: admin/SanPham
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var sp = new SanPhamDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = sp.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = sp.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin/SanPham/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: admin/SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            collection.ModifyBy = session.UserName;
            collection.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
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
        // GET: admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            var pro = new SanPhamDao().ViewDetail(id);
            return View(pro);
        }

        // POST: admin/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var res = dao.Update(pro);
                if (res)
                {
                    return RedirectToAction("Index", "SanPhams");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }
        // GET: admin/SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            new SanPhamDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new SanPhamDao().Delete(int.Parse(id));
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