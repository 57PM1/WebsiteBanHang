using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class NgonNguDao
    {

        private ShoeShopDbContext db = null;
        public NgonNguDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(Language entity)
        {
            db.Languages.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Languages.Find(id);
                db.Languages.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<Language> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Languages.Where(o => o.LanguageName.Contains(searchKey));
            return res.OrderByDescending(o => o.LanguageName).ToPagedList<Language>(pageNum, pageSize);
        }
        public Language ViewDetail(int id)
        {
            return db.Languages.Find(id);
        }
        public bool Update(Language ab)
        {
            try
            {
                var res = db.Languages.Find(ab.ID);
                res.LanguageName = ab.LanguageName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<Language> ListAll(int page, int pageSize)
        {
            return db.Languages.OrderByDescending(o => o.LanguageName).ToPagedList(page, pageSize);
        }
        public IEnumerable<Language> ListAll()
        {
            return db.Languages.OrderByDescending(o => o.LanguageName);
        }
    }

}

