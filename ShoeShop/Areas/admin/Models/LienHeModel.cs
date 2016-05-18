using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class LienHeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
     
    }
}