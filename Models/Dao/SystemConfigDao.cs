using System;
using System.Collections.Generic;
using System.Linq;
using Models.EF;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.Dao
{
   public class SystemConfigDao
    {
        private ShoeShopDbContext db = null;
        public SystemConfigDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(SystemConfig entity)
        {
            db.SystemConfigs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.SystemConfigs.Find(id);
                db.SystemConfigs.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<SystemConfig> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.SystemConfigs.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<SystemConfig>(pageNum, pageSize);
        }
        public SystemConfig ViewDetail(int id)
        {
            return db.SystemConfigs.Find(id);
        }
        public bool Update(SystemConfig cus)
        {
            try
            {
                var res = db.SystemConfigs.Find(cus.ID);
                res.Name = cus.Name;
                res.Type = cus.Type;
                res.Value = cus.Value;
                res.Status = cus.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<SystemConfig> ListAll(int page, int pageSize)
        {
            return db.SystemConfigs.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<SystemConfig> ListAll()
        {
            return db.SystemConfigs.OrderByDescending(o => o.Name);
        }
    }
}

