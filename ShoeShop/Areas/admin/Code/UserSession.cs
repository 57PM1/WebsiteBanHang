using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public int UserRole { get; set; }
    }
}