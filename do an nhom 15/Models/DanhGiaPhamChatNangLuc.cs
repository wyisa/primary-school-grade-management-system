namespace do_an_nhom_15.Models
{
    // Đánh giá phẩm chất và năng lực của học sinh theo học kỳ
    // Tách riêng hoàn toàn khỏi điểm số / kết quả môn học
    public class DanhGiaPhamChatNangLuc
    {
        public int Id { get; set; }

        public string MaHocSinh { get; set; } = string.Empty;

        public string NamHoc { get; set; } = string.Empty;

        public string HocKy { get; set; } = string.Empty;

        // Tốt / Đạt / Cần cố gắng
        public string PhamChat { get; set; } = string.Empty;

        // Tốt / Đạt / Cần cố gắng
        public string NangLuc { get; set; } = string.Empty;

        public string? NhanXet { get; set; }

        public static readonly string[] DanhSachMucDo = { "Tốt", "Đạt", "Cần cố gắng" };
    }
}