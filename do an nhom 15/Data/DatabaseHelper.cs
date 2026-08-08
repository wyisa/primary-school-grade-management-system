using Microsoft.Data.SqlClient;
using do_an_nhom_15.Utils;
using do_an_nhom_15.Models;

namespace do_an_nhom_15.Data
{
    public static class DatabaseHelper
    {
        // ===== CẤU HÌNH KẾT NỐI SQL SERVER =====
        // Sửa lại ServerName cho đúng với máy của bạn:
        // - Cài SQL Server 2019 Developer/Express, instance mặc định thường là "." hoặc "localhost"
        // - Nếu khi cài đặt bạn chọn Named Instance dạng SQLEXPRESS thì để: @".\SQLEXPRESS"
        // - Có thể mở SSMS, xem tên server ở màn hình Connect để biết chính xác
        private const string ServerName = @".\SQLEXPRESS";
        private const string DatabaseName = "QuanLyDiem";

        // Chuỗi kết nối tới SQL Server (dùng Windows Authentication - không cần username/password)
        private static readonly string ConnectionString =
            $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True;TrustServerCertificate=True;";

        // Chuỗi kết nối tới master, dùng để kiểm tra/tạo database khi chưa tồn tại
        private static readonly string MasterConnectionString =
            $"Server={ServerName};Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

        // Tạo kết nối tới SQL Server (đến đúng database QuanLyDiem)
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Khởi tạo database
        public static void InitializeDatabase()
        {
            // Bước 1: Tạo database QuanLyDiem trên SQL Server nếu chưa tồn tại
            using (SqlConnection masterConnection = new SqlConnection(MasterConnectionString))
            {
                masterConnection.Open();

                using SqlCommand createDbCommand = masterConnection.CreateCommand();

                createDbCommand.CommandText =
                    $"IF DB_ID(N'{DatabaseName}') IS NULL CREATE DATABASE [{DatabaseName}];";

                createDbCommand.ExecuteNonQuery();
            }

            // Bước 2: Tạo các bảng bên trong database QuanLyDiem
            using SqlConnection connection = GetConnection();

            connection.Open();

            string sql = @"

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LopHoc')
BEGIN
    CREATE TABLE LopHoc
    (
        MaLop NVARCHAR(10) PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HocSinh')
BEGIN
    CREATE TABLE HocSinh
    (
        MaHocSinh NVARCHAR(10) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        NgaySinh NVARCHAR(10) NOT NULL,
        GioiTinh NVARCHAR(10) NOT NULL,
        MaLop NVARCHAR(10) NOT NULL,
        FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MonHoc')
BEGIN
    CREATE TABLE MonHoc
    (
        MaMon NVARCHAR(10) PRIMARY KEY,
        TenMon NVARCHAR(100) NOT NULL,
        HinhThucDanhGia NVARCHAR(50) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaiKhoan')
BEGIN
    CREATE TABLE TaiKhoan
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
        MatKhau NVARCHAR(100) NOT NULL,
        HoTen NVARCHAR(100) NOT NULL,
        VaiTro NVARCHAR(30) NOT NULL,
        MaLopPhuTrach NVARCHAR(10) NULL,
        MaHocSinh NVARCHAR(10) NULL,
        FOREIGN KEY (MaLopPhuTrach) REFERENCES LopHoc(MaLop),
        FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh)
    );
END;

-- Bảng điểm mới: đánh giá theo năm học / học kỳ / mốc đánh giá (thay cho công thức hệ số 1-2-3 cũ)
-- Bảng Diem cũ đã được loại bỏ khỏi lược đồ vì không còn được sử dụng.
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DiemDinhKy')
BEGIN
    CREATE TABLE DiemDinhKy
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaHocSinh NVARCHAR(10) NOT NULL,
        MaMon NVARCHAR(10) NOT NULL,
        NamHoc NVARCHAR(20) NOT NULL,
        HocKy NVARCHAR(20) NOT NULL,
        ThoiDiemDanhGia NVARCHAR(50) NOT NULL,
        DiemKiemTraDinhKy FLOAT NULL,
        KetQuaMonHoc NVARCHAR(50) NULL,
        NhanXet NVARCHAR(500) NULL,
        CONSTRAINT UQ_DiemDinhKy UNIQUE (MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia),
        FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh),
        FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
    );
END;

-- Đánh giá phẩm chất & năng lực - tách riêng hoàn toàn khỏi điểm số
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DanhGiaPhamChatNangLuc')
BEGIN
    CREATE TABLE DanhGiaPhamChatNangLuc
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaHocSinh NVARCHAR(10) NOT NULL,
        NamHoc NVARCHAR(20) NOT NULL,
        HocKy NVARCHAR(20) NOT NULL,
        PhamChat NVARCHAR(50) NULL,
        NangLuc NVARCHAR(50) NULL,
        NhanXet NVARCHAR(500) NULL,
        CONSTRAINT UQ_DanhGiaPhamChat UNIQUE (MaHocSinh, NamHoc, HocKy),
        FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh)
    );
