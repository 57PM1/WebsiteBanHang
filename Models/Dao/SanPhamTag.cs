using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class SanPhamTag
    {
        private ShoeShopDbContext db = null;
        public SanPhamTag()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(SanPhamTag entity)
        {
            db.SanphamTags.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Abouts.Find(id);
                db.Abouts.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<About> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Abouts.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<About>(pageNum, pageSize);
        }
        public About ViewDetail(int id)
        {
            return db.Abouts.Find(id);
        }
        public bool Update(About ab)
        {
            try
            {
                var res = db.Abouts.Find(ab.ID);
                res.Name = ab.Name;
                res.MetaTitle = ab.MetaTitle;
                res.Images = ab.Images;
                res.CreateDate = ab.CreateDate;
                res.ModifyDate = ab.ModifyDate;
                res.ModifyBy = ab.ModifyBy;
                res.MetaKeyword = ab.MetaKeyword;
                res.MetaDescription = ab.MetaDescription;
                res.Status = ab.Status;
                res.Tag = ab.Tag;
                res.Content = ab.Content;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<About> ListAll(int page, int pageSize)
        {
            return db.Abouts.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
        }
        public IEnumerable<About> ListAll()
        {
            return db.Abouts.OrderByDescending(o => o.Name);
        }
    }
}
}
