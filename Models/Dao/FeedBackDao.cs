using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class FeedbackDao
    {

        private ShoeShopDbContext db = null;
        public FeedbackDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(Feedback entity)
        {
            db.Feedbacks.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<Feedback> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.Feedbacks.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.Name).ToPagedList<Feedback>(pageNum, pageSize);
        }
        public Feedback ViewDetail(int? id)
        {
            return db.Feedbacks.Find(id);
        }
        public bool Update(Feedback fb)
        {
            try
            {
                var res = db.Feedbacks.Find(fb.ID);
                res.Name = fb.Name;
                res.Birthday = fb.Birthday;
                res.Province = fb.Province;
                res.Address = fb.Address;
                res.Tel = fb.Tel;
                res.Email = fb.Email;
                res.CreateDate = fb.CreateDate;
                res.Status = fb.Status;
                res.Content = fb.Content;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<Feedback> ListAll(int page, int pageSize)
        {
            return db.Feedbacks.OrderByDescending(o => o.CreateDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Feedback> ListAll()
        {
            return db.Feedbacks.OrderByDescending(o => o.CreateDate);
        }
    }
}


