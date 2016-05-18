using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class TagDao
    {
        private ShoeShopDbContext db = null;
        public TagDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Tags.Find(id);
                db.Tags.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<Tag> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Tags.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<Tag>(pageNum, pageSize);
        }
        public Tag ViewDetail(int id)
        {
            return db.Tags.Find(id);
        }
        public bool Update(Tag ab)
        {
            try
            {
                var res = db.Tags.Find(ab.ID);
                res.Name = ab.Name;  
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<Tag> ListAll(int page, int pageSize)
        {
            return db.Tags.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<Tag> ListAll()
        {
            return db.Tags.OrderByDescending(o => o.Name);
        }
    }
}

