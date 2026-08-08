using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class HocSinhService
    {
        private readonly HocSinhRepository _hocSinhRepository;

        public HocSinhService()
        {
            _hocSinhRepository = new HocSinhRepository();
        }

        // Lấy danh sách học sinh của lớp giáo viên đang đăng nhập (QT-03)
        public List<HocSinh> LayDanhSachTheoLop(string maLop)
        {
            return _hocSinhRepository.LayTheoLop(maLop);
        }

        // Lấy 1 học sinh theo mã (dùng cho Form xem điểm con)
        public HocSinh? LayTheoMa(string maHocSinh)
        {
            return _hocSinhRepository.LayTheoMa(maHocSinh);
        }

        public List<HocSinh> TimKiem(string maLop, string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return _hocSinhRepository.LayTheoLop(maLop);
            }

            return _hocSinhRepository.TimKiem(maLop, tuKhoa.Trim());
        }

        // ================================
        // THÊM HỌC SINH (QT-04: tự gán vào lớp giáo viên đang đăng nhập)
        // ================================
        public (bool ThanhCong, string ThongBao) Them(
            string maHocSinh,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string maLopPhuTrach)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng nhập mã học sinh.");
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return (false, "Vui lòng nhập họ và tên.");
            }

            if (string.IsNullOrWhiteSpace(gioiTinh))
            {
                return (false, "Vui lòng chọn giới tính.");
            }

            if (string.IsNullOrWhiteSpace(maLopPhuTrach))
            {
                return (false, "Tài khoản chưa được gán lớp phụ trách.");
            }

            maHocSinh = maHocSinh.Trim();
            hoTen = hoTen.Trim();

            if (_hocSinhRepository.KiemTraMaHocSinhTonTai(maHocSinh))
            {
                return (false, "Mã học sinh đã tồn tại.");
            }

            try
            {
                HocSinh hocSinh = new HocSinh
                {
                    MaHocSinh = maHocSinh,
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    MaLop = maLopPhuTrach // QT-04: luôn lấy từ lớp phụ trách, không cho chọn tùy ý
                };

                bool thanhCong = _hocSinhRepository.Them(hocSinh);

                return thanhCong
                    ? (true, "Thêm học sinh thành công.")
                    : (false, "Thêm học sinh thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // SỬA HỌC SINH
        // ================================
        public (bool ThanhCong, string ThongBao) Sua(
            string maHocSinh,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string maLopPhuTrach)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng chọn học sinh cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                return (false, "Vui lòng nhập họ và tên.");
            }

            try
            {
                HocSinh hocSinh = new HocSinh
                {
                    MaHocSinh = maHocSinh.Trim(),
                    HoTen = hoTen.Trim(),
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    MaLop = maLopPhuTrach
                };

                bool thanhCong = _hocSinhRepository.Sua(hocSinh);

                return thanhCong
                    ? (true, "Cập nhật học sinh thành công.")
                    : (false, "Không tìm thấy học sinh trong lớp phụ trách của bạn.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // XÓA HỌC SINH
        // ================================
        public (bool ThanhCong, string ThongBao) Xoa(string maHocSinh, string maLopPhuTrach)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng chọn học sinh cần xóa.");
            }

            try
            {
                bool thanhCong = _hocSinhRepository.Xoa(maHocSinh.Trim(), maLopPhuTrach);

                return thanhCong
                    ? (true, "Xóa học sinh thành công.")
                    : (false, "Không tìm thấy học sinh trong lớp phụ trách của bạn.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}