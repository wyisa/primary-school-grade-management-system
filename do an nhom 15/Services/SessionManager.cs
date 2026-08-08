using do_an_nhom_15.Models;

namespace do_an_nhom_15.Services
{
    public static class SessionManager
    {
        public static TaiKhoan?
            TaiKhoanDangNhap
        {
            get;
            set;
        }


        public static bool DaDangNhap()
        {
            return TaiKhoanDangNhap != null;
        }


        public static void DangXuat()
        {
            TaiKhoanDangNhap = null;
        }
    }
}