END;

";

            using SqlCommand command = connection.CreateCommand();

            command.CommandText = sql;

            command.ExecuteNonQuery();

            // Thêm dữ liệu mặc định theo đúng thứ tự (lớp -> môn -> học sinh -> điểm -> tài khoản)
            InsertDefaultClasses(connection);
            InsertDefaultSubjects(connection);
            RemoveOldDefaultSubjects(connection);
            InsertDefaultStudents(connection);
            InsertDefaultGrades(connection);
            InsertDefaultDanhGiaPhamChat(connection);
            InsertDefaultAccounts(connection);
            MigrateMatKhauCuSangBam(connection);
            InsertDefaultParentAccounts(connection);
        }


        // Thêm danh sách lớp mặc định
        private static void InsertDefaultClasses(SqlConnection connection)
        {
            string sql = @"

IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '1A') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('1A', N'Lớp 1A');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '1B') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('1B', N'Lớp 1B');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '2A') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('2A', N'Lớp 2A');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '2B') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('2B', N'Lớp 2B');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '3A') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('3A', N'Lớp 3A');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '3B') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('3B', N'Lớp 3B');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '4A') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('4A', N'Lớp 4A');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '4B') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('4B', N'Lớp 4B');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '5A') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('5A', N'Lớp 5A');
IF NOT EXISTS (SELECT 1 FROM LopHoc WHERE MaLop = '5B') INSERT INTO LopHoc (MaLop, TenLop) VALUES ('5B', N'Lớp 5B');

";

            using SqlCommand command = connection.CreateCommand();

            command.CommandText = sql;

            command.ExecuteNonQuery();
        }


        // Thêm dữ liệu môn học mặc định (chỉ còn Toán, Tiếng Việt, Tiếng Anh)
        private static void InsertDefaultSubjects(
            SqlConnection connection)
        {
            string sql = @"

IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMon = 'TOAN') INSERT INTO MonHoc (MaMon, TenMon, HinhThucDanhGia) VALUES ('TOAN', N'Toán', N'Điểm số');
IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMon = 'TVIE') INSERT INTO MonHoc (MaMon, TenMon, HinhThucDanhGia) VALUES ('TVIE', N'Tiếng Việt', N'Điểm số');
IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMon = 'TANH') INSERT INTO MonHoc (MaMon, TenMon, HinhThucDanhGia) VALUES ('TANH', N'Tiếng Anh', N'Điểm số');

