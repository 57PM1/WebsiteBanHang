using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class MenuTypeDao
    {

        private ShoeShopDbContext db = null;
        public MenuTypeDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(MenuType entity)
        {
            db.MenuTypes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.MenuTypes.Find(id);
                db.MenuTypes.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<MenuType> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.MenuTypes.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<MenuType>(pageNum, pageSize);
        }
        public MenuType ViewDetail(int id)
        {
            return db.MenuTypes.Find(id);
        }
        public bool Update(MenuType ab)
        {
            try
            {
                var res = db.MenuTypes.Find(ab.ID);
                res.Name = ab.Name;      
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<MenuType> ListAll(int page, int pageSize)
        {
            return db.MenuTypes.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<MenuType> ListAll()
        {
            return db.MenuTypes.OrderByDescending(o => o.Name);
        }
    }
}

