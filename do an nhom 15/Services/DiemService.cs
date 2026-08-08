using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class DiemService
    {
        private readonly DiemRepository _diemRepository;

        public DiemService()
        {
            _diemRepository = new DiemRepository();
        }

        public List<Diem> LayTheoHocSinh(string maHocSinh)
        {
            return _diemRepository.LayTheoHocSinh(maHocSinh);
        }

        public List<Diem> LayTheoHocSinhVaMon(string maHocSinh, string maMon)
        {
            return _diemRepository.LayTheoHocSinhVaMon(maHocSinh, maMon);
        }

        public List<Diem> LayTheoMonVaMoc(string maMon, string namHoc, string hocKy, string thoiDiemDanhGia)
        {
            return _diemRepository.LayTheoMonVaMoc(maMon, namHoc, hocKy, thoiDiemDanhGia);
        }

        public Diem? LayMotBanGhi(string maHocSinh, string maMon, string namHoc, string hocKy, string thoiDiemDanhGia)
        {
            return _diemRepository.LayMotBanGhi(maHocSinh, maMon, namHoc, hocKy, thoiDiemDanhGia);
        }

        // ================================
        // LƯU KẾT QUẢ ĐÁNH GIÁ ĐỊNH KỲ - tự thêm mới hoặc cập nhật theo khóa nghiệp vụ
        // (MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia)
        // ================================
        public (bool ThanhCong, string ThongBao, Diem? KetQua) LuuDiem(
            string maHocSinh,
            string maMon,
            string namHoc,
            string hocKy,
            string thoiDiemDanhGia,
            double? diemKiemTraDinhKy,
            string ketQuaMonHoc,
            string? nhanXet)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng chọn học sinh.", null);
            }

            if (string.IsNullOrWhiteSpace(maMon))
            {
                return (false, "Vui lòng chọn môn học.", null);
            }

            if (string.IsNullOrWhiteSpace(namHoc))
            {
                return (false, "Vui lòng chọn năm học.", null);
            }

            if (string.IsNullOrWhiteSpace(thoiDiemDanhGia))
            {
                return (false, "Vui lòng chọn thời điểm đánh giá.", null);
            }

            if (diemKiemTraDinhKy.HasValue && (diemKiemTraDinhKy.Value < 0 || diemKiemTraDinhKy.Value > 10))
            {
                return (false, "Điểm phải nằm trong khoảng từ 0 đến 10.", null);
            }

            if (string.IsNullOrWhiteSpace(ketQuaMonHoc) && !diemKiemTraDinhKy.HasValue)
            {
                return (false, "Vui lòng nhập điểm hoặc chọn kết quả đánh giá môn học.", null);
            }

            try
            {
                Diem diem = new Diem
                {
                    MaHocSinh = maHocSinh,
                    MaMon = maMon,
                    NamHoc = namHoc,
                    HocKy = hocKy,
                    ThoiDiemDanhGia = thoiDiemDanhGia,
                    DiemKiemTraDinhKy = diemKiemTraDinhKy,
                    KetQuaMonHoc = ketQuaMonHoc,
                    NhanXet = string.IsNullOrWhiteSpace(nhanXet) ? null : nhanXet
                };

                Diem? banGhiHienCo = _diemRepository.LayMotBanGhi(maHocSinh, maMon, namHoc, hocKy, thoiDiemDanhGia);

                bool thanhCong = banGhiHienCo == null
                    ? _diemRepository.Them(diem)
                    : _diemRepository.Sua(diem);

                return thanhCong
                    ? (true, "Lưu kết quả đánh giá thành công.", diem)
                    : (false, "Lưu kết quả đánh giá thất bại.", null);
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message, null);
            }
        }

        // Dùng khi thống kê nhanh theo 1 điểm số cho trước (VD: điểm KTĐK)
        public static string XepLoaiTheoDiem(double diemKiemTraDinhKy)
        {
            if (diemKiemTraDinhKy >= 9.0)
            {
                return "Hoàn thành tốt";
            }

            if (diemKiemTraDinhKy >= 5.0)
            {
                return "Hoàn thành";
            }

            return "Chưa hoàn thành";
        }
    }
}
