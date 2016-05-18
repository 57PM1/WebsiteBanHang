using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class PageModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Author { get; set; }
        public string PageContent { get; set; }
    }
}