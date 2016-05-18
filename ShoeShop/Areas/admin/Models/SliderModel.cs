using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class SliderModel
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string ModìyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Status { get; set; }
    }
}