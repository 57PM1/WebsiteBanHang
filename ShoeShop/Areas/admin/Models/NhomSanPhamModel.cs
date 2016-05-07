using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class NhomSanPhamModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public IEnumerable<NhomSanPham> Parent { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
        public string SeoTitle { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string MetaKeyword { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public int? Status { get; set; }
        public string MetaDescription { get; set; }
        public bool ShowOnHome { get; set; }
        public NhomSanPhamModel()
        {
            this.Parent = new NhomsanphamDao().ListAll(1,10);
        }
    }
   
}