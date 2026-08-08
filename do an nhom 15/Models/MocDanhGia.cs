namespace do_an_nhom_15.Models
{
    // Lớp tiện ích: quy định các mốc đánh giá định kỳ theo khối lớp
    // (tinh thần Thông tư 27/2020/TT-BGDĐT - giảm số lần kiểm tra định kỳ cho khối nhỏ)
    public static class MocDanhGia
    {
        // Khối 1-3: chỉ đánh giá 2 mốc trong năm
        public static readonly string[] MocKhoi1Den3 = { "Cuối học kỳ I", "Cuối năm học" };

        // Khối 4-5: đánh giá đủ 4 mốc trong năm
        public static readonly string[] MocKhoi4Den5 =
        {
            "Giữa học kỳ I", "Cuối học kỳ I", "Giữa học kỳ II", "Cuối năm học"
        };

        // Danh sách năm học gợi ý (giáo viên có thể gõ năm khác nếu cần)
        public static readonly string[] DanhSachNamHocGoiY = { "2025-2026", "2026-2027", "2027-2028" };

        // Lấy khối lớp (1..5) từ mã lớp, VD "3B" -> 3. Trả về 0 nếu không xác định được.
        public static int LayKhoiTuMaLop(string? maLop)
        {
            if (string.IsNullOrEmpty(maLop))
            {
                return 0;
            }

            char kyTuDau = maLop[0];

            return char.IsDigit(kyTuDau) ? kyTuDau - '0' : 0;
        }

        // Lấy danh sách mốc đánh giá phù hợp với khối lớp
        public static string[] LayMocTheoKhoi(int khoi)
        {
            return khoi >= 1 && khoi <= 3 ? MocKhoi1Den3 : MocKhoi4Den5;
        }

        // Lấy danh sách mốc đánh giá phù hợp trực tiếp từ mã lớp
        public static string[] LayMocTheoMaLop(string? maLop)
        {
            return LayMocTheoKhoi(LayKhoiTuMaLop(maLop));
        }

        // Suy ra học kỳ từ mốc đánh giá
        public static string LayHocKyTuMoc(string thoiDiemDanhGia)
        {
            return thoiDiemDanhGia is "Giữa học kỳ I" or "Cuối học kỳ I"
                ? "Học kỳ I"
                : "Học kỳ II";
        }
    }
}
