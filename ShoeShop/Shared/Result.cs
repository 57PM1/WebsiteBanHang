using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoeShop.Shared;
namespace ShoeShop
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string errInfo { get; set; }
        public err error { get; set; }
    }
}