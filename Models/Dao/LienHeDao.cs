using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class LienHeDao
    {
        private ShoeShopDbContext db = null;
        public LienHeDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(LienHe entity)
        {
            db.LienHes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.LienHes.Find(id);
                db.LienHes.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<LienHe> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.LienHes.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<LienHe>(pageNum, pageSize);
        }
        public LienHe ViewDetail(int id)
        {
            return db.LienHes.Find(id);
        }
        public bool Update(LienHe ab)
        {
            try
            {
                var res = db.LienHes.Find(ab.ID);
                res.Name = ab.Name;
                res.Company = ab.Company;
                res.Address = ab.Address;
                res.Tel = ab.Tel;
                res.Mail = ab.Mail;
                res.Detail = ab.Detail;
                res.Date = ab.Date;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<LienHe> ListAll(int page, int pageSize)
        {
            return db.LienHes.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<LienHe> ListAll()
        {
            return db.LienHes.OrderByDescending(o => o.Name);
        }
    }

}
