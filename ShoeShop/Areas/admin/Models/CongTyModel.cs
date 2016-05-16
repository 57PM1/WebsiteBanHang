using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class CongTyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Phone { get; set; }
        public IEnumerable<CongTy> Parent { get; set; }
        public string Fax { get; set; }
       
    }
}