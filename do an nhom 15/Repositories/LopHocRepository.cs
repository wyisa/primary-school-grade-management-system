using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Repositories
{
    public class LopHocRepository
    {
        public List<LopHoc> LayTatCa()
        {
            List<LopHoc> danhSach = new List<LopHoc>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT MaLop, TenLop
                FROM LopHoc
                ORDER BY MaLop
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(new LopHoc
                {
                    MaLop = reader.GetString(0),
                    TenLop = reader.GetString(1)
                });
            }

            return danhSach;
        }

        // ================================
        // KIỂM TRA MÃ LỚP ĐÃ TỒN TẠI
        // ================================
        public bool KiemTraMaLopTonTai(string maLop)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM LopHoc
                WHERE MaLop = @MaLop
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaLop", maLop);

            long soLuong = Convert.ToInt64(command.ExecuteScalar());

            return soLuong > 0;
        }

        // ================================
        // THÊM LỚP
        // ================================
        public bool Them(LopHoc lopHoc)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO LopHoc (MaLop, TenLop)
                VALUES (@MaLop, @TenLop)
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaLop", lopHoc.MaLop);
            command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        // ================================
        // SỬA LỚP
        // ================================
        public bool Sua(LopHoc lopHoc)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE LopHoc
                SET TenLop = @TenLop
                WHERE MaLop = @MaLop
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TenLop", lopHoc.TenLop);
            command.Parameters.AddWithValue("@MaLop", lopHoc.MaLop);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        // ================================
        // ĐẾM SỐ HỌC SINH ĐANG THUỘC LỚP (dùng để chặn xóa lớp còn học sinh)
        // ================================
        public int DemHocSinhTrongLop(string maLop)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM HocSinh WHERE MaLop = @MaLop";
            command.Parameters.AddWithValue("@MaLop", maLop);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        // ================================
        // ĐẾM SỐ TÀI KHOẢN GIÁO VIÊN ĐANG PHỤ TRÁCH LỚP (dùng để chặn xóa lớp còn giáo viên)
        // ================================
        public int DemTaiKhoanPhuTrachLop(string maLop)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM TaiKhoan WHERE MaLopPhuTrach = @MaLop";
            command.Parameters.AddWithValue("@MaLop", maLop);

            return Convert.ToInt32(command.ExecuteScalar());
        }

        // ================================
        // XÓA LỚP
        // ================================
        public bool Xoa(string maLop)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                DELETE FROM LopHoc
                WHERE MaLop = @MaLop
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaLop", maLop);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }
    }
}