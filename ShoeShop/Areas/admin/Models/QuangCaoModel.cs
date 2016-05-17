using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class QuangCaoModel
    {
         public string ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Link { get; set; }
        public int Target { get; set; }
        public int Position { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
    }
}