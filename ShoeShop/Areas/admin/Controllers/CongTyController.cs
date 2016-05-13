using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;
using Models.Dao;
using System.Web.Mvc;
using ShoeShop.Common;
using ShoeShop.Areas.admin.Code;

namespace ShoeShop.Areas.admin.Controllers
{
    public class CongTyController : BaseController
    {

        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var ct = new CongTyDao();
            if (!string.IsNullOrEmpty(searchKey))
            {
                var lst = ct.SearchResult(searchKey, page, pagesize);
                return View(lst);
            }
            else
            {
                var model = ct.ListAll(page, pagesize);
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: admin/CongTy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/CongTy/Create
        [HttpPost]
        public ActionResult Create(CongTy collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new CongTyDao();
                int id = dao.Insert(collection);
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
        // GET: admin/CongTy/Edit/5
        public ActionResult Edit(int id)
        {
            var ct = new CongTyDao().ViewDetail(id);
            return View(ct);
        }

        // POST: admin/CongTy/Edit/5
        [HttpPost]
        public ActionResult Edit(CongTy ct)
        {
            if (ModelState.IsValid)
            {
                var dao = new CongTyDao();
                var res = dao.Update(ct);
                if (res)
                {
                    return RedirectToAction("Index", "CongTy");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/CongTy/Delete/5
        public ActionResult Delete(int id)
        {
            new CongTyDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/CongTy/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new CongTyDao().Delete(int.Parse(id));
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
