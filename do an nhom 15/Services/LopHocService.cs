using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class LopHocService
    {
        private readonly LopHocRepository _lopHocRepository;

        public LopHocService()
        {
            _lopHocRepository = new LopHocRepository();
        }

        public List<LopHoc> LayTatCa()
        {
            return _lopHocRepository.LayTatCa();
        }

        // ================================
        // THÊM LỚP
        // ================================
        public (bool ThanhCong, string ThongBao) ThemLop(string maLop, string tenLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                return (false, "Vui lòng nhập mã lớp.");
            }

            if (string.IsNullOrWhiteSpace(tenLop))
            {
                return (false, "Vui lòng nhập tên lớp.");
            }

            maLop = maLop.Trim();
            tenLop = tenLop.Trim();

            if (_lopHocRepository.KiemTraMaLopTonTai(maLop))
            {
                return (false, "Mã lớp đã tồn tại.");
            }

            try
            {
                bool thanhCong = _lopHocRepository.Them(new LopHoc
                {
                    MaLop = maLop,
                    TenLop = tenLop
                });

                return thanhCong
                    ? (true, "Thêm lớp thành công.")
                    : (false, "Thêm lớp thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // SỬA LỚP
        // ================================
        public (bool ThanhCong, string ThongBao) SuaLop(string maLop, string tenLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                return (false, "Vui lòng chọn lớp cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenLop))
            {
                return (false, "Vui lòng nhập tên lớp.");
            }

            maLop = maLop.Trim();
            tenLop = tenLop.Trim();

            if (!_lopHocRepository.KiemTraMaLopTonTai(maLop))
            {
                return (false, "Mã lớp không tồn tại.");
            }

            try
            {
                bool thanhCong = _lopHocRepository.Sua(new LopHoc
                {
                    MaLop = maLop,
                    TenLop = tenLop
                });

                return thanhCong
                    ? (true, "Cập nhật lớp thành công.")
                    : (false, "Cập nhật lớp thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        // ================================
        // XÓA LỚP
        // ================================
        public (bool ThanhCong, string ThongBao) XoaLop(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop))
            {
                return (false, "Vui lòng chọn lớp cần xóa.");
            }

            maLop = maLop.Trim();

            if (!_lopHocRepository.KiemTraMaLopTonTai(maLop))
            {
                return (false, "Mã lớp không tồn tại.");
            }

            int soHocSinh = _lopHocRepository.DemHocSinhTrongLop(maLop);

            if (soHocSinh > 0)
            {
                return (false, $"Không thể xóa lớp vì lớp vẫn còn {soHocSinh} học sinh. Vui lòng chuyển hoặc xóa hết học sinh trước khi xóa lớp.");
            }

            int soTaiKhoanPhuTrach = _lopHocRepository.DemTaiKhoanPhuTrachLop(maLop);

            if (soTaiKhoanPhuTrach > 0)
            {
                return (false, "Không thể xóa lớp vì vẫn còn tài khoản giáo viên đang phụ trách lớp này.");
            }

            try
            {
                bool thanhCong = _lopHocRepository.Xoa(maLop);

                return thanhCong
                    ? (true, "Xóa lớp thành công.")
                    : (false, "Xóa lớp thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Không thể xóa lớp (có thể do dữ liệu liên quan chưa được xóa hết): " + ex.Message);
            }
        }
    }
}