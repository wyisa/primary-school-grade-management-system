using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Repositories
{
    public class DanhGiaPhamChatRepository
    {
        // Lấy toàn bộ đánh giá phẩm chất/năng lực của 1 học sinh (mọi năm học/học kỳ)
        public List<DanhGiaPhamChatNangLuc> LayTheoHocSinh(string maHocSinh)
        {
            List<DanhGiaPhamChatNangLuc> danhSach = new List<DanhGiaPhamChatNangLuc>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, NamHoc, HocKy, PhamChat, NangLuc, NhanXet
                FROM DanhGiaPhamChatNangLuc
                WHERE MaHocSinh = @MaHocSinh
                ORDER BY NamHoc, HocKy
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(Doc(reader));
            }

            return danhSach;
        }

        public DanhGiaPhamChatNangLuc? LayMotBanGhi(string maHocSinh, string namHoc, string hocKy)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, NamHoc, HocKy, PhamChat, NangLuc, NhanXet
                FROM DanhGiaPhamChatNangLuc
                WHERE MaHocSinh = @MaHocSinh AND NamHoc = @NamHoc AND HocKy = @HocKy
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);
            command.Parameters.AddWithValue("@NamHoc", namHoc);
            command.Parameters.AddWithValue("@HocKy", hocKy);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return Doc(reader);
            }

            return null;
        }

        public bool Them(DanhGiaPhamChatNangLuc danhGia)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO DanhGiaPhamChatNangLuc (MaHocSinh, NamHoc, HocKy, PhamChat, NangLuc, NhanXet)
                VALUES (@MaHocSinh, @NamHoc, @HocKy, @PhamChat, @NangLuc, @NhanXet)
            ";

            using SqlCommand command = connection.CreateCommand();
            GanThamSo(command, danhGia);
            command.CommandText = sql;

            return command.ExecuteNonQuery() > 0;
        }

        public bool Sua(DanhGiaPhamChatNangLuc danhGia)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE DanhGiaPhamChatNangLuc
                SET PhamChat = @PhamChat, NangLuc = @NangLuc, NhanXet = @NhanXet
                WHERE MaHocSinh = @MaHocSinh AND NamHoc = @NamHoc AND HocKy = @HocKy
            ";

            using SqlCommand command = connection.CreateCommand();
            GanThamSo(command, danhGia);
            command.CommandText = sql;

            return command.ExecuteNonQuery() > 0;
        }

        private static void GanThamSo(SqlCommand command, DanhGiaPhamChatNangLuc d)
        {
            command.Parameters.AddWithValue("@MaHocSinh", d.MaHocSinh);
            command.Parameters.AddWithValue("@NamHoc", d.NamHoc);
            command.Parameters.AddWithValue("@HocKy", d.HocKy);
            command.Parameters.AddWithValue("@PhamChat", (object?)d.PhamChat ?? DBNull.Value);
            command.Parameters.AddWithValue("@NangLuc", (object?)d.NangLuc ?? DBNull.Value);
            command.Parameters.AddWithValue("@NhanXet", (object?)d.NhanXet ?? DBNull.Value);
        }

        private static DanhGiaPhamChatNangLuc Doc(SqlDataReader reader)
        {
            return new DanhGiaPhamChatNangLuc
            {
                Id = reader.GetInt32(0),
                MaHocSinh = reader.GetString(1),
                NamHoc = reader.GetString(2),
                HocKy = reader.GetString(3),
                PhamChat = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                NangLuc = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                NhanXet = reader.IsDBNull(6) ? null : reader.GetString(6)
            };
        }
    }
}
