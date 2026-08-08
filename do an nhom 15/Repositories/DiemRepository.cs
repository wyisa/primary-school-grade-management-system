using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Repositories
{
    public class DiemRepository
    {
        // Lấy toàn bộ bản ghi đánh giá (mọi môn, mọi năm học, mọi mốc) của 1 học sinh
        public List<Diem> LayTheoHocSinh(string maHocSinh)
        {
            List<Diem> danhSach = new List<Diem>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet
                FROM DiemDinhKy
                WHERE MaHocSinh = @MaHocSinh
                ORDER BY NamHoc, HocKy, ThoiDiemDanhGia, MaMon
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(DocDiem(reader));
            }

            return danhSach;
        }

        // Lấy toàn bộ bản ghi của 1 học sinh - 1 môn (mọi năm học/mốc)
        public List<Diem> LayTheoHocSinhVaMon(string maHocSinh, string maMon)
        {
            List<Diem> danhSach = new List<Diem>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet
                FROM DiemDinhKy
                WHERE MaHocSinh = @MaHocSinh AND MaMon = @MaMon
                ORDER BY NamHoc, HocKy, ThoiDiemDanhGia
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);
            command.Parameters.AddWithValue("@MaMon", maMon);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(DocDiem(reader));
            }

            return danhSach;
        }

        // Lấy toàn bộ bản ghi của 1 môn, tại 1 mốc đánh giá cụ thể (dùng cho Thống kê)
        public List<Diem> LayTheoMonVaMoc(string maMon, string namHoc, string hocKy, string thoiDiemDanhGia)
        {
            List<Diem> danhSach = new List<Diem>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet
                FROM DiemDinhKy
                WHERE MaMon = @MaMon AND NamHoc = @NamHoc AND HocKy = @HocKy AND ThoiDiemDanhGia = @ThoiDiemDanhGia
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaMon", maMon);
            command.Parameters.AddWithValue("@NamHoc", namHoc);
            command.Parameters.AddWithValue("@HocKy", hocKy);
            command.Parameters.AddWithValue("@ThoiDiemDanhGia", thoiDiemDanhGia);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(DocDiem(reader));
            }

            return danhSach;
        }

        // Lấy đúng 1 bản ghi theo khóa nghiệp vụ (dùng để kiểm tra thêm mới / cập nhật)
        public Diem? LayMotBanGhi(string maHocSinh, string maMon, string namHoc, string hocKy, string thoiDiemDanhGia)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet
                FROM DiemDinhKy
                WHERE MaHocSinh = @MaHocSinh AND MaMon = @MaMon AND NamHoc = @NamHoc
                      AND HocKy = @HocKy AND ThoiDiemDanhGia = @ThoiDiemDanhGia
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);
            command.Parameters.AddWithValue("@MaMon", maMon);
            command.Parameters.AddWithValue("@NamHoc", namHoc);
            command.Parameters.AddWithValue("@HocKy", hocKy);
            command.Parameters.AddWithValue("@ThoiDiemDanhGia", thoiDiemDanhGia);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return DocDiem(reader);
            }

            return null;
        }

        public bool Them(Diem diem)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO DiemDinhKy
                (MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet)
                VALUES
                (@MaHocSinh, @MaMon, @NamHoc, @HocKy, @ThoiDiemDanhGia, @DiemKiemTraDinhKy, @KetQuaMonHoc, @NhanXet)
            ";

            using SqlCommand command = connection.CreateCommand();
            GanThamSo(command, diem);
            command.CommandText = sql;

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        public bool Sua(Diem diem)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE DiemDinhKy
                SET DiemKiemTraDinhKy = @DiemKiemTraDinhKy,
                    KetQuaMonHoc = @KetQuaMonHoc,
                    NhanXet = @NhanXet
                WHERE MaHocSinh = @MaHocSinh AND MaMon = @MaMon AND NamHoc = @NamHoc
                      AND HocKy = @HocKy AND ThoiDiemDanhGia = @ThoiDiemDanhGia
            ";

            using SqlCommand command = connection.CreateCommand();
            GanThamSo(command, diem);
            command.CommandText = sql;

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        private static void GanThamSo(SqlCommand command, Diem diem)
        {
            command.Parameters.AddWithValue("@MaHocSinh", diem.MaHocSinh);
            command.Parameters.AddWithValue("@MaMon", diem.MaMon);
            command.Parameters.AddWithValue("@NamHoc", diem.NamHoc);
            command.Parameters.AddWithValue("@HocKy", diem.HocKy);
            command.Parameters.AddWithValue("@ThoiDiemDanhGia", diem.ThoiDiemDanhGia);
            command.Parameters.AddWithValue("@DiemKiemTraDinhKy", (object?)diem.DiemKiemTraDinhKy ?? DBNull.Value);
            command.Parameters.AddWithValue("@KetQuaMonHoc", (object?)diem.KetQuaMonHoc ?? DBNull.Value);
            command.Parameters.AddWithValue("@NhanXet", (object?)diem.NhanXet ?? DBNull.Value);
        }

        private static Diem DocDiem(SqlDataReader reader)
        {
            return new Diem
            {
                Id = reader.GetInt32(0),
                MaHocSinh = reader.GetString(1),
                MaMon = reader.GetString(2),
                NamHoc = reader.GetString(3),
                HocKy = reader.GetString(4),
                ThoiDiemDanhGia = reader.GetString(5),
                DiemKiemTraDinhKy = reader.IsDBNull(6) ? null : reader.GetDouble(6),
                KetQuaMonHoc = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                NhanXet = reader.IsDBNull(8) ? null : reader.GetString(8)
            };
        }
    }
}
