using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class AboutModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Images { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public int Status { get; set; }
        public string Tag { get; set; }
        public string Content { get; set; }
    }
}