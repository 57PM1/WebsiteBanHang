using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Areas.admin.Models
{
    public class HoTroModel
    {
        public int Id { get; set; }     
        public string Name { get; set; }
        public string Tel { get; set; }
        public int Type { get; set; }
        public string Nick { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
    }
}