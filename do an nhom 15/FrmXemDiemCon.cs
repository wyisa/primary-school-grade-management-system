using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmXemDiemCon : Form
    {
        private readonly HocSinhService _hocSinhService;
        private readonly LopHocService _lopHocService;
        private readonly MonHocService _monHocService;
        private readonly DiemService _diemService;
        private readonly DanhGiaPhamChatService _phamChatService;

        private class DongDiem
        {
            public string MonHoc { get; set; } = string.Empty;
            public string NamHoc { get; set; } = string.Empty;
            public string HocKy { get; set; } = string.Empty;
            public string ThoiDiemDanhGia { get; set; } = string.Empty;
            public string DiemKiemTraDinhKy { get; set; } = string.Empty;
            public string KetQuaMonHoc { get; set; } = string.Empty;
            public string NhanXet { get; set; } = string.Empty;
        }

        // Mô tả 1 thẻ chỉ số (KPI card) hiển thị kết quả học tập tổng hợp
        private class MoTaTheChiSo
        {
            public string Ma { get; set; } = string.Empty;
            public string Icon { get; set; } = string.Empty;
            public string Nhan { get; set; } = string.Empty;
            public Color MauNen { get; set; }
            public Color MauChu { get; set; }
        }

        private readonly Dictionary<string, Label> _oGiaTriThe = new();

        public FrmXemDiemCon()
        {
            InitializeComponent();

            _hocSinhService = new HocSinhService();
            _lopHocService = new LopHocService();
            _monHocService = new MonHocService();
            _diemService = new DiemService();
            _phamChatService = new DanhGiaPhamChatService();

            txtHoTen.ReadOnly = true;
            txtMaHocSinh.ReadOnly = true;
            txtLop.ReadOnly = true;

            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            btnDangXuat.Click += btnDangXuat_Click;

            ApDungGiaoDien();
            TaoLuoiTheChiSo();

            LoadThongTinConVaDiem();
        }

        // Áp theme xanh lá nhẹ nhàng: banner tiêu đề dạng gradient, các khối nội dung
        // được nhóm vào từng "thẻ" (card) bo góc riêng biệt, đồng bộ với các form khác
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);

            GiaoDien.VeNenGradient(pnlHeader, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam, 120f);
            GiaoDien.LamDepNhanBadge(lblHocSinhBanner, Color.White, GiaoDien.MauXanhDam);
            GiaoDien.LamDepNut(btnDoiMatKhau, GiaoDien.KieuNut.TrongSuot);
            GiaoDien.LamDepNut(btnDangXuat, GiaoDien.KieuNut.NguyHiem);

            foreach (Panel the in new[] { pnlThongTin, pnlKetQua, pnlBangDiem, pnlPhamChat })
            {
                GiaoDien.LamDepThe(the, 16);
            }

            foreach (Label tieuDeThe in new[]
            {
                lblTieuDeThongTin, lblTieuDeKetQua, lblTieuDeBangDiem, lblTieuDePhamChat
            })
            {
                tieuDeThe.ForeColor = GiaoDien.MauXanhDam;
            }

            foreach (Label nhan in new[] { lblHoTen, lblMaHocSinh, lblLop, lblPhamChat, lblNangLuc })
            {
                GiaoDien.LamDepNhanPhu(nhan);
            }

            foreach (TextBox oNhap in new[] { txtHoTen, txtMaHocSinh, txtLop })
            {
                GiaoDien.LamDepTextBox(oNhap);
            }

            GiaoDien.LamDepBang(dgvDiem);

            GiaoDien.LamDepNhanBadge(txtPhamChat, GiaoDien.MauXamNhat, GiaoDien.MauChuChinh);
            GiaoDien.LamDepNhanBadge(txtNangLuc, GiaoDien.MauXamNhat, GiaoDien.MauChuChinh);
        }

        // Dựng 3 thẻ chỉ số (Hoàn thành tốt / Hoàn thành / Chưa hoàn thành) trong pnlKetQua
        private void TaoLuoiTheChiSo()
        {
            MoTaTheChiSo[] danhSachThe = new[]
            {
                new MoTaTheChiSo { Ma = "HoanThanhTot",  Icon = "🏆", Nhan = "Hoàn thành tốt", MauNen = GiaoDien.MauXanhNhat, MauChu = GiaoDien.MauXanhChinh },
                new MoTaTheChiSo { Ma = "HoanThanh",     Icon = "✅", Nhan = "Hoàn thành", MauNen = GiaoDien.MauXanhDuongNhat, MauChu = GiaoDien.MauXanhDuong },
                new MoTaTheChiSo { Ma = "ChuaHoanThanh", Icon = "⚠️", Nhan = "Chưa hoàn thành", MauNen = ColorTranslator.FromHtml("#FBEAE8"), MauChu = GiaoDien.MauDo },
            };

            const int soCot = 3;
            const int leTrai = 20;
            const int leTren = 52;
            const int khoangCach = 20;

            int rongThe = (pnlKetQua.ClientSize.Width - leTrai * 2 - khoangCach * (soCot - 1)) / soCot;
            int caoThe = 100;

            for (int i = 0; i < danhSachThe.Length; i++)
            {
                MoTaTheChiSo mota = danhSachThe[i];
                int x = leTrai + i * (rongThe + khoangCach);

                Panel the = new Panel
                {
                    Location = new Point(x, leTren),
                    Size = new Size(rongThe, caoThe),
                    BackColor = mota.MauNen
                };
                GiaoDien.BoGocTron(the, 14);

                Label lblIcon = new Label
                {
                    Text = mota.Icon,
                    Font = new Font("Segoe UI Emoji", 16F),
                    ForeColor = mota.MauChu,
                    Location = new Point(16, 12),
                    Size = new Size(40, 30),
                    AutoSize = false
                };

                Label lblNhan = new Label
                {
                    Text = mota.Nhan,
                    Font = GiaoDien.FontChu,
                    ForeColor = GiaoDien.MauChuPhu,
                    Location = new Point(16, 42),
                    Size = new Size(rongThe - 32, 20),
                    AutoSize = false
                };

                Label lblGiaTri = new Label
                {
                    Text = "0",
                    Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                    ForeColor = mota.MauChu,
                    Location = new Point(16, 60),
                    Size = new Size(rongThe - 32, 34),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                the.Controls.Add(lblIcon);
                the.Controls.Add(lblNhan);
                the.Controls.Add(lblGiaTri);

                pnlKetQua.Controls.Add(the);

                _oGiaTriThe[mota.Ma] = lblGiaTri;
            }
        }

        // Trả về (màu nền nhạt, màu chữ) phù hợp cho từng mức đánh giá phẩm chất/năng lực
        private static (Color nen, Color chu) MauTheoMucDo(string mucDo)
        {
            return mucDo switch
            {
                "Tốt" => (GiaoDien.MauXanhNhat, GiaoDien.MauXanhChinh),
                "Đạt" => (GiaoDien.MauXanhDuongNhat, GiaoDien.MauXanhDuong),
                "Cần cố gắng" => (GiaoDien.MauCamNhat, GiaoDien.MauCam),
                _ => (GiaoDien.MauXamNhat, GiaoDien.MauChuChinh)
            };
        }

        private void LoadThongTinConVaDiem()
        {
            TaiKhoan? taiKhoan = SessionManager.TaiKhoanDangNhap;

            if (taiKhoan == null || string.IsNullOrWhiteSpace(taiKhoan.MaHocSinh))
            {
                MessageBox.Show(
                    "Tài khoản chưa được gán học sinh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            HocSinh? hocSinh = _hocSinhService.LayTheoMa(taiKhoan.MaHocSinh);

            if (hocSinh == null)
            {
                MessageBox.Show(
                    "Không tìm thấy thông tin học sinh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            txtHoTen.Text = hocSinh.HoTen;
            txtMaHocSinh.Text = hocSinh.MaHocSinh;

            LopHoc? lop = _lopHocService.LayTatCa().FirstOrDefault(l => l.MaLop == hocSinh.MaLop);
            txtLop.Text = lop?.TenLop ?? hocSinh.MaLop;

            lblHocSinhBanner.Text = $"HỌC SINH: {hocSinh.HoTen} - {txtLop.Text}";

            List<MonHoc> danhSachMon = _monHocService.LayTatCa();
            List<Diem> danhSachDiem = _diemService.LayTheoHocSinh(hocSinh.MaHocSinh);

            // Hiển thị TOÀN BỘ các mốc đánh giá đã có (không gộp thành 1 điểm trung bình tự tạo)
            List<DongDiem> danhSachDong = danhSachDiem
                .Select(d => new DongDiem
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

            // Kết quả học tập chung: hiển thị số môn đã Hoàn thành tốt / Hoàn thành / Chưa hoàn thành
            // (KHÔNG gộp thành 1 điểm trung bình tự tạo vì nghiệp vụ mới không dùng công thức đó)
            int soHoanThanhTot = danhSachDiem.Count(d => d.KetQuaMonHoc == "Hoàn thành tốt");
            int soHoanThanh = danhSachDiem.Count(d => d.KetQuaMonHoc == "Hoàn thành");
            int soChuaHoanThanh = danhSachDiem.Count(d => d.KetQuaMonHoc == "Chưa hoàn thành");

            _oGiaTriThe["HoanThanhTot"].Text = soHoanThanhTot.ToString();
            _oGiaTriThe["HoanThanh"].Text = soHoanThanh.ToString();
            _oGiaTriThe["ChuaHoanThanh"].Text = soChuaHoanThanh.ToString();

            // Đánh giá phẩm chất & năng lực - lấy bản ghi gần nhất (nếu có nhiều học kỳ)
            List<DanhGiaPhamChatNangLuc> danhSachPhamChat = _phamChatService.LayTheoHocSinh(hocSinh.MaHocSinh);
            DanhGiaPhamChatNangLuc? banGhiGanNhat = danhSachPhamChat.LastOrDefault();

            string phamChat = banGhiGanNhat?.PhamChat ?? "Chưa có đánh giá";
            string nangLuc = banGhiGanNhat?.NangLuc ?? "Chưa có đánh giá";

            txtPhamChat.Text = phamChat;
            txtNangLuc.Text = nangLuc;

            (Color nenPhamChat, Color chuPhamChat) = MauTheoMucDo(phamChat);
            (Color nenNangLuc, Color chuNangLuc) = MauTheoMucDo(nangLuc);

            GiaoDien.LamDepNhanBadge(txtPhamChat, nenPhamChat, chuPhamChat);
            GiaoDien.LamDepNhanBadge(txtNangLuc, nenNangLuc, chuNangLuc);
        }

        private void btnDoiMatKhau_Click(object? sender, EventArgs e)
        {
            using FrmChangePassword frm = new FrmChangePassword();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            SessionManager.DangXuat();

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();

            this.Hide();
        }
    }
}
