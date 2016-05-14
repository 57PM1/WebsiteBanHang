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
    public class ThanhPhoController : BaseController
    {
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var ct = new ThanhPhoDao();
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

        // GET: admin/ThanhPho/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/ThanhPho/Create
        [HttpPost]
        public ActionResult Create(ThanhPho collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new ThanhPhoDao();
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
        // GET: admin/ThanhPho/Edit/5
        public ActionResult Edit(int id)
        {
            var ct = new ThanhPhoDao().ViewDetail(id);
            return View(ct);
        }

        // POST: admin/ThanhPho/Edit/5
        [HttpPost]
        public ActionResult Edit(ThanhPho ct)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThanhPhoDao();
                var res = dao.Update(ct);
                if (res)
                {
                    return RedirectToAction("Index", "ThanhPho");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/ThanhPho/Delete/5
        public ActionResult Delete(int id)
        {
            new ThanhPhoDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/ThanhPho/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new ThanhPhoDao().Delete(int.Parse(id));
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