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
    public class QuangCaoController : BaseController
    {
        // GET: admin/QuangCao
  
        public ActionResult Index(string searchKey, int page = 1, int pagesize = 10)
        {
            var ct = new QuangCaoDao();
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

        // GET: admin/QuangCao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/QuangCao/Create
        [HttpPost]
        public ActionResult Create(QuangCao collection)
        {
            var session = (UserSession)Session[CommonConstant.USER_SESSION];
            if (ModelState.IsValid)
            {
                var dao = new QuangCaoDao();
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
        // GET: admin/QuangCao/Edit/5
        public ActionResult Edit(int id)
        {
            var ct = new QuangCaoDao().ViewDetail(id);
            return View(ct);
        }

        // POST: admin/Quangcao/Edit/5
        [HttpPost]
        public ActionResult Edit(QuangCao ad)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuangCaoDao();
                var res = dao.Update(ad);
                if (res)
                {
                    return RedirectToAction("Index", "QuangCao");
                }
                else
                {
                    ModelState.AddModelError("", CommonConstant.UPDATE_FAIL);
                }
            }
            return View("Index");
        }

        // GET: admin/QuangCao/Delete/5
        public ActionResult Delete(int id)
        {
            new QuangCaoDao().Delete(id);
            return RedirectToAction("Index");
        }

        // POST: admin/QuangCao/Delete/5
        [HttpPost]
        public ActionResult Delete(string[] Ids)
        {
            try
            {
                foreach (var id in Ids)
                {
                    new QuangCaoDao().Delete(int.Parse(id));
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
