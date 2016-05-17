using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Models
{
    public class HomePageViewModel
    {
        public List<NhomSanPham> Danhmucsanphams { get; set; }
        public List<SanPham> Sanphams { set; get; }
        public Footer Footer { get; set; }
        public Slider Slider { get; set; }
        public List<Menu> Menus { get; set; }
        public LienHe Lienhe { get; set; }
        public List<SanPham> SanPhamNoiBat { set; get; }
        public List<SanPham> SanPhamMoiNhat { get; set; }
    }
}
