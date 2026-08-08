using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;
using do_an_nhom_15.Utils;

namespace do_an_nhom_15.Repositories
{
    public class TaiKhoanRepository
    {
        // ================================
        // KIỂM TRA TÊN ĐĂNG NHẬP ĐÃ TỒN TẠI
        // ================================
        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE TenDangNhap = @TenDangNhap
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

            long soLuong = Convert.ToInt64(command.ExecuteScalar());

            return soLuong > 0;
        }

        // ================================
        // THÊM TÀI KHOẢN
        // ================================
        public bool Them(TaiKhoan taiKhoan)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO TaiKhoan
                (TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh)
                VALUES
                (@TenDangNhap, @MatKhau, @HoTen, @VaiTro, @MaLopPhuTrach, @MaHocSinh)
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TenDangNhap", taiKhoan.TenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", BaoMat.BamMatKhau(taiKhoan.MatKhau));
            command.Parameters.AddWithValue("@HoTen", taiKhoan.HoTen);
            command.Parameters.AddWithValue("@VaiTro", taiKhoan.VaiTro);
            command.Parameters.AddWithValue("@MaLopPhuTrach", (object?)taiKhoan.MaLopPhuTrach ?? DBNull.Value);
            command.Parameters.AddWithValue("@MaHocSinh", (object?)taiKhoan.MaHocSinh ?? DBNull.Value);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        // ================================
        // ĐĂNG NHẬP (đã bổ sung MaHocSinh cho tài khoản phụ huynh)
        // ================================
        public TaiKhoan? DangNhap(string tenDangNhap, string matKhau)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh
                FROM TaiKhoan
                WHERE TenDangNhap = @TenDangNhap
                AND MatKhau = @MatKhau
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            command.Parameters.AddWithValue("@MatKhau", BaoMat.BamMatKhau(matKhau));

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new TaiKhoan
                {
                    TenDangNhap = reader.GetString(0),
                    MatKhau = reader.GetString(1),
                    HoTen = reader.GetString(2),
                    VaiTro = reader.GetString(3),
                    MaLopPhuTrach = reader.IsDBNull(4) ? null : reader.GetString(4),
                    MaHocSinh = reader.IsDBNull(5) ? null : reader.GetString(5)
                };
            }

            return null;
        }

        // ================================
        // ĐỔI MẬT KHẨU
        // ================================
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE TaiKhoan
                SET MatKhau = @MatKhauMoi
                WHERE TenDangNhap = @TenDangNhap
                AND MatKhau = @MatKhauCu
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MatKhauMoi", BaoMat.BamMatKhau(matKhauMoi));
            command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
            command.Parameters.AddWithValue("@MatKhauCu", BaoMat.BamMatKhau(matKhauCu));

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }
    }
}