using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class ThanhPhoDao
    {
            private ShoeShopDbContext db = null;
            public ThanhPhoDao()
            {
                db = new ShoeShopDbContext();
            }
            public int Insert(ThanhPho entity)
            {
                db.ThanhPhoes.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            public bool Delete(int id)
            {
                try
                {
                    var res = db.ThanhPhoes.Find(id);
                    db.ThanhPhoes.Remove(res);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            public IPagedList<ThanhPho> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
            {
                var res = db.ThanhPhoes.Where(o => o.Name.Contains(searchKey));
                return res.OrderByDescending(o => o.Name).ToPagedList<ThanhPho>(pageNum, pageSize);
            }
            public ThanhPho ViewDetail(int id)
            {
                return db.ThanhPhoes.Find(id);
            }
            public bool Update(ThanhPho cus)
            {
                try
                {
                    var res = db.ThanhPhoes.Find(cus.Name);
                    res.Name = cus.Name;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            public IPagedList<ThanhPho> ListAll(int page, int pageSize)
            {
                return db.ThanhPhoes.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
            }
            public IEnumerable<ThanhPho> ListAll()
            {
                return db.ThanhPhoes.OrderByDescending(o => o.Name);
            }
        }
    }