using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using ShoeShop.Areas.admin.Code;
using ShoeShop.Common;

namespace ShoeShop.Areas.admin.Controllers
{
    public class SystemConfigController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var sy = new SystemConfigDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = sy.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = sy.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/SystemConfig/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/SystemConfig/Create
        [HttpPost]
        public ActionResult Create(SystemConfig collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new SystemConfigDao();
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
        // GET: admin/SystemConfig/Edit/5
        public ActionResult Edit(int id)
        {
            var sy = new SystemConfigDao().ViewDetail(id);
            return View(sy);
        }

        // POST: admin/syachhang/Edit/5
        [HttpPost]
        public ActionResult Edit(SystemConfig sy)
        {
            if (ModelState.IsValid)
            {
                var dao = new SystemConfigDao();
                var res = dao.Update(sy);
                if (res)
                {
                    return RedirectToAction("Index", "syachHang");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/SystemConfig/Delete/5
        public ActionResult Delete(int id)
        {
            new SystemConfigDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/SystemConfig/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new SystemConfigDao().Delete(int.Parse(id));
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