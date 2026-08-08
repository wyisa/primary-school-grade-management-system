using do_an_nhom_15.Models;
using do_an_nhom_15.Repositories;

namespace do_an_nhom_15.Services
{
    public class DanhGiaPhamChatService
    {
        private readonly DanhGiaPhamChatRepository _repository;

        public DanhGiaPhamChatService()
        {
            _repository = new DanhGiaPhamChatRepository();
        }

        public List<DanhGiaPhamChatNangLuc> LayTheoHocSinh(string maHocSinh)
        {
            return _repository.LayTheoHocSinh(maHocSinh);
        }

        public DanhGiaPhamChatNangLuc? LayMotBanGhi(string maHocSinh, string namHoc, string hocKy)
        {
            return _repository.LayMotBanGhi(maHocSinh, namHoc, hocKy);
        }

        public (bool ThanhCong, string ThongBao) Luu(
            string maHocSinh, string namHoc, string hocKy,
            string phamChat, string nangLuc, string? nhanXet)
        {
            if (string.IsNullOrWhiteSpace(maHocSinh))
            {
                return (false, "Vui lòng chọn học sinh.");
            }

            if (string.IsNullOrWhiteSpace(namHoc) || string.IsNullOrWhiteSpace(hocKy))
            {
                return (false, "Vui lòng chọn năm học và học kỳ.");
            }

            if (string.IsNullOrWhiteSpace(phamChat) && string.IsNullOrWhiteSpace(nangLuc))
            {
                return (false, "Vui lòng chọn ít nhất một trong hai: phẩm chất hoặc năng lực.");
            }

            try
            {
                DanhGiaPhamChatNangLuc danhGia = new DanhGiaPhamChatNangLuc
                {
                    MaHocSinh = maHocSinh,
                    NamHoc = namHoc,
                    HocKy = hocKy,
                    PhamChat = phamChat,
                    NangLuc = nangLuc,
                    NhanXet = string.IsNullOrWhiteSpace(nhanXet) ? null : nhanXet
                };

                DanhGiaPhamChatNangLuc? hienCo = _repository.LayMotBanGhi(maHocSinh, namHoc, hocKy);

                bool thanhCong = hienCo == null
                    ? _repository.Them(danhGia)
                    : _repository.Sua(danhGia);

                return thanhCong
                    ? (true, "Lưu đánh giá phẩm chất & năng lực thành công.")
                    : (false, "Lưu thất bại.");
            }
            catch (Exception ex)
            {
                return (false, "Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
