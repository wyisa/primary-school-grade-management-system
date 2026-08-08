using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Repositories
{
    public class HocSinhRepository
    {
        // ================================
        // LẤY DANH SÁCH HỌC SINH THEO LỚP (QT-03)
        // ================================
        public List<HocSinh> LayTheoLop(string maLop)
        {
            List<HocSinh> danhSach = new List<HocSinh>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop
                FROM HocSinh
                WHERE MaLop = @MaLop
                ORDER BY MaHocSinh
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaLop", maLop);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(new HocSinh
                {
                    MaHocSinh = reader.GetString(0),
                    HoTen = reader.GetString(1),
                    NgaySinh = DateTime.Parse(reader.GetString(2)),
                    GioiTinh = reader.GetString(3),
                    MaLop = reader.GetString(4)
                });
            }

            SapXepTheoTenGoi(danhSach);

            return danhSach;
        }

        // Sắp xếp danh sách học sinh theo MÃ HỌC SINH tăng dần.
        private static void SapXepTheoTenGoi(List<HocSinh> danhSach)
        {
            System.Globalization.CultureInfo vanHoa;

            try
            {
                vanHoa = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            }
            catch
            {
                vanHoa = System.Globalization.CultureInfo.InvariantCulture;
            }

            StringComparer soSanh = StringComparer.Create(vanHoa, ignoreCase: true);

            danhSach.Sort((a, b) => soSanh.Compare(a.MaHocSinh, b.MaHocSinh));
        }
        public HocSinh? LayTheoMa(string maHocSinh)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop
                FROM HocSinh
                WHERE MaHocSinh = @MaHocSinh
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new HocSinh
                {
                    MaHocSinh = reader.GetString(0),
                    HoTen = reader.GetString(1),
                    NgaySinh = DateTime.Parse(reader.GetString(2)),
                    GioiTinh = reader.GetString(3),
                    MaLop = reader.GetString(4)
                };
            }

            return null;
        }

        // ================================
        // TÌM KIẾM HỌC SINH TRONG LỚP (theo mã hoặc họ tên)
        // ================================
        public List<HocSinh> TimKiem(string maLop, string tuKhoa)
        {
            List<HocSinh> danhSach = new List<HocSinh>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop
                FROM HocSinh
                WHERE MaLop = @MaLop
                  AND (MaHocSinh LIKE @TuKhoa OR HoTen LIKE @TuKhoa)
                ORDER BY MaHocSinh
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaLop", maLop);
            command.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(new HocSinh
                {
                    MaHocSinh = reader.GetString(0),
                    HoTen = reader.GetString(1),
                    NgaySinh = DateTime.Parse(reader.GetString(2)),
                    GioiTinh = reader.GetString(3),
                    MaLop = reader.GetString(4)
                });
            }

            SapXepTheoTenGoi(danhSach);

            return danhSach;
        }

        // ================================
        // KIỂM TRA MÃ HỌC SINH ĐÃ TỒN TẠI
        // ================================
        public bool KiemTraMaHocSinhTonTai(string maHocSinh)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM HocSinh
                WHERE MaHocSinh = @MaHocSinh
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", maHocSinh);

            long soLuong = Convert.ToInt64(command.ExecuteScalar());

            return soLuong > 0;
        }

        // ================================
        // THÊM HỌC SINH
        // ================================
        public bool Them(HocSinh hocSinh)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO HocSinh (MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop)
                VALUES (@MaHocSinh, @HoTen, @NgaySinh, @GioiTinh, @MaLop)
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaHocSinh", hocSinh.MaHocSinh);
            command.Parameters.AddWithValue("@HoTen", hocSinh.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", hocSinh.NgaySinh.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@GioiTinh", hocSinh.GioiTinh);
            command.Parameters.AddWithValue("@MaLop", hocSinh.MaLop);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        // ================================
        // SỬA HỌC SINH
        // ================================
        public bool Sua(HocSinh hocSinh)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE HocSinh
                SET HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh
                WHERE MaHocSinh = @MaHocSinh
                  AND MaLop = @MaLop
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@HoTen", hocSinh.HoTen);
            command.Parameters.AddWithValue("@NgaySinh", hocSinh.NgaySinh.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@GioiTinh", hocSinh.GioiTinh);
            command.Parameters.AddWithValue("@MaHocSinh", hocSinh.MaHocSinh);
            command.Parameters.AddWithValue("@MaLop", hocSinh.MaLop);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        // ================================
        // XÓA HỌC SINH (chỉ xóa trong đúng lớp - QT-03)
        // ================================
        public bool Xoa(string maHocSinh, string maLop)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            using SqlTransaction giaoDich = connection.BeginTransaction();

            try
            {
                // HocSinh đang bị 3 bảng khác tham chiếu khóa ngoại (DiemDinhKy, DanhGiaPhamChatNangLuc,
                // TaiKhoan của phụ huynh) mà KHÔNG có ON DELETE CASCADE, nên phải chủ động xóa dữ liệu
                // liên quan trước, nếu không câu lệnh DELETE FROM HocSinh bên dưới sẽ luôn bị SQL Server
                // chặn lại (báo lỗi vi phạm khóa ngoại) đối với bất kỳ học sinh nào đã có điểm/đánh giá.
                XoaTheoMaHocSinh(connection, giaoDich, "DELETE FROM DiemDinhKy WHERE MaHocSinh = @MaHocSinh", maHocSinh);
                XoaTheoMaHocSinh(connection, giaoDich, "DELETE FROM DanhGiaPhamChatNangLuc WHERE MaHocSinh = @MaHocSinh", maHocSinh);
                XoaTheoMaHocSinh(connection, giaoDich, "DELETE FROM TaiKhoan WHERE MaHocSinh = @MaHocSinh", maHocSinh);

                using SqlCommand lenhXoaHocSinh = connection.CreateCommand();
                lenhXoaHocSinh.Transaction = giaoDich;

                lenhXoaHocSinh.CommandText = @"
                    DELETE FROM HocSinh
                    WHERE MaHocSinh = @MaHocSinh
                      AND MaLop = @MaLop
                ";

                lenhXoaHocSinh.Parameters.AddWithValue("@MaHocSinh", maHocSinh);
                lenhXoaHocSinh.Parameters.AddWithValue("@MaLop", maLop);

                int soDong = lenhXoaHocSinh.ExecuteNonQuery();

                giaoDich.Commit();

                return soDong > 0;
            }
            catch
            {
                giaoDich.Rollback();
                throw;
            }
        }

        // Xóa toàn bộ bản ghi của 1 học sinh trong 1 bảng con, dùng chung trong transaction ở trên
        private static void XoaTheoMaHocSinh(SqlConnection connection, SqlTransaction giaoDich, string cauLenh, string maHocSinh)
        {
            using SqlCommand lenh = connection.CreateCommand();
            lenh.Transaction = giaoDich;
            lenh.CommandText = cauLenh;
            lenh.Parameters.AddWithValue("@MaHocSinh", maHocSinh);
            lenh.ExecuteNonQuery();
        }
    }
}