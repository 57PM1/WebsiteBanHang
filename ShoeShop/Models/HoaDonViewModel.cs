using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class HoaDonViewModel
    {
        public DatHang hoadon { get; set; }
        public List<ChiTietDatHang> details { get; set; }

    }
}