using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;
using do_an_nhom_15.Reports;
using System.Drawing.Printing;
using System.Globalization;
using ClosedXML.Excel;

namespace do_an_nhom_15
{
    public partial class FrmQuanLyDiem : Form
    {
        private readonly HocSinhService _hocSinhService;
        private readonly MonHocService _monHocService;
        private readonly DiemService _diemService;
        private readonly LopHocService _lopHocService;
        private readonly DanhGiaPhamChatService _phamChatService;

        private string _maLopPhuTrach = string.Empty;
        private string _tenLopPhuTrach = string.Empty;

        // Danh sách hiển thị trong cboHocSinh
        private class HocSinhLua
        {
            public string MaHocSinh { get; set; } = string.Empty;
            public string MaLop { get; set; } = string.Empty;
            public string HienThi { get; set; } = string.Empty;
            public override string ToString() => HienThi;
        }

        // Dữ liệu hiển thị trong bảng lịch sử đánh giá của học sinh đang chọn
        private class DongLichSu
        {
            public string MonHoc { get; set; } = string.Empty;
            public string NamHoc { get; set; } = string.Empty;
            public string HocKy { get; set; } = string.Empty;
            public string ThoiDiemDanhGia { get; set; } = string.Empty;
            public string DiemKiemTraDinhKy { get; set; } = string.Empty;
            public string KetQuaMonHoc { get; set; } = string.Empty;
            public string NhanXet { get; set; } = string.Empty;
        }

        // Dữ liệu dùng khi in bảng điểm
        private class DongInBangDiem
        {
            public string TenMon { get; set; } = string.Empty;
            public string ThoiDiemDanhGia { get; set; } = string.Empty;
            public string DiemKiemTraDinhKy { get; set; } = string.Empty;
            public string KetQuaMonHoc { get; set; } = string.Empty;
        }

        private List<DongInBangDiem> _duLieuIn = new List<DongInBangDiem>();
        private string _tenHocSinhIn = string.Empty;
        private string _maHocSinhIn = string.Empty;

        public FrmQuanLyDiem()
        {
            InitializeComponent();

            _hocSinhService = new HocSinhService();
            _monHocService = new MonHocService();
            _diemService = new DiemService();
            _lopHocService = new LopHocService();
            _phamChatService = new DanhGiaPhamChatService();

            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQuaMonHoc.DataSource = Diem.DanhSachKetQuaMonHoc.ToList();
            cboPhamChat.DataSource = DanhGiaPhamChatNangLuc.DanhSachMucDo.ToList();
            cboNangLuc.DataSource = DanhGiaPhamChatNangLuc.DanhSachMucDo.ToList();

            cboNamHoc.Items.AddRange(MocDanhGia.DanhSachNamHocGoiY);
            cboNamHoc.SelectedIndex = 0;

            cboHocKyPhamChat.Items.AddRange(new object[] { "Học kỳ I", "Học kỳ II" });
            cboHocKyPhamChat.SelectedIndex = 0;

            cboHocSinh.SelectedIndexChanged += cboHocSinh_SelectedIndexChanged;
            cboThoiDiemDanhGia.SelectedIndexChanged += cboThoiDiemDanhGia_SelectedIndexChanged;
            cboThoiDiemDanhGia.SelectedIndexChanged += (s, e) => LamMoiBangLichSu();
            cboMonHoc.SelectedIndexChanged += (s, e) => TuDongDoKetQuaHienCo();
            cboNamHoc.SelectedIndexChanged += (s, e) =>
            {
                TuDongDoKetQuaHienCo();
                NapLaiPhamChatNangLucChoHocSinhDangChon();
                LamMoiBangLichSu();
            };
            cboHocKyPhamChat.SelectedIndexChanged += (s, e) => NapLaiPhamChatNangLucChoHocSinhDangChon();
            chkXemTatCaLichSu.CheckedChanged += (s, e) => LamMoiBangLichSu();
            dgvDiem.SelectionChanged += dgvDiem_SelectionChanged;

            btnLuuDiem.Click += btnLuuDiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnInBangDiem.Click += btnInBangDiem_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnNhapExcel.Click += btnNhapExcel_Click;
            btnInHocBaPdf.Click += btnInHocBaPdf_Click;
            btnBangTongHopLop.Click += btnBangTongHopLop_Click;
            btnLuuPhamChat.Click += btnLuuPhamChat_Click;

            ApDungGiaoDien();

            LoadDuLieuBanDau();
        }

