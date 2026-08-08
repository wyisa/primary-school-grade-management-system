using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class TaiKhoanService
    {
        private readonly TaiKhoanRepository _taiKhoanRepository;

        public TaiKhoanService()
        {
            _taiKhoanRepository = new TaiKhoanRepository();
        }

        // ================================
        // ĐĂNG KÝ TÀI KHOẢN GIÁO VIÊN
        // ================================
        public (bool ThanhCong, string ThongBao) DangKyGiaoVien(
            string tenDangNhap,
            string matKhau,
            string hoTen,
            string maLopPhuTrach)
        {
            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                return (false, "Vui lòng nhập tên đăng nhập.");
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return (false, "Vui lòng nhập mật khẩu.");
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return (false, "Vui lòng nhập họ và tên.");
            }

            // Kiểm tra lớp phụ trách
            if (string.IsNullOrWhiteSpace(maLopPhuTrach))
            {
                return (false, "Vui lòng chọn lớp phụ trách.");
            }

            // Kiểm tra tài khoản đã tồn tại
            bool daTonTai = _taiKhoanRepository.KiemTraTenDangNhapTonTai(tenDangNhap);

            if (daTonTai)
            {
                return (false, "Tên đăng nhập đã tồn tại.");
            }

            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    TenDangNhap = tenDangNhap.Trim(),
                    MatKhau = matKhau,
                    HoTen = hoTen.Trim(),
                    VaiTro = "Giáo viên",
                    MaLopPhuTrach = maLopPhuTrach
                };

                bool thanhCong = _taiKhoanRepository.Them(taiKhoan);

                if (thanhCong)
                {
                    return (true, "Đăng ký tài khoản giáo viên thành công.");
                }

                return (false, "Đăng ký tài khoản thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // ĐĂNG NHẬP
        // ================================
        public TaiKhoan? DangNhap(string tenDangNhap, string matKhau)
        {
            return _taiKhoanRepository.DangNhap(tenDangNhap, matKhau);
        }

        // ================================
        // ĐỔI MẬT KHẨU
        // ================================
        public (bool ThanhCong, string ThongBao) DoiMatKhau(
            string tenDangNhap,
            string matKhauCu,
            string matKhauMoi,
            string nhapLaiMatKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                return (false, "Vui lòng nhập mật khẩu hiện tại.");
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                return (false, "Vui lòng nhập mật khẩu mới.");
            }

            if (matKhauMoi != nhapLaiMatKhauMoi)
            {
                return (false, "Mật khẩu nhập lại không khớp.");
            }

            if (matKhauMoi == matKhauCu)
            {
                return (false, "Mật khẩu mới phải khác mật khẩu hiện tại.");
            }

            try
            {
                bool thanhCong = _taiKhoanRepository.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi);

                return thanhCong
                    ? (true, "Đổi mật khẩu thành công.")
                    : (false, "Mật khẩu hiện tại không đúng.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // ĐĂNG KÝ TÀI KHOẢN PHỤ HUYNH (do giáo viên tạo, gắn với 1 học sinh)
        // ================================
        public (bool ThanhCong, string ThongBao) DangKyPhuHuynh(
            string tenDangNhap,
            string matKhau,
            string maHocSinh,
            string hoTenHocSinh)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                return (false, "Vui lòng nhập tên đăng nhập.");
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                return (false, "Vui lòng nhập mật khẩu.");
            }

            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng chọn học sinh trước khi tạo tài khoản.");
            }

            tenDangNhap = tenDangNhap.Trim();

            if (_taiKhoanRepository.KiemTraTenDangNhapTonTai(tenDangNhap))
            {
                return (false, "Tên đăng nhập đã tồn tại.");
            }

            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    TenDangNhap = tenDangNhap,
                    MatKhau = matKhau,
                    HoTen = "Phụ huynh " + hoTenHocSinh,
                    VaiTro = "Phụ huynh",
                    MaLopPhuTrach = null,
                    MaHocSinh = maHocSinh
                };

                bool thanhCong = _taiKhoanRepository.Them(taiKhoan);

                return thanhCong
                    ? (true, "Tạo tài khoản phụ huynh thành công.")
                    : (false, "Tạo tài khoản thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}