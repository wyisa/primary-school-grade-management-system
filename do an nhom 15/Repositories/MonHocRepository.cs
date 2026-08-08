using Microsoft.Data.SqlClient;
using do_an_nhom_15.Data;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Repositories
{
    public class MonHocRepository
    {
        public List<MonHoc> LayTatCa()
        {
            List<MonHoc> danhSach = new List<MonHoc>();

            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT MaMon, TenMon, HinhThucDanhGia
                FROM MonHoc
                ORDER BY TenMon
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                danhSach.Add(new MonHoc
                {
                    MaMon = reader.GetString(0),
                    TenMon = reader.GetString(1),
                    HinhThucDanhGia = reader.GetString(2)
                });
            }

            return danhSach;
        }

        public bool KiemTraMaMonTonTai(string maMon)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM MonHoc
                WHERE MaMon = @MaMon
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaMon", maMon);

            long soLuong = Convert.ToInt64(command.ExecuteScalar());

            return soLuong > 0;
        }

        public bool Them(MonHoc monHoc)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO MonHoc (MaMon, TenMon, HinhThucDanhGia)
                VALUES (@MaMon, @TenMon, @HinhThucDanhGia)
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaMon", monHoc.MaMon);
            command.Parameters.AddWithValue("@TenMon", monHoc.TenMon);
            command.Parameters.AddWithValue("@HinhThucDanhGia", monHoc.HinhThucDanhGia);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        public bool Sua(MonHoc monHoc)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                UPDATE MonHoc
                SET TenMon = @TenMon,
                    HinhThucDanhGia = @HinhThucDanhGia
                WHERE MaMon = @MaMon
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@TenMon", monHoc.TenMon);
            command.Parameters.AddWithValue("@HinhThucDanhGia", monHoc.HinhThucDanhGia);
            command.Parameters.AddWithValue("@MaMon", monHoc.MaMon);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }

        public bool Xoa(string maMon)
        {
            using SqlConnection connection = DatabaseHelper.GetConnection();
            connection.Open();

            string sql = @"
                DELETE FROM MonHoc
                WHERE MaMon = @MaMon
            ";

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@MaMon", maMon);

            int soDong = command.ExecuteNonQuery();

            return soDong > 0;
        }
    }
}