        // Áp theme xanh lá nhẹ nhàng: banner tiêu đề dạng gradient, các khối nội dung
        // được nhóm vào từng "thẻ" (card) bo góc riêng biệt, nút bo góc, bảng điểm kẻ sọc xen kẽ
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);
            pnlNoiDung.BackColor = GiaoDien.MauNen;

            // Banner tiêu đề (gradient xanh lá -> xanh đậm), chữ trắng đã set sẵn trong Designer
            GiaoDien.VeNenGradient(pnlHeader, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam, 120f);
            GiaoDien.LamDepNhanBadge(lblLopPhuTrach, Color.White, GiaoDien.MauXanhDam);

            // Các thẻ (card) nội dung
            foreach (Panel the in new[] { pnlBoLoc, pnlNhapDiem, pnlHanhDong, pnlBangCard, pnlPhamChat })
            {
                GiaoDien.LamDepThe(the, 16);
            }

            // Tiêu đề nhỏ của từng thẻ
            foreach (Label tieuDeThe in new[]
            {
                lblTieuDeBoLoc, lblTieuDeNhapDiem, lblTieuDeHanhDong, lblTieuDeBang, lblPhamChatNangLuc
            })
            {
                tieuDeThe.ForeColor = GiaoDien.MauXanhDam;
            }

            foreach (Label nhan in new[]
            {
                lblChonHocSinh, lblChonMon, lblNamHoc, lblThoiDiem, lblHocKy,
                lblDiemKtdk, lblKetQuaMonHoc, lblNhanXet, lblPhamChat, lblNangLuc,
                lblNhanXetPhamChat, lblHocKyPhamChat
            })
            {
                GiaoDien.LamDepNhanPhu(nhan);
            }

            foreach (TextBox o in new[] { txtHocKy, txtDiemKtdk, txtNhanXet, txtNhanXetPhamChat })
            {
                GiaoDien.LamDepTextBox(o);
            }

            foreach (ComboBox c in new[]
            {
                cboHocSinh, cboMonHoc, cboNamHoc, cboThoiDiemDanhGia,
                cboKetQuaMonHoc, cboPhamChat, cboNangLuc, cboHocKyPhamChat
            })
            {
                GiaoDien.LamDepCombo(c);
            }

            GiaoDien.LamDepNut(btnLuuDiem, GiaoDien.KieuNut.Chinh, 10);
            GiaoDien.LamDepNut(btnLamMoi, GiaoDien.KieuNut.Phu, 10);
            GiaoDien.LamDepNut(btnInBangDiem, GiaoDien.KieuNut.Phu, 10);
            GiaoDien.LamDepNut(btnXuatExcel, GiaoDien.KieuNut.XanhDuong, 10);
            GiaoDien.LamDepNut(btnNhapExcel, GiaoDien.KieuNut.XanhDuong, 10);
            GiaoDien.LamDepNut(btnInHocBaPdf, GiaoDien.KieuNut.Cam, 10);
            GiaoDien.LamDepNut(btnBangTongHopLop, GiaoDien.KieuNut.Tim, 10);
            GiaoDien.LamDepNut(btnLuuPhamChat, GiaoDien.KieuNut.Chinh, 10);

            chkXemTatCaLichSu.ForeColor = GiaoDien.MauChuPhu;
            chkXemTatCaLichSu.Font = GiaoDien.FontChu;

