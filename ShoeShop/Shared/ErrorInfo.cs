using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Shared
{
    public class ErrorInfo
    {
        public string insertSuccess { get; set; }
        public string insertFail { get; set; }
        public string extra { get; set; }

        public ErrorInfo()
        {
            insertSuccess=string.Format("Thêm mới {0} thành công!",extra);
            insertFail = string.Format("Thêm mới {0} thất bại!",extra);
        }
    }
}