";

            using SqlCommand command = connection.CreateCommand();

            command.CommandText = sql;

            command.ExecuteNonQuery();
        }


        // Xóa các môn học mặc định cũ nếu chưa có điểm nào được nhập
        private static void RemoveOldDefaultSubjects(
            SqlConnection connection)
        {
            string sql = @"

DELETE FROM MonHoc
WHERE MaMon IN ('TINH', 'DAOD', 'TNXH', 'LSDL', 'MTHU', 'AMNH', 'GDTC')
  AND MaMon NOT IN (SELECT DISTINCT MaMon FROM DiemDinhKy);

";

            using SqlCommand command = connection.CreateCommand();

            command.CommandText = sql;

            command.ExecuteNonQuery();
        }


        // Thêm 10 học sinh mẫu cho MỖI lớp trong 10 lớp (1A,1B,...,5B) = 100 học sinh, mỗi em một họ tên riêng
        private static void InsertDefaultStudents(SqlConnection connection)
        {
            // Danh sách lớp kèm năm sinh phù hợp với độ tuổi của khối lớp đó
            (string MaLop, int NamSinh)[] danhSachLop =
            {
                ("1A", 2019), ("1B", 2019),
                ("2A", 2018), ("2B", 2018),
                ("3A", 2017), ("3B", 2017),
                ("4A", 2016), ("4B", 2016),
                ("5A", 2015), ("5B", 2015),
            };

            // 10 họ phổ biến kết hợp với 5 tên nam / 5 tên nữ => 50 tên nam + 50 tên nữ, không tên nào trùng nhau
            string[] danhSachHo = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Vũ", "Đặng", "Bùi", "Đỗ", "Ngô" };
            string[] tenNam = { "An", "Bình", "Cường", "Dũng", "Em" };
            string[] tenNu = { "Bích", "Châu", "Diễm", "Hoa", "Lan" };

            int soThuTu = 1;
            int chiSoNam = 0;
            int chiSoNu = 0;

            foreach ((string maLop, int namSinh) in danhSachLop)
            {
                for (int i = 0; i < 10; i++)
                {
                    string maHocSinh = $"HS{soThuTu:D3}";

                    bool laNam = i % 2 == 0;
                    string hoTen;
                    string gioiTinh;

                    if (laNam)
                    {
                        hoTen = $"{danhSachHo[chiSoNam % 10]} Văn {tenNam[chiSoNam / 10]}";
                        gioiTinh = "Nam";
                        chiSoNam++;
                    }
                    else
                    {
                        hoTen = $"{danhSachHo[chiSoNu % 10]} Thị {tenNu[chiSoNu / 10]}";
                        gioiTinh = "Nữ";
                        chiSoNu++;
                    }

                    int thang = 1 + (soThuTu % 12);
                    int ngay = 1 + (soThuTu % 28);
                    string ngaySinh = $"{namSinh:D4}-{thang:D2}-{ngay:D2}";

                    using SqlCommand command = connection.CreateCommand();

                    command.CommandText = @"
                        IF NOT EXISTS (SELECT 1 FROM HocSinh WHERE MaHocSinh = @maHocSinh)
                        INSERT INTO HocSinh (MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop)
                        VALUES (@maHocSinh, @hoTen, @ngaySinh, @gioiTinh, @maLop);
                    ";

                    command.Parameters.AddWithValue("@maHocSinh", maHocSinh);
                    command.Parameters.AddWithValue("@hoTen", hoTen);
                    command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@maLop", maLop);

                    command.ExecuteNonQuery();

                    soThuTu++;
                }
            }
        }


        // Thêm điểm mẫu cho TẤT CẢ học sinh, ở CẢ 3 môn, tại các mốc đánh giá phù hợp với khối lớp
        private static void InsertDefaultGrades(SqlConnection connection)
        {
            string namHoc = MocDanhGia.DanhSachNamHocGoiY[0];

            // Lấy danh sách toàn bộ học sinh kèm lớp để suy ra khối
            List<(string MaHocSinh, string MaLop)> danhSachHocSinh = new List<(string, string)>();

            using (SqlCommand selectHocSinh = connection.CreateCommand())
            {
                selectHocSinh.CommandText = "SELECT MaHocSinh, MaLop FROM HocSinh;";

                using SqlDataReader reader = selectHocSinh.ExecuteReader();

                while (reader.Read())
                {
                    danhSachHocSinh.Add((reader.GetString(0), reader.GetString(1)));
                }
            }

            // Lấy danh sách toàn bộ mã môn học hiện có
            List<string> danhSachMon = new List<string>();

            using (SqlCommand selectMon = connection.CreateCommand())
            {
                selectMon.CommandText = "SELECT MaMon FROM MonHoc;";

                using SqlDataReader reader = selectMon.ExecuteReader();

                while (reader.Read())
                {
                    danhSachMon.Add(reader.GetString(0));
                }
            }

            // Sinh điểm cho từng (học sinh, môn, mốc đánh giá phù hợp khối lớp)
            // theo công thức có tính biến thiên nhưng cố định, để mỗi lần chạy đều ra dữ liệu giống nhau
            for (int hs = 0; hs < danhSachHocSinh.Count; hs++)
            {
                (string maHocSinh, string maLop) = danhSachHocSinh[hs];
                string[] cacMoc = MocDanhGia.LayMocTheoMaLop(maLop);

                for (int m = 0; m < danhSachMon.Count; m++)
                {
                    string maMon = danhSachMon[m];

                    for (int mocIndex = 0; mocIndex < cacMoc.Length; mocIndex++)
                    {
                        string thoiDiemDanhGia = cacMoc[mocIndex];
                        string hocKy = MocDanhGia.LayHocKyTuMoc(thoiDiemDanhGia);

                        double diemSo = 5.0 + ((hs * 7 + m * 3 + mocIndex * 2) % 11) * 0.5;

                        Diem diem = new Diem
                        {
                            MaHocSinh = maHocSinh,
                            MaMon = maMon,
                            NamHoc = namHoc,
                            HocKy = hocKy,
                            ThoiDiemDanhGia = thoiDiemDanhGia,
                            DiemKiemTraDinhKy = diemSo
                        };

                        diem.KetQuaMonHoc = diem.GoiYKetQuaMonHocTheoDiem();

                        using SqlCommand command = connection.CreateCommand();

                        command.CommandText = @"
                            IF NOT EXISTS (
                                SELECT 1 FROM DiemDinhKy
                                WHERE MaHocSinh = @maHocSinh AND MaMon = @maMon AND NamHoc = @namHoc
                                      AND HocKy = @hocKy AND ThoiDiemDanhGia = @thoiDiemDanhGia
                            )
                            INSERT INTO DiemDinhKy
                            (MaHocSinh, MaMon, NamHoc, HocKy, ThoiDiemDanhGia, DiemKiemTraDinhKy, KetQuaMonHoc, NhanXet)
                            VALUES (@maHocSinh, @maMon, @namHoc, @hocKy, @thoiDiemDanhGia, @diem, @ketQua, NULL);
                        ";

                        command.Parameters.AddWithValue("@maHocSinh", diem.MaHocSinh);
                        command.Parameters.AddWithValue("@maMon", diem.MaMon);
                        command.Parameters.AddWithValue("@namHoc", diem.NamHoc);
                        command.Parameters.AddWithValue("@hocKy", diem.HocKy);
                        command.Parameters.AddWithValue("@thoiDiemDanhGia", diem.ThoiDiemDanhGia);
                        command.Parameters.AddWithValue("@diem", diem.DiemKiemTraDinhKy!.Value);
                        command.Parameters.AddWithValue("@ketQua", diem.KetQuaMonHoc);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        // Thêm đánh giá phẩm chất & năng lực mẫu cho TẤT CẢ học sinh, học kỳ I năm học mặc định
        private static void InsertDefaultDanhGiaPhamChat(SqlConnection connection)
        {
            string namHoc = MocDanhGia.DanhSachNamHocGoiY[0];

            List<string> danhSachHocSinh = new List<string>();

            using (SqlCommand selectHocSinh = connection.CreateCommand())
            {
                selectHocSinh.CommandText = "SELECT MaHocSinh FROM HocSinh;";

                using SqlDataReader reader = selectHocSinh.ExecuteReader();

                while (reader.Read())
                {
                    danhSachHocSinh.Add(reader.GetString(0));
                }
            }

            for (int i = 0; i < danhSachHocSinh.Count; i++)
            {
                string maHocSinh = danhSachHocSinh[i];
                string phamChat = DanhGiaPhamChatNangLuc.DanhSachMucDo[i % 3];
                string nangLuc = DanhGiaPhamChatNangLuc.DanhSachMucDo[(i + 1) % 3];

                using SqlCommand command = connection.CreateCommand();

                command.CommandText = @"
                    IF NOT EXISTS (
                        SELECT 1 FROM DanhGiaPhamChatNangLuc
                        WHERE MaHocSinh = @maHocSinh AND NamHoc = @namHoc AND HocKy = @hocKy
                    )
                    INSERT INTO DanhGiaPhamChatNangLuc (MaHocSinh, NamHoc, HocKy, PhamChat, NangLuc, NhanXet)
                    VALUES (@maHocSinh, @namHoc, @hocKy, @phamChat, @nangLuc, NULL);
                ";

                command.Parameters.AddWithValue("@maHocSinh", maHocSinh);
                command.Parameters.AddWithValue("@namHoc", namHoc);
                command.Parameters.AddWithValue("@hocKy", "Học kỳ I");
                command.Parameters.AddWithValue("@phamChat", phamChat);
                command.Parameters.AddWithValue("@nangLuc", nangLuc);

                command.ExecuteNonQuery();
            }
        }


        // Thêm tài khoản mẫu có sẵn:
        // - Tài khoản Giáo viên cho MỖI lớp trong 10 lớp (mật khẩu mặc định: 123456)
        // - Tài khoản Phụ huynh mẫu (chỉ xem điểm của HS001)
        // ================================
        // MIGRATION: BĂM LẠI MẬT KHẨU CỦA CÁC TÀI KHOẢN CŨ
        // ================================
        // Trước khi tính năng băm mật khẩu (BaoMat.BamMatKhau) được thêm vào, các tài khoản đã tạo
        // (đăng ký giáo viên, tạo tài khoản phụ huynh...) đang lưu MatKhau ở dạng văn bản thuần.
        // Vì đăng nhập bây giờ băm mật khẩu người dùng nhập rồi mới so sánh, các tài khoản CŨ đó sẽ
        // không đăng nhập được nữa nếu không băm lại giá trị đang lưu trong CSDL cho khớp.
        // Hàm này chạy mỗi lần khởi động app, tự dò các dòng MatKhau chưa đúng định dạng mã băm
        // SHA-256 (64 ký tự hex) và băm lại 1 lần duy nhất; các tài khoản đã băm rồi sẽ được bỏ qua.
        private static void MigrateMatKhauCuSangBam(SqlConnection connection)
        {
            List<(string TenDangNhap, string MatKhau)> danhSachCanBam = new List<(string, string)>();

            using (SqlCommand lenhDoc = connection.CreateCommand())
            {
                lenhDoc.CommandText = "SELECT TenDangNhap, MatKhau FROM TaiKhoan";

                using SqlDataReader reader = lenhDoc.ExecuteReader();

                while (reader.Read())
                {
                    string tenDangNhap = reader.GetString(0);
                    string matKhau = reader.GetString(1);

                    if (!BaoMat.LaMaBamHopLe(matKhau))
                    {
                        danhSachCanBam.Add((tenDangNhap, matKhau));
                    }
                }
            }

            foreach ((string tenDangNhap, string matKhauCu) in danhSachCanBam)
            {
                using SqlCommand lenhCapNhat = connection.CreateCommand();

                lenhCapNhat.CommandText = @"
                    UPDATE TaiKhoan
                    SET MatKhau = @matKhauMoi
                    WHERE TenDangNhap = @tenDangNhap
                ";

                lenhCapNhat.Parameters.AddWithValue("@matKhauMoi", BaoMat.BamMatKhau(matKhauCu));
                lenhCapNhat.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                lenhCapNhat.ExecuteNonQuery();
            }
        }

        private static void InsertDefaultAccounts(SqlConnection connection)
        {
            (string TenDangNhap, string HoTen, string MaLop)[] danhSachGiaoVien =
            {
                ("giaovien1a", "Nguyễn Thị Giáo Viên 1A", "1A"),
                ("giaovien1b", "Nguyễn Thị Giáo Viên 1B", "1B"),
                ("giaovien2a", "Nguyễn Thị Giáo Viên 2A", "2A"),
                ("giaovien2b", "Nguyễn Thị Giáo Viên 2B", "2B"),
                ("giaovien3a", "Nguyễn Thị Giáo Viên 3A", "3A"),
                ("giaovien3b", "Nguyễn Thị Giáo Viên 3B", "3B"),
                ("giaovien4a", "Nguyễn Thị Giáo Viên 4A", "4A"),
                ("giaovien4b", "Nguyễn Thị Giáo Viên 4B", "4B"),
                ("giaovien5a", "Nguyễn Thị Giáo Viên 5A", "5A"),
                ("giaovien5b", "Nguyễn Thị Giáo Viên 5B", "5B"),
            };

            foreach ((string tenDangNhap, string hoTen, string maLop) in danhSachGiaoVien)
            {
                using SqlCommand command = connection.CreateCommand();

                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap)
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh)
                    VALUES (@tenDangNhap, @matKhau, @hoTen, @vaiTro, @maLop, NULL);
                ";

                command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@matKhau", BaoMat.BamMatKhau("123456"));
                command.Parameters.AddWithValue("@hoTen", hoTen);
                command.Parameters.AddWithValue("@vaiTro", "Giáo viên");
                command.Parameters.AddWithValue("@maLop", maLop);

                command.ExecuteNonQuery();
            }

            // Giữ lại tài khoản giáo viên cũ "giaovien" (lớp 1A) để không phá dữ liệu đã dùng trước đó
            using (SqlCommand lenhGiaoVienCu = connection.CreateCommand())
            {
                lenhGiaoVienCu.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'giaovien')
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh)
                    VALUES ('giaovien', @matKhau, N'Nguyễn Thị Giáo Viên', N'Giáo viên', '1A', NULL);
                ";

                lenhGiaoVienCu.Parameters.AddWithValue("@matKhau", BaoMat.BamMatKhau("123456"));
                lenhGiaoVienCu.ExecuteNonQuery();
            }

            using (SqlCommand lenhPhuHuynhCu = connection.CreateCommand())
            {
                lenhPhuHuynhCu.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'phuhuynh')
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh)
                    VALUES ('phuhuynh', @matKhau, N'Phụ huynh của Nguyễn Văn An', N'Phụ huynh', NULL, 'HS001');
                ";

                lenhPhuHuynhCu.Parameters.AddWithValue("@matKhau", BaoMat.BamMatKhau("123456"));
                lenhPhuHuynhCu.ExecuteNonQuery();
            }
        }


        // Tạo 1 tài khoản Phụ huynh cho MỖI học sinh (mật khẩu mặc định: 123456)
        // Tên đăng nhập: phuhuynh + số thứ tự học sinh (VD: học sinh HS007 -> phuhuynh007)
        private static void InsertDefaultParentAccounts(SqlConnection connection)
        {
            List<(string MaHocSinh, string HoTen)> danhSachHocSinh = new List<(string, string)>();

            using (SqlCommand selectHocSinh = connection.CreateCommand())
            {
                selectHocSinh.CommandText = "SELECT MaHocSinh, HoTen FROM HocSinh ORDER BY MaHocSinh;";

                using SqlDataReader reader = selectHocSinh.ExecuteReader();

                while (reader.Read())
                {
                    danhSachHocSinh.Add((reader.GetString(0), reader.GetString(1)));
                }
            }

            foreach ((string maHocSinh, string hoTenHocSinh) in danhSachHocSinh)
            {
                string soThuTu = maHocSinh.Length >= 5 ? maHocSinh.Substring(2) : maHocSinh;
                string tenDangNhap = $"phuhuynh{soThuTu}";
                string hoTenTaiKhoan = $"Phụ huynh của {hoTenHocSinh}";

                using SqlCommand command = connection.CreateCommand();

                command.CommandText = @"
                    IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = @tenDangNhap)
                    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, VaiTro, MaLopPhuTrach, MaHocSinh)
                    VALUES (@tenDangNhap, @matKhau, @hoTen, @vaiTro, NULL, @maHocSinh);
                ";

                command.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@matKhau", BaoMat.BamMatKhau("123456"));
                command.Parameters.AddWithValue("@hoTen", hoTenTaiKhoan);
                command.Parameters.AddWithValue("@vaiTro", "Phụ huynh");
                command.Parameters.AddWithValue("@maHocSinh", maHocSinh);

                command.ExecuteNonQuery();
            }
        }
    }
}
