using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Dao;
using Models.EF;


namespace ShoeShop.Areas.admin.Models
{
    public class KhachHangModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
        public IEnumerable<KhachHang> Parent { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
    }
}