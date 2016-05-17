
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Models.EF;


namespace Models.Dao
{
    public class SanPhamDao
    {
        private ShoeShopDbContext db = null;
        public SanPhamDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(SanPham entity)
        {
            db.SanPhams.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.SanPhams.Find(id);
                db.SanPhams.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IPagedList<SanPham> SearchResult(string searchKey, int pageNum = 1, int pageSize = 10)
        {
            var res = db.SanPhams.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o => o.CreateDate).ToPagedList<SanPham>(pageNum, pageSize);
        }
        public SanPham ViewDetail(int? id)
        {
            return db.SanPhams.Find(id);
        }
        public bool Update(SanPham pro)
        {
            try
            {
                var res = db.SanPhams.Find(pro.ID);
                res.Name = pro.Name;
                res.Code = pro.Code;
                res.MetaDescription = pro.MetaDescription;
                res.NhomSP_ID = pro.NhomSP_ID;
                res.Detail = pro.Detail;
                res.Images = pro.Images;
                res.MoreImages = pro.MoreImages;
                res.Price = pro.Price;
                res.PromotionPrice = pro.PromotionPrice;
                res.Quantity = pro.Quantity;
                res.Date = pro.Date;
                res.Order = pro.Order;
                res.IncludeVAT = pro.IncludeVAT;
                res.CreateDate = pro.CreateDate;
                res.ModifyDate = pro.ModifyDate;
                res.ModifyBy = pro.ModifyBy;
                res.MetaKeyword = pro.MetaKeyword;
                res.MetaDescription = pro.MetaDescription;
                res.Status = pro.Status;
                res.TopHot = pro.TopHot;
                res.ViewCount = pro.ViewCount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public IPagedList<SanPham> ListAll(int page, int pageSize)
        {
            return db.SanPhams.OrderByDescending(o => o.CreateDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<SanPham> ListAll()
        {
            return db.SanPhams.OrderByDescending(o => o.Order);
        }
        public SanPham GetProductByID(int id)
        {
            return db.SanPhams.Find(id);
        }
        public List<SanPham> SelectSanPhamByNhomSanPhamId(int? nhomSanPhamId)
        {
            return db.SanPhams.Where(x => x.NhomSP_ID == nhomSanPhamId).ToList();

        }
        public List<SanPham> GetTopHotProduct()
        {
            return db.SanPhams.Where(o => o.TopHot == true).ToList();
        }
        public List<SanPham> GetNewArivalsProduct()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            return db.SanPhams.Take<SanPham>(10).ToList();
        }
    }
}
