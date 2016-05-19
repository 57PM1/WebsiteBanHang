using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Models.Dao
{
    public class NhomsanphamDao
    {
        private ShoeShopDbContext db = null;
        public NhomsanphamDao()
        {
            db = new ShoeShopDbContext();
        }
        public int Insert(NhomSanPham entity)
        {
            db.NhomSanPhams.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Delete(int id)
        {
            try
            {
                var res = db.NhomSanPhams.Find(id);
                db.NhomSanPhams.Remove(res);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public IPagedList<NhomSanPham> SearchResult( string searchKey, int pageNum=1, int pageSize=10)
        {
            var res = db.NhomSanPhams.Where(o => o.Name.Contains(searchKey));
            return res.OrderByDescending(o=>o.CreateDate).ToPagedList<NhomSanPham>(pageNum, pageSize);
        }
        public NhomSanPham ViewDetail(int id)
        {
            return db.NhomSanPhams.Find(id);
        }
        public bool Update(NhomSanPham cate)
        {
            try
            {
                var res = db.NhomSanPhams.Find(cate.Id);
                res.Name = cate.Name;
                res.Content = cate.Content;
                res.CreateDate = cate.CreateDate;
                res.Images = cate.Images;
                res.Order = cate.Order;
                res.SeoTitle = cate.SeoTitle;
                res.ParentID = cate.ParentID;
                res.Status = cate.Status;
                res.ShowOnHome = cate.ShowOnHome;
                res.MetaTitle = cate.MetaTitle;
                res.MetaKeyword = cate.MetaKeyword;
                res.MetaDescription = cate.MetaDescription;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
        public IPagedList<NhomSanPham> ListAll(int page, int pageSize)
        {
            return db.NhomSanPhams.OrderByDescending(o=>o.CreateDate).ToPagedList(page,pageSize);
        }
        public List<NhomSanPham> ListAll()
        {
            return db.NhomSanPhams.ToList();
        }
    }
}