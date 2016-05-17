using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;
using Models.Dao;

namespace ShoeShop.Areas.admin.Models
{
    public class SanPhamsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public int? NhomSP_ID { get; set; }
        public string Detail { get; set; }
        public string Images { get; set; }
        public string MoreImages { get; set; }
        public decimal Price { get; set; }
        public decimal PromotionPrice { get; set; }
        public float Quantity { get; set; }
        public DateTime Date { get; set; }
        public int? Order { get; set; }
        public bool IncludeVAT { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public int? Status { get; set; }
        public bool TopHot { get; set; }
        public int? ViewCount { get; set; }
    }
}