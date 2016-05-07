using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShop.Common
{
    public static class CommonConstant
    {
        #region LOGIN
        public static string USER_SESSION = "USER_SESSION";
        public static string LOGIN_FAIL = "Tên tài khoản hoặc mật khẩu không đúng!";
        public static string USER_IS_BLOCKED = "Tài khoản đã bị khóa!";

        #endregion
        #region DANHMUCSANPHAM
        public static string INSERT_SUCCESS = "Thêm mới danh mục thành công!";
        public static string INSERT_FAIL = "Thêm mới danh mục không thành công!";
        public static string DELETE_SUCCESS = "Xóa danh mục thành công!";
        public static string DELETE_FAIL = "Xóa danh mục không thành công!";
        public static string UPDATE_SUCCESS = "Cập nhật danh mục thành công!";
        public static string UPDATE_FAIL = "Cập nhật danh mục không thành công!";
        #endregion
    }
}