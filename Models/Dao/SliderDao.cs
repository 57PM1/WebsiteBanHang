using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
  public  class SliderDao
    {
 
            private ShoeShopDbContext db = null;
            public SliderDao()
            {
                db = new ShoeShopDbContext();
            }
            public int Insert(Slider entity)
            {
                db.Sliders.Add(entity);
                db.SaveChanges();
                return entity.ID;
            }
            public bool Delete(int id)
            {
                try
                {
                    var res = db.Sliders.Find(id);
                    db.Sliders.Remove(res);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            public Slider ViewDetail(int? id)
            {
                return db.Sliders.Find(id);
            }
            public bool Update(Slider sld)
            {
                try
                {
                    var res = db.Sliders.Find(sld.ID);
                    res.Image = sld.Image;
                    res.DisplayOrder = sld.DisplayOrder;
                    res.Link = sld.Link;
                    res.Description = sld.Description;
                res.CreateDate = sld.CreateDate;
                res.CreateBy = sld.CreateBy;
                res.ModifyBy = sld.ModifyBy;
                res.ModifyDate = sld.ModifyDate;
                res.Status = sld.Status;
                db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
            public IPagedList<Slider> ListAll(int page, int pageSize)
            {
                return db.Sliders.OrderByDescending(o => o.CreateDate).ToPagedList(page, pageSize);
            }
            public IEnumerable<Slider> ListAll()
            {
                return db.Sliders.OrderByDescending(o => o.CreateDate);
            }
        }
    }

