using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class PageDao
    {
        private ShoeShopDbContext db = null;
        public PageDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(Page entity)
        {
            db.Pages.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Pages.Find(id);
                db.Pages.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<Page> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Pages.Where(o => o.Title.Contains(searchKey));
            return res.OrderByDescending(o => o.Postdate).ToPagedList<Page>(pageNum, pageSize);
        }
        public Page ViewDetail(int id)
        {
            return db.Pages.Find(id);
        }
        public bool Update(Page ab)
        {
            try
            {
                var res = db.Pages.Find(ab.ID);
                res.Title = ab.Title;
                res.Postdate = ab.Postdate;
                res.Author = ab.Author;
                res.PageContent = ab.PageContent;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<Page> ListAll(int page, int pageSize)
        {
            return db.Pages.OrderByDescending(o => o.Postdate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Page> ListAll()
        {
            return db.Pages.OrderByDescending(o => o.Postdate);
        }
    }
}

