using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.Dao
{
    public class HoTroDao
    {

        private ShoeShopDbContext db = null;
        public HoTroDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(HoTro entity)
        {
            db.HoTroes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.HoTroes.Find(id);
                db.HoTroes.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<HoTro> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.HoTroes.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<HoTro>(pageNum, pageSize);
        }
        public HoTro ViewDetail(int id)
        {
            return db.HoTroes.Find(id);
        }
        public bool Update(HoTro ab)
        {
            try
            {
                var res = db.HoTroes.Find(ab.Id);
                res.Name = ab.Name;
                res.Tel = ab.Tel;
                res.Type = ab.Type;
                res.Nick = ab.Nick;
                res.Order = ab.Order;
                res.Status = ab.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<HoTro> ListAll(int page, int pageSize)
        {
            return db.HoTroes.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<HoTro> ListAll()
        {
            return db.HoTroes.OrderByDescending(o => o.Name);
        }
    }
}

