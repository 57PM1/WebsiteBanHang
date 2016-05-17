using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CongTyDao
    {
            private ShoeShopDbContext db = null;
            public CongTyDao()
            {
                db = new ShoeShopDbContext();
            }
            public int Insert(CongTy entity)
            {
                db.CongTies.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            public bool Delete(int id)
            {
                try
                {
                    var res = db.CongTies.Find(id);
                    db.CongTies.Remove(res);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            public IPagedList<CongTy> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
            {
                var res = db.CongTies.Where(o => o.Name.Contains(searchKey));
                return res.OrderByDescending(o => o.Name).ToPagedList<CongTy>(pageNum, pageSize);
            }
            public CongTy ViewDetail(int? id)
            {
                return db.CongTies.Find(id);
            }
            public bool Update(CongTy com)
            {
                try
                {
                    var res = db.CongTies.Find(com.ID);
                    res.Name = com.Name;
                    res.Address = com.Address;
                    res.Phone = com.Phone;
                    res.Fax = com.Fax;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            public IPagedList<CongTy> ListAll(int page, int pageSize)
            {
                return db.CongTies.OrderByDescending(o => o.Name).ToPagedList(page, pageSize);
            }
            public IEnumerable<CongTy> ListAll()
            {
                return db.CongTies.OrderByDescending(o => o.Name);
            }
        }
    }
