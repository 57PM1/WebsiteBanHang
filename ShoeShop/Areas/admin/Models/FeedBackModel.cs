using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class FeedBackModel
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? Status { get; set; }
        public string Content { get; set; }
    }
}