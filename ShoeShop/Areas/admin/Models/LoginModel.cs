using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Tên đăng nhập!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập Mật khẩu!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}