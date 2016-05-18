using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public  class MenuDao
    {

        private ShoeShopDbContext db = null;
        public MenuDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(Menu entity)
        {
            db.Menus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Menus.Find(id);
                db.Menus.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<Menu> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Menus.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<Menu>(pageNum, pageSize);
        }
        public Menu ViewDetail(int id)
        {
            return db.Menus.Find(id);
        }
        public bool Update(Menu ab)
        {
            try
            {
                var res = db.Menus.Find(ab.ID);
                res.Name = ab.Name;
                res.MenuTypeID = ab.MenuTypeID;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<Menu> ListAll(int page, int pageSize)
        {
            return db.Menus.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<Menu> ListAll()
        {
            return db.Menus.OrderByDescending(o => o.Name);
        }
    }
}
