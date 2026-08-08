using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class MonHocService
    {
        private readonly MonHocRepository _monHocRepository;

        public MonHocService()
        {
            _monHocRepository = new MonHocRepository();
        }

        public List<MonHoc> LayTatCa()
        {
            return _monHocRepository.LayTatCa();
        }

        public (bool ThanhCong, string ThongBao) Them(string maMon, string tenMon, string hinhThucDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                return (false, "Vui lòng nhập mã môn.");
            }

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                return (false, "Vui lòng nhập tên môn học.");
            }

            if (string.IsNullOrWhiteSpace(hinhThucDanhGia))
            {
                return (false, "Vui lòng chọn hình thức đánh giá.");
            }

            maMon = maMon.Trim();
            tenMon = tenMon.Trim();

            if (_monHocRepository.KiemTraMaMonTonTai(maMon))
            {
                return (false, "Mã môn đã tồn tại.");
            }

            try
            {
                bool thanhCong = _monHocRepository.Them(new MonHoc
                {
                    MaMon = maMon,
                    TenMon = tenMon,
                    HinhThucDanhGia = hinhThucDanhGia
                });

                return thanhCong
                    ? (true, "Thêm môn học thành công.")
                    : (false, "Thêm môn học thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        public (bool ThanhCong, string ThongBao) Sua(string maMon, string tenMon, string hinhThucDanhGia)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                return (false, "Vui lòng chọn môn học cần sửa.");
            }

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                return (false, "Vui lòng nhập tên môn học.");
            }

            try
            {
                bool thanhCong = _monHocRepository.Sua(new MonHoc
                {
                    MaMon = maMon.Trim(),
                    TenMon = tenMon.Trim(),
                    HinhThucDanhGia = hinhThucDanhGia
                });

                return thanhCong
                    ? (true, "Cập nhật môn học thành công.")
                    : (false, "Không tìm thấy môn học.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                return (false, "Vui lòng chọn môn học cần xóa.");
            }

            try
            {
                bool thanhCong = _monHocRepository.Xoa(maMon.Trim());

                return thanhCong
                    ? (true, "Xóa môn học thành công.")
                    : (false, "Không tìm thấy môn học.");
            }
            catch (Exception ex)
            {
                // Nếu môn học đã có điểm liên quan, FOREIGN KEY sẽ chặn xóa
                return (false, "Không thể xóa: môn học đã có điểm được nhập, hoặc lỗi: " + ex.Message);
            }
        }
    }
}