            GiaoDien.LamDepBang(dgvDiem);
        }

        private void LoadDuLieuBanDau()
        {
            TaiKhoan? taiKhoan = SessionManager.TaiKhoanDangNhap;

            if (taiKhoan == null || string.IsNullOrWhiteSpace(taiKhoan.MaLopPhuTrach))
            {
                MessageBox.Show(
                    "Tài khoản chưa được gán lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            _maLopPhuTrach = taiKhoan.MaLopPhuTrach;

            LopHoc? lop = _lopHocService.LayTatCa().FirstOrDefault(l => l.MaLop == _maLopPhuTrach);
            _tenLopPhuTrach = lop?.TenLop ?? _maLopPhuTrach;
            lblLopPhuTrach.Text = $"LỚP PHỤ TRÁCH: {_tenLopPhuTrach}";

            List<MonHoc> danhSachMon = _monHocService.LayTatCa();
            cboMonHoc.DataSource = danhSachMon;
            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";

            List<HocSinh> danhSachHocSinh = _hocSinhService.LayDanhSachTheoLop(_maLopPhuTrach);

            List<HocSinhLua> danhSachLua = danhSachHocSinh
                .Select(h => new HocSinhLua
                {
                    MaHocSinh = h.MaHocSinh,
                    MaLop = h.MaLop,
                    HienThi = $"{h.MaHocSinh} - {h.HoTen}"
                })
                .ToList();

            cboHocSinh.DataSource = danhSachLua;
            cboHocSinh.DisplayMember = "HienThi";
            cboHocSinh.ValueMember = "MaHocSinh";
        }

        private HocSinhLua? HocSinhDangChon()
        {
            return cboHocSinh.SelectedItem as HocSinhLua;
        }

        private void cboHocSinh_SelectedIndexChanged(object? sender, EventArgs e)
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh == null)
            {
                return;
            }

            // Cập nhật danh sách mốc đánh giá phù hợp với khối lớp của học sinh này
            string[] cacMoc = MocDanhGia.LayMocTheoMaLop(hocSinh.MaLop);

            cboThoiDiemDanhGia.DataSource = null;
            cboThoiDiemDanhGia.DataSource = cacMoc.ToList();

            LoadLichSuDanhGia(hocSinh.MaHocSinh);
            LoadPhamChatNangLuc(hocSinh.MaHocSinh);
        }

        private void cboThoiDiemDanhGia_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboThoiDiemDanhGia.SelectedItem is string thoiDiem)
            {
                txtHocKy.Text = MocDanhGia.LayHocKyTuMoc(thoiDiem);
            }
            else
            {
                txtHocKy.Text = string.Empty;
            }

            TuDongDoKetQuaHienCo();
        }

        // Nếu bản ghi (học sinh - môn - năm học - mốc) đã tồn tại thì tự động hiển thị lại để giáo viên sửa
        private void TuDongDoKetQuaHienCo()
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh == null
                || cboMonHoc.SelectedValue == null
                || cboNamHoc.SelectedItem == null
                || cboThoiDiemDanhGia.SelectedItem == null)
            {
                return;
            }

            string maMon = cboMonHoc.SelectedValue.ToString()!;
            string namHoc = cboNamHoc.SelectedItem.ToString()!;
            string thoiDiem = cboThoiDiemDanhGia.SelectedItem.ToString()!;
            string hocKy = MocDanhGia.LayHocKyTuMoc(thoiDiem);

            Diem? banGhi = _diemService.LayMotBanGhi(hocSinh.MaHocSinh, maMon, namHoc, hocKy, thoiDiem);

            if (banGhi == null)
            {
                txtDiemKtdk.Clear();
                cboKetQuaMonHoc.SelectedIndex = -1;
                txtNhanXet.Clear();
                return;
            }

            txtDiemKtdk.Text = banGhi.DiemKiemTraDinhKy?.ToString("0.0") ?? string.Empty;
            cboKetQuaMonHoc.SelectedItem = banGhi.KetQuaMonHoc;
            txtNhanXet.Text = banGhi.NhanXet ?? string.Empty;
        }

        // Nạp lại bảng lịch sử cho học sinh đang chọn (dùng khi đổi năm học/mốc đánh giá/bật-tắt lọc)
        private void LamMoiBangLichSu()
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh != null)
            {
                LoadLichSuDanhGia(hocSinh.MaHocSinh);
            }
        }

        private void LoadLichSuDanhGia(string maHocSinh)
        {
            List<Diem> danhSachDiem = _diemService.LayTheoHocSinh(maHocSinh);
            List<MonHoc> danhSachMon = _monHocService.LayTatCa();

            // Mặc định chỉ hiển thị điểm các môn của đúng năm học + học kỳ đang chọn,
            // để giáo viên xem nhanh "điểm các môn" thay vì phải lướt qua toàn bộ lịch sử.
            // Bỏ tick "Xem toàn bộ lịch sử" nếu muốn xem lại tất cả các năm học/học kỳ đã nhập.
            if (!chkXemTatCaLichSu.Checked)
            {
                string? namHocDangChon = cboNamHoc.SelectedItem?.ToString();
                string? hocKyDangChon = string.IsNullOrWhiteSpace(txtHocKy.Text) ? null : txtHocKy.Text;

                if (!string.IsNullOrWhiteSpace(namHocDangChon))
                {
                    danhSachDiem = danhSachDiem.Where(d => d.NamHoc == namHocDangChon).ToList();
                }

                if (!string.IsNullOrWhiteSpace(hocKyDangChon))
                {
                    danhSachDiem = danhSachDiem.Where(d => d.HocKy == hocKyDangChon).ToList();
                }
            }

            List<DongLichSu> danhSachDong = danhSachDiem
                .OrderBy(d => danhSachMon.FirstOrDefault(m => m.MaMon == d.MaMon)?.TenMon ?? d.MaMon)
                .Select(d => new DongLichSu
                {
                    MonHoc = danhSachMon.FirstOrDefault(m => m.MaMon == d.MaMon)?.TenMon ?? d.MaMon,
                    NamHoc = d.NamHoc,
                    HocKy = d.HocKy,
                    ThoiDiemDanhGia = d.ThoiDiemDanhGia,
                    DiemKiemTraDinhKy = d.DiemKiemTraDinhKy?.ToString("0.0") ?? "-",
                    KetQuaMonHoc = d.KetQuaMonHoc,
                    NhanXet = d.NhanXet ?? string.Empty
                })
                .ToList();

            dgvDiem.AutoGenerateColumns = true;
            dgvDiem.DataSource = null;
            dgvDiem.DataSource = danhSachDong;

            void Doi(string ten, string tieuDe)
            {
                if (dgvDiem.Columns.Contains(ten))
                {
                    dgvDiem.Columns[ten]!.HeaderText = tieuDe;
                }
            }

            Doi("MonHoc", "Môn học");
            Doi("NamHoc", "Năm học");
            Doi("HocKy", "Học kỳ");
            Doi("ThoiDiemDanhGia", "Thời điểm đánh giá");
            Doi("DiemKiemTraDinhKy", "Điểm KTĐK");
            Doi("KetQuaMonHoc", "Kết quả môn học");
            Doi("NhanXet", "Nhận xét");
        }

        // Bấm 1 dòng trong bảng lịch sử -> nạp lại lên các ô nhập để sửa
        private void dgvDiem_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvDiem.CurrentRow?.DataBoundItem is not DongLichSu dong)
            {
                return;
            }

            MonHoc? mon = _monHocService.LayTatCa().FirstOrDefault(m => m.TenMon == dong.MonHoc);

            if (mon != null)
            {
                cboMonHoc.SelectedValue = mon.MaMon;
            }

            if (cboNamHoc.Items.Contains(dong.NamHoc))
            {
                cboNamHoc.SelectedItem = dong.NamHoc;
            }
            else
            {
                cboNamHoc.Text = dong.NamHoc;
            }

            if (((List<string>)cboThoiDiemDanhGia.DataSource!).Contains(dong.ThoiDiemDanhGia))
            {
                cboThoiDiemDanhGia.SelectedItem = dong.ThoiDiemDanhGia;
            }
        }

        private void btnLuuDiem_Click(object? sender, EventArgs e)
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cboMonHoc.SelectedValue == null || cboThoiDiemDanhGia.SelectedItem == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn đầy đủ môn học và thời điểm đánh giá.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string maMon = cboMonHoc.SelectedValue.ToString()!;
            string namHoc = cboNamHoc.Text.Trim();
            string thoiDiem = cboThoiDiemDanhGia.SelectedItem.ToString()!;
            string hocKy = txtHocKy.Text;

            double? diemKtdk = null;

            if (!string.IsNullOrWhiteSpace(txtDiemKtdk.Text))
            {
                if (!double.TryParse(txtDiemKtdk.Text, out double giaTri))
                {
                    MessageBox.Show(
                        "Điểm kiểm tra định kỳ không hợp lệ.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                diemKtdk = giaTri;
            }

            string ketQuaMonHoc = cboKetQuaMonHoc.SelectedItem?.ToString() ?? string.Empty;

            (bool thanhCong, string thongBao, _) = _diemService.LuuDiem(
                hocSinh.MaHocSinh, maMon, namHoc, hocKy, thoiDiem,
                diemKtdk, ketQuaMonHoc, txtNhanXet.Text
            );

            MessageBox.Show(
                thongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (thanhCong)
            {
                LoadLichSuDanhGia(hocSinh.MaHocSinh);
            }
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtDiemKtdk.Clear();
            cboKetQuaMonHoc.SelectedIndex = -1;
            txtNhanXet.Clear();
        }

        // Nạp lại phẩm chất & năng lực khi đổi năm học hoặc học kỳ, cho học sinh đang được chọn
        private void NapLaiPhamChatNangLucChoHocSinhDangChon()
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh != null)
            {
                LoadPhamChatNangLuc(hocSinh.MaHocSinh);
            }
        }

        private void LoadPhamChatNangLuc(string maHocSinh)
        {
            string namHoc = cboNamHoc.Text;
            string hocKy = cboHocKyPhamChat.SelectedItem?.ToString() ?? "Học kỳ I";

            DanhGiaPhamChatNangLuc? banGhi = _phamChatService.LayMotBanGhi(maHocSinh, namHoc, hocKy);

            if (banGhi == null)
            {
                cboPhamChat.SelectedIndex = -1;
                cboNangLuc.SelectedIndex = -1;
                txtNhanXetPhamChat.Clear();
                return;
            }

            cboPhamChat.SelectedItem = banGhi.PhamChat;
            cboNangLuc.SelectedItem = banGhi.NangLuc;
            txtNhanXetPhamChat.Text = banGhi.NhanXet ?? string.Empty;
        }

        private void btnLuuPhamChat_Click(object? sender, EventArgs e)
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string namHoc = cboNamHoc.Text.Trim();
            string hocKy = cboHocKyPhamChat.SelectedItem?.ToString() ?? "Học kỳ I";
            string phamChat = cboPhamChat.SelectedItem?.ToString() ?? string.Empty;
            string nangLuc = cboNangLuc.SelectedItem?.ToString() ?? string.Empty;

            (bool thanhCong, string thongBao) = _phamChatService.Luu(
                hocSinh.MaHocSinh, namHoc, hocKy, phamChat, nangLuc, txtNhanXetPhamChat.Text
            );

            MessageBox.Show(
                thongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );
        }

        // ================================
        // IN BẢNG ĐIỂM CỦA HỌC SINH ĐANG CHỌN (TOÀN BỘ MÔN + MỐC ĐÃ CÓ DỮ LIỆU)
        // ================================
        private void btnInBangDiem_Click(object? sender, EventArgs e)
        {
            HocSinhLua? hocSinh = HocSinhDangChon();

            if (hocSinh == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh để in bảng điểm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<Diem> danhSachDiem = _diemService.LayTheoHocSinh(hocSinh.MaHocSinh);
            List<MonHoc> danhSachMon = _monHocService.LayTatCa();

            _duLieuIn = danhSachDiem
                .Select(d => new DongInBangDiem
                {
                    TenMon = danhSachMon.FirstOrDefault(m => m.MaMon == d.MaMon)?.TenMon ?? d.MaMon,
                    ThoiDiemDanhGia = $"{d.NamHoc} - {d.ThoiDiemDanhGia}",
                    DiemKiemTraDinhKy = d.DiemKiemTraDinhKy?.ToString("0.0") ?? "-",
                    KetQuaMonHoc = d.KetQuaMonHoc
                })
                .ToList();

            if (_duLieuIn.Count == 0)
            {
                MessageBox.Show(
                    "Học sinh này chưa có kết quả đánh giá để in.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            HocSinh? hocSinhDayDu = _hocSinhService.LayTheoMa(hocSinh.MaHocSinh);
            _maHocSinhIn = hocSinh.MaHocSinh;
            _tenHocSinhIn = hocSinhDayDu?.HoTen ?? hocSinh.HienThi;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_BangDiem_PrintPage;

            using PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 900,
                Height = 700
            };

            printPreview.ShowDialog();
        }

        private void PrintDocument_BangDiem_PrintPage(object? sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            Font fontTieuDe = new Font("Arial", 14, FontStyle.Bold);
            Font fontThuong = new Font("Arial", 10);
            Font fontDamThuong = new Font("Arial", 10, FontStyle.Bold);

            int left = 50;
            int top = 40;

            g.DrawString("BẢNG ĐIỂM HỌC SINH", fontTieuDe, Brushes.Black, left, top);
            top += 35;

            g.DrawString(
                $"Họ tên: {_tenHocSinhIn}   -   Mã HS: {_maHocSinhIn}   -   Lớp: {_tenLopPhuTrach}",
                fontThuong, Brushes.Black, left, top
            );
            top += 35;

            int[] cot = { left, left + 150, left + 420, left + 570 };

            g.DrawString("Môn học", fontDamThuong, Brushes.Black, cot[0], top);
            g.DrawString("Thời điểm đánh giá", fontDamThuong, Brushes.Black, cot[1], top);
            g.DrawString("Điểm KTĐK", fontDamThuong, Brushes.Black, cot[2], top);
            g.DrawString("Kết quả môn học", fontDamThuong, Brushes.Black, cot[3], top);
            top += 18;

            g.DrawLine(Pens.Black, left, top, left + 700, top);
            top += 8;

            foreach (DongInBangDiem dong in _duLieuIn)
            {
                g.DrawString(dong.TenMon, fontThuong, Brushes.Black, cot[0], top);
                g.DrawString(dong.ThoiDiemDanhGia, fontThuong, Brushes.Black, cot[1], top);
                g.DrawString(dong.DiemKiemTraDinhKy, fontThuong, Brushes.Black, cot[2], top);
                g.DrawString(dong.KetQuaMonHoc, fontThuong, Brushes.Black, cot[3], top);
                top += 25;
            }

            top += 20;
            g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy}", fontThuong, Brushes.Black, left, top);
        }

        // ================================
        // XUẤT EXCEL BẢNG ĐIỂM CỦA TOÀN BỘ HỌC SINH TRONG LỚP PHỤ TRÁCH
        // ================================
        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maLopPhuTrach))
            {
                MessageBox.Show(
                    "Không xác định được lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<HocSinh> danhSachHocSinh = _hocSinhService
                .LayDanhSachTheoLop(_maLopPhuTrach)
                .OrderBy(h => h.HoTen)
                .ToList();

            if (danhSachHocSinh.Count == 0)
            {
                MessageBox.Show(
                    "Lớp chưa có học sinh nào.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<MonHoc> danhSachMon = _monHocService.LayTatCa();

            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"BangDiem_{_tenLopPhuTrach}_{DateTime.Now:ddMMyyyy}.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet sheet = workbook.Worksheets.Add("Bảng điểm");

            string[] tieuDe =
            {
                "Mã học sinh", "Họ tên", "Môn học", "Năm học", "Học kỳ",
                "Thời điểm đánh giá", "Điểm KTĐK", "Kết quả môn học", "Nhận xét"
            };

            for (int i = 0; i < tieuDe.Length; i++)
            {
                sheet.Cell(1, i + 1).Value = tieuDe[i];
            }

            IXLRange hangTieuDe = sheet.Range(1, 1, 1, tieuDe.Length);
            hangTieuDe.Style.Font.Bold = true;
            hangTieuDe.Style.Fill.BackgroundColor = XLColor.LightGray;

            int dong = 2;

            foreach (HocSinh hocSinh in danhSachHocSinh)
            {
                List<Diem> danhSachDiem = _diemService
                    .LayTheoHocSinh(hocSinh.MaHocSinh)
                    .OrderBy(d => d.NamHoc)
                    .ThenBy(d => d.HocKy)
                    .ThenBy(d => d.MaMon)
                    .ToList();

                if (danhSachDiem.Count == 0)
                {
                    sheet.Cell(dong, 1).Value = hocSinh.MaHocSinh;
                    sheet.Cell(dong, 2).Value = hocSinh.HoTen;
                    sheet.Cell(dong, 3).Value = "(Chưa có điểm)";
                    dong++;
                    continue;
                }

                foreach (Diem d in danhSachDiem)
                {
                    string tenMon = danhSachMon.FirstOrDefault(m => m.MaMon == d.MaMon)?.TenMon ?? d.MaMon;

                    sheet.Cell(dong, 1).Value = hocSinh.MaHocSinh;
                    sheet.Cell(dong, 2).Value = hocSinh.HoTen;
                    sheet.Cell(dong, 3).Value = tenMon;
                    sheet.Cell(dong, 4).Value = d.NamHoc;
                    sheet.Cell(dong, 5).Value = d.HocKy;
                    sheet.Cell(dong, 6).Value = d.ThoiDiemDanhGia;
                    sheet.Cell(dong, 7).Value = d.DiemKiemTraDinhKy?.ToString("0.0") ?? "-";
                    sheet.Cell(dong, 8).Value = d.KetQuaMonHoc;
                    sheet.Cell(dong, 9).Value = d.NhanXet ?? string.Empty;
                    dong++;
                }
            }

            sheet.Columns().AdjustToContents();
            sheet.SheetView.FreezeRows(1);

            try
            {
                workbook.SaveAs(saveDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể lưu file Excel: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Đã xuất file Excel thành công. Bạn có muốn mở file ngay không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (ketQua == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = saveDialog.FileName,
                    UseShellExecute = true
                });
            }
        }

        // ================================
        // NHẬP ĐIỂM HÀNG LOẠT TỪ FILE EXCEL
        // (đọc đúng định dạng cột mà "Xuất Excel cả lớp" đã tạo ra, để chỉnh sửa hàng loạt rồi nhập lại)
        // ================================
        private void btnNhapExcel_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maLopPhuTrach))
            {
                MessageBox.Show(
                    "Không xác định được lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx"
            };

            if (openDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            HashSet<string> maHocSinhHopLe = _hocSinhService
                .LayDanhSachTheoLop(_maLopPhuTrach)
                .Select(h => h.MaHocSinh)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            Dictionary<string, string> tenMonSangMaMon = _monHocService
                .LayTatCa()
                .GroupBy(m => m.TenMon.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().MaMon, StringComparer.OrdinalIgnoreCase);

            int soDongThanhCong = 0;
            List<string> danhSachLoi = new List<string>();

            try
            {
                using XLWorkbook workbook = new XLWorkbook(openDialog.FileName);
                IXLWorksheet sheet = workbook.Worksheet(1);

                int dongCuoi = sheet.LastRowUsed()?.RowNumber() ?? 1;

                for (int dong = 2; dong <= dongCuoi; dong++)
                {
                    string maHocSinh = sheet.Cell(dong, 1).GetString().Trim();

                    if (string.IsNullOrWhiteSpace(maHocSinh))
                    {
                        continue;
                    }

                    string tenMon = sheet.Cell(dong, 3).GetString().Trim();

                    if (string.IsNullOrWhiteSpace(tenMon) || tenMon == "(Chưa có điểm)")
                    {
                        continue;
                    }

                    if (!maHocSinhHopLe.Contains(maHocSinh))
                    {
                        danhSachLoi.Add($"Dòng {dong}: mã học sinh \"{maHocSinh}\" không thuộc lớp phụ trách.");
                        continue;
                    }

                    if (!tenMonSangMaMon.TryGetValue(tenMon, out string? maMon))
                    {
                        danhSachLoi.Add($"Dòng {dong}: không tìm thấy môn học \"{tenMon}\".");
                        continue;
                    }

                    string namHoc = sheet.Cell(dong, 4).GetString().Trim();
                    string hocKy = sheet.Cell(dong, 5).GetString().Trim();
                    string thoiDiemDanhGia = sheet.Cell(dong, 6).GetString().Trim();
                    string diemChuoi = sheet.Cell(dong, 7).GetString().Trim();
                    string ketQuaMonHoc = sheet.Cell(dong, 8).GetString().Trim();
                    string nhanXet = sheet.Cell(dong, 9).GetString().Trim();

                    double? diem = null;

                    if (!string.IsNullOrWhiteSpace(diemChuoi) && diemChuoi != "-" &&
                        double.TryParse(diemChuoi, NumberStyles.Any, CultureInfo.InvariantCulture, out double giaTri))
                    {
                        diem = giaTri;
                    }

                    (bool thanhCong, string thongBao, _) = _diemService.LuuDiem(
                        maHocSinh, maMon, namHoc, hocKy, thoiDiemDanhGia, diem, ketQuaMonHoc, nhanXet
                    );

                    if (thanhCong)
                    {
                        soDongThanhCong++;
                    }
                    else
                    {
                        danhSachLoi.Add($"Dòng {dong} ({maHocSinh}): {thongBao}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể đọc file Excel: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            string thongBaoKetQua = $"Đã nhập thành công {soDongThanhCong} dòng.";

            if (danhSachLoi.Count > 0)
            {
                int soLoiHienThi = Math.Min(danhSachLoi.Count, 10);

                thongBaoKetQua += $"\n\nCó {danhSachLoi.Count} dòng bị bỏ qua do lỗi:\n"
                    + string.Join("\n", danhSachLoi.Take(soLoiHienThi));

                if (danhSachLoi.Count > soLoiHienThi)
                {
                    thongBaoKetQua += $"\n... và {danhSachLoi.Count - soLoiHienThi} lỗi khác.";
                }
            }

            MessageBox.Show(
                thongBaoKetQua,
                "Kết quả nhập Excel",
                MessageBoxButtons.OK,
                danhSachLoi.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information
            );

            // Làm mới lại bảng lịch sử đang hiển thị (nếu đang chọn 1 học sinh)
            if (cboHocSinh.SelectedItem is HocSinh hocSinhDangChon)
            {
                LoadLichSuDanhGia(hocSinhDangChon.MaHocSinh);
            }
        }

        // ================================
        // IN HỌC BẠ (PDF) CHO TOÀN BỘ HỌC SINH TRONG LỚP
        // ================================
        private void btnInHocBaPdf_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maLopPhuTrach))
            {
                MessageBox.Show(
                    "Không xác định được lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<HocSinh> danhSachHocSinh = _hocSinhService
                .LayDanhSachTheoLop(_maLopPhuTrach)
                .OrderBy(h => h.MaHocSinh)
                .ToList();

            if (danhSachHocSinh.Count == 0)
            {
                MessageBox.Show(
                    "Lớp chưa có học sinh nào.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<MonHoc> danhSachMon = _monHocService.LayTatCa();

            string LayTenMon(string maMon) =>
                danhSachMon.FirstOrDefault(m => m.MaMon == maMon)?.TenMon ?? maMon;

            using SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Document (*.pdf)|*.pdf",
                FileName = $"HocBa_{_tenLopPhuTrach}_{DateTime.Now:ddMMyyyy}.pdf"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<HocBaPdfExporter.HocSinhHocBa> duLieu = danhSachHocSinh
                .Select(hs => new HocBaPdfExporter.HocSinhHocBa
                {
                    HocSinh = hs,
                    DanhSachDiem = _diemService.LayTheoHocSinh(hs.MaHocSinh),
                    DanhSachDanhGia = _phamChatService.LayTheoHocSinh(hs.MaHocSinh)
                })
                .ToList();

            try
            {
                HocBaPdfExporter.XuatFile(saveDialog.FileName, _tenLopPhuTrach, duLieu, LayTenMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể tạo file PDF: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            DialogResult ketQuaMoFile = MessageBox.Show(
                "Đã xuất học bạ PDF thành công. Bạn có muốn mở file ngay không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (ketQuaMoFile == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = saveDialog.FileName,
                    UseShellExecute = true
                });
            }
        }
        // ================================
        // XEM BẢNG TỔNG HỢP ĐIỂM CẢ LỚP (mỗi hàng 1 học sinh, mỗi cột 1 môn)
        // ================================
        private void btnBangTongHopLop_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maLopPhuTrach))
            {
                MessageBox.Show(
                    "Không xác định được lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string? namHoc = cboNamHoc.SelectedItem?.ToString();
            string? thoiDiem = cboThoiDiemDanhGia.SelectedItem?.ToString();
            string hocKy = txtHocKy.Text;

            if (string.IsNullOrWhiteSpace(namHoc) || string.IsNullOrWhiteSpace(thoiDiem) || string.IsNullOrWhiteSpace(hocKy))
            {
                MessageBox.Show(
                    "Vui lòng chọn Năm học và Thời điểm đánh giá trước (ở phần nhập điểm phía trên) để xem bảng tổng hợp đúng mốc.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<HocSinh> danhSachHocSinh = _hocSinhService.LayDanhSachTheoLop(_maLopPhuTrach);
            List<MonHoc> danhSachMon = _monHocService.LayTatCa();

            if (danhSachHocSinh.Count == 0)
            {
                MessageBox.Show(
                    "Lớp chưa có học sinh nào.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using FrmBangTongHopLop frm = new FrmBangTongHopLop(
                _tenLopPhuTrach, namHoc, hocKy, thoiDiem, danhSachHocSinh, danhSachMon, _diemService
            );

            frm.ShowDialog();
        }
    }
}
