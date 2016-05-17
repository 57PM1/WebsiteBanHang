using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class QuangCaoDao
    {
        private ShoeShopDbContext db = null;
        public QuangCaoDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(QuangCao entity)
        {
            db.QuangCaos.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.QuangCaos.Find(id);
                db.QuangCaos.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<QuangCao> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.QuangCaos.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<QuangCao>(pageNum, pageSize);
        }
        public QuangCao ViewDetail(int id)
        {
            return db.QuangCaos.Find(id);
        }
        public bool Update(QuangCao ad)
        {
            try
            {
                var res = db.QuangCaos.Find(ad.Name);
                res.Name = ad.Name;
                res.Url = ad.Url;
                res.Width = ad.Width;
                res.Height = ad.Height;
                res.Link = ad.Link;
                res.Target = ad.Target;
                res.Positon = ad.Positon;
                res.Order = ad.Order;
                res.Status = ad.Status;    
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<QuangCao> ListAll(int page, int pageSize)
        {
            return db.QuangCaos.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<QuangCao> ListAll()
        {
            return db.QuangCaos.OrderByDescending(o => o.Name);
        }
    }
}

