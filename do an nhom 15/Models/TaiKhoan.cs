namespace do_an_nhom_15.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }

        public string TenDangNhap { get; set; } = string.Empty;

        public string MatKhau { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;

        public string VaiTro { get; set; } = string.Empty;

        // Dùng cho tài khoản giáo viên
        public string? MaLopPhuTrach { get; set; }

        // Dùng cho tài khoản phụ huynh
        public string? MaHocSinh { get; set; }
        public string MaLop { get; set; } = "";

        public string TenLop { get; set; } = "";
    }
}