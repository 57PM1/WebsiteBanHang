using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using Models.EF;

using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class KhachhangDao
    {
        private ShoeShopDbContext db = null;
        public KhachhangDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<KhachHang> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.KhachHangs.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<KhachHang>(pageNum, pageSize);
        }
        public KhachHang ViewDetail(int? id)
        {
            return db.KhachHangs.Find(id);
        }
        public bool Update(KhachHang cus)
        {
            try
            {
                var res = db.KhachHangs.Find(cus.ID);
                res.Name = cus.Name;
                res.Sex = cus.Sex;
                res.Address = cus.Address;
                res.Sdt = cus.Sdt;
                res.Email = cus.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<KhachHang> ListAll(int page, int pageSize)
        {
            return db.KhachHangs.OrderByDescending(o => o.ID).ToPagedList(page, pageSize);
        }
        public IEnumerable<KhachHang> ListAll()
        {
            return db.KhachHangs.OrderByDescending(o => o.Name);
        }
    }
}
