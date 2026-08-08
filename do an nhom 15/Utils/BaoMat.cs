using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace do_an_nhom_15.Utils
{
    // Băm mật khẩu bằng SHA-256 trước khi lưu vào CSDL hoặc so sánh khi đăng nhập.
    // Đáp ứng yêu cầu phi chức năng "Bảo mật" đã nêu trong báo cáo phân tích (mục 1.5):
    // mật khẩu KHÔNG được lưu ở dạng văn bản thuần (plain text).
    public static class BaoMat
    {
        private static readonly Regex MauMaBam = new Regex("^[0-9a-f]{64}$", RegexOptions.Compiled);

        public static string BamMatKhau(string matKhauGoc)
        {
            byte[] duLieu = Encoding.UTF8.GetBytes(matKhauGoc);
            byte[] maBam = SHA256.HashData(duLieu);

            return Convert.ToHexString(maBam).ToLowerInvariant();
        }

        // Kiểm tra xem 1 chuỗi đã ở dạng mã băm SHA-256 (64 ký tự hex) hay chưa.
        // Dùng để phát hiện các tài khoản CŨ còn lưu mật khẩu dạng văn bản thuần (trước khi
        // tính năng băm mật khẩu được thêm vào), để tự động băm lại cho đúng chuẩn mới.
        public static bool LaMaBamHopLe(string chuoi)
        {
            return !string.IsNullOrEmpty(chuoi) && MauMaBam.IsMatch(chuoi);
        }
    }
}
