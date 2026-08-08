namespace do_an_nhom_15.Models
{
    // Kết quả đánh giá học tập của 1 học sinh - 1 môn - tại 1 mốc đánh giá cụ thể
    // (thay cho cách tính điểm trung bình theo hệ số 1-2-3 kiểu cũ)
    public class Diem
    {
        public int Id { get; set; }

        public string MaHocSinh { get; set; } = string.Empty;

        public string MaMon { get; set; } = string.Empty;

        public string NamHoc { get; set; } = string.Empty;

        public string HocKy { get; set; } = string.Empty;

        public string ThoiDiemDanhGia { get; set; } = string.Empty;

        // Điểm kiểm tra định kỳ (thang 10) - có thể để trống nếu môn/mốc không có bài kiểm tra
        public double? DiemKiemTraDinhKy { get; set; }

        // Hoàn thành tốt / Hoàn thành / Chưa hoàn thành - giáo viên tự chọn
        public string KetQuaMonHoc { get; set; } = string.Empty;

        // Nhận xét của giáo viên (không bắt buộc)
        public string? NhanXet { get; set; }

        // Danh sách kết quả đánh giá môn học hợp lệ
        public static readonly string[] DanhSachKetQuaMonHoc =
        {
            "Hoàn thành tốt", "Hoàn thành", "Chưa hoàn thành"
        };

        // Chỉ mang tính GỢI Ý dựa trên điểm số - giáo viên vẫn có toàn quyền chọn lại
        // vì kết quả môn học thực tế còn phụ thuộc thái độ, quá trình học tập...
        public string GoiYKetQuaMonHocTheoDiem()
        {
            if (!DiemKiemTraDinhKy.HasValue)
            {
                return string.Empty;
            }

            if (DiemKiemTraDinhKy.Value >= 9.0)
            {
                return "Hoàn thành tốt";
            }

            if (DiemKiemTraDinhKy.Value >= 5.0)
            {
                return "Hoàn thành";
            }

            return "Chưa hoàn thành";
        }
    }
}
