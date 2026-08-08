using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;
using System.Drawing.Printing;

namespace do_an_nhom_15
{
    public partial class FrmThongKe : Form
    {
        private readonly HocSinhService _hocSinhService;
        private readonly MonHocService _monHocService;
        private readonly DiemService _diemService;
        private readonly LopHocService _lopHocService;

        private string _maLopPhuTrach = string.Empty;
        private string _tenLopPhuTrach = string.Empty;

        private const string MA_MON_TAT_CA = "__TATCA__";
        private const string MOC_TAT_CA = "Tất cả các mốc";

        private class MonHocLua
        {
            public string MaMon { get; set; } = string.Empty;
            public string TenMon { get; set; } = string.Empty;
        }

        private class KetQuaThongKe
        {
            public int TongSoHocSinh { get; set; }
            public int SoLuotDaCoDiem { get; set; }
            public double? DiemTrungBinh { get; set; }
            public double? DiemCaoNhat { get; set; }
            public double? DiemThapNhat { get; set; }
            public int SoHoanThanhTot { get; set; }
            public int SoHoanThanh { get; set; }
            public int SoChuaHoanThanh { get; set; }
            public string TenMonDaChon { get; set; } = string.Empty;
            public string ThoiDiemDaChon { get; set; } = string.Empty;
            public string NamHocDaChon { get; set; } = string.Empty;
        }

        // Mô tả 1 thẻ chỉ số (KPI card) trên lưới kết quả: mã định danh, icon, nhãn phụ, màu nền/màu chữ
        private class MoTaTheChiSo
        {
            public string Ma { get; set; } = string.Empty;
            public string Icon { get; set; } = string.Empty;
            public string Nhan { get; set; } = string.Empty;
            public Color MauNen { get; set; }
            public Color MauChu { get; set; }
        }

        private KetQuaThongKe? _ketQuaHienTai;

        // Lưu tham chiếu label giá trị + label phụ (phần trăm) của từng thẻ để cập nhật khi có kết quả mới
        private readonly Dictionary<string, Label> _oGiaTriThe = new();
        private readonly Dictionary<string, Label> _oPhuThe = new();

        public FrmThongKe()
        {
            InitializeComponent();

            _hocSinhService = new HocSinhService();
            _monHocService = new MonHocService();
            _diemService = new DiemService();
            _lopHocService = new LopHocService();

            cboNamHoc.Items.AddRange(MocDanhGia.DanhSachNamHocGoiY);
            cboNamHoc.SelectedIndex = 0;

            btnThongKe.Click += btnThongKe_Click;
            btnInBaoCao.Click += btnInBaoCao_Click;

            ApDungGiaoDien();
            TaoLuoiTheChiSo();

            LoadDuLieuBanDau();
        }

        // Áp theme xanh lá nhẹ nhàng: banner tiêu đề dạng gradient, các khối nội dung
        // được nhóm vào từng "thẻ" (card) bo góc riêng biệt, nút bo góc
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);

            // Banner tiêu đề (gradient xanh lá -> xanh đậm)
            GiaoDien.VeNenGradient(pnlHeader, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam, 120f);
            GiaoDien.LamDepNhanBadge(lblLopPhuTrach, Color.White, GiaoDien.MauXanhDam);

            GiaoDien.LamDepThe(pnlBoLoc, 16);
            GiaoDien.LamDepThe(pnlKetQua, 16);

            lblTieuDeBoLoc.ForeColor = GiaoDien.MauXanhDam;
            lblTieuDeKetQua.ForeColor = GiaoDien.MauXanhDam;

            foreach (Label nhan in new[] { lblNamHoc, lblChonMon, lblChonMoc })
            {
                GiaoDien.LamDepNhanPhu(nhan);
            }

            foreach (ComboBox c in new[] { cboNamHoc, cboMonHoc, cboThoiDiemDanhGia })
            {
                GiaoDien.LamDepCombo(c);
            }

            GiaoDien.LamDepNut(btnThongKe, GiaoDien.KieuNut.Chinh);
            GiaoDien.LamDepNut(btnInBaoCao, GiaoDien.KieuNut.Phu);
        }

        // Dựng lưới 8 thẻ chỉ số (4 cột x 2 hàng) bên trong pnlKetQua: mỗi thẻ có icon, nhãn,
        // 1 label giá trị lớn (được style theo màu riêng) và 1 label phụ (dùng cho tỉ lệ %)
        private void TaoLuoiTheChiSo()
        {
            Color mauNenDo = ColorTranslator.FromHtml("#FBEAE8");

            MoTaTheChiSo[] danhSachThe = new[]
            {
                new MoTaTheChiSo { Ma = "TongSoHocSinh", Icon = "👥", Nhan = "Tổng số học sinh", MauNen = GiaoDien.MauXanhDuongNhat, MauChu = GiaoDien.MauXanhDuong },
                new MoTaTheChiSo { Ma = "SoLuotDiem",     Icon = "📝", Nhan = "Số lượt có điểm KTĐK", MauNen = GiaoDien.MauTimNhat, MauChu = GiaoDien.MauTim },
                new MoTaTheChiSo { Ma = "DiemTB",         Icon = "📈", Nhan = "Điểm trung bình", MauNen = GiaoDien.MauXanhNhat, MauChu = GiaoDien.MauXanhChinh },
                new MoTaTheChiSo { Ma = "DiemCao",        Icon = "🔼", Nhan = "Điểm cao nhất", MauNen = GiaoDien.MauCamNhat, MauChu = GiaoDien.MauCam },
                new MoTaTheChiSo { Ma = "DiemThap",       Icon = "🔽", Nhan = "Điểm thấp nhất", MauNen = GiaoDien.MauHongNhat, MauChu = GiaoDien.MauHong },
                new MoTaTheChiSo { Ma = "HoanThanhTot",   Icon = "🏆", Nhan = "Hoàn thành tốt", MauNen = GiaoDien.MauXanhNhat, MauChu = GiaoDien.MauXanhChinh },
                new MoTaTheChiSo { Ma = "HoanThanh",      Icon = "✅", Nhan = "Hoàn thành", MauNen = GiaoDien.MauXanhDuongNhat, MauChu = GiaoDien.MauXanhDuong },
                new MoTaTheChiSo { Ma = "ChuaHoanThanh",  Icon = "⚠️", Nhan = "Chưa hoàn thành", MauNen = mauNenDo, MauChu = GiaoDien.MauDo },
            };

            const int soCot = 4;
            const int leTrai = 20;
            const int leTren = 56;
            const int khoangCach = 16;

            int rongThe = (pnlKetQua.ClientSize.Width - leTrai * 2 - khoangCach * (soCot - 1)) / soCot;
            int caoThe = 160;

            for (int i = 0; i < danhSachThe.Length; i++)
            {
                MoTaTheChiSo mota = danhSachThe[i];
                int cot = i % soCot;
                int hang = i / soCot;

                int x = leTrai + cot * (rongThe + khoangCach);
                int y = leTren + hang * (caoThe + khoangCach);

                Panel the = new Panel
                {
                    Location = new Point(x, y),
                    Size = new Size(rongThe, caoThe),
                    BackColor = mota.MauNen
                };
                GiaoDien.BoGocTron(the, 14);

                Label lblIcon = new Label
                {
                    Text = mota.Icon,
                    Font = new Font("Segoe UI Emoji", 18F),
                    ForeColor = mota.MauChu,
                    Location = new Point(16, 14),
                    Size = new Size(44, 40),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false
                };

                Label lblNhan = new Label
                {
                    Text = mota.Nhan,
                    Font = GiaoDien.FontChu,
                    ForeColor = GiaoDien.MauChuPhu,
                    Location = new Point(16, 60),
                    Size = new Size(rongThe - 32, 34),
                    AutoSize = false
                };

                Label lblGiaTri = new Label
                {
                    Text = "—",
                    Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                    ForeColor = mota.MauChu,
                    Location = new Point(16, 92),
                    Size = new Size(rongThe - 32, 38),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Label lblPhu = new Label
                {
                    Text = string.Empty,
                    Font = GiaoDien.FontChu,
                    ForeColor = GiaoDien.MauChuPhu,
                    Location = new Point(16, 130),
                    Size = new Size(rongThe - 32, 20),
                    AutoSize = false
                };

                the.Controls.Add(lblIcon);
                the.Controls.Add(lblNhan);
                the.Controls.Add(lblGiaTri);
                the.Controls.Add(lblPhu);

                pnlKetQua.Controls.Add(the);

                _oGiaTriThe[mota.Ma] = lblGiaTri;
                _oPhuThe[mota.Ma] = lblPhu;
            }
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

            List<MonHocLua> danhSachMon = new List<MonHocLua>
            {
                new MonHocLua { MaMon = MA_MON_TAT_CA, TenMon = "Tất cả" }
            };

            danhSachMon.AddRange(
                _monHocService.LayTatCa().Select(m => new MonHocLua { MaMon = m.MaMon, TenMon = m.TenMon })
            );

            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = danhSachMon;
            cboMonHoc.SelectedIndex = 0;

            // Mốc đánh giá lấy theo khối lớp đang phụ trách (mỗi giáo viên chỉ phụ trách 1 lớp)
            List<string> danhSachMoc = new List<string> { MOC_TAT_CA };
            danhSachMoc.AddRange(MocDanhGia.LayMocTheoMaLop(_maLopPhuTrach));

            cboThoiDiemDanhGia.DataSource = danhSachMoc;
            cboThoiDiemDanhGia.SelectedIndex = 0;
        }

        private KetQuaThongKe TinhThongKe(string maMonDaChon, string tenMonDaChon, string namHoc, string mocDaChon)
        {
            List<HocSinh> danhSachHocSinh = _hocSinhService.LayDanhSachTheoLop(_maLopPhuTrach);

            List<Diem> danhSachDiemXet = new List<Diem>();

            foreach (HocSinh hocSinh in danhSachHocSinh)
            {
                IEnumerable<Diem> diemCuaHocSinh = _diemService.LayTheoHocSinh(hocSinh.MaHocSinh)
                    .Where(d => d.NamHoc == namHoc);

                if (maMonDaChon != MA_MON_TAT_CA)
                {
                    diemCuaHocSinh = diemCuaHocSinh.Where(d => d.MaMon == maMonDaChon);
                }

                if (mocDaChon != MOC_TAT_CA)
                {
                    diemCuaHocSinh = diemCuaHocSinh.Where(d => d.ThoiDiemDanhGia == mocDaChon);
                }

                danhSachDiemXet.AddRange(diemCuaHocSinh);
            }

            List<double> diemDayDu = danhSachDiemXet
                .Where(d => d.DiemKiemTraDinhKy.HasValue)
                .Select(d => d.DiemKiemTraDinhKy!.Value)
                .ToList();

            KetQuaThongKe ketQua = new KetQuaThongKe
            {
                TongSoHocSinh = danhSachHocSinh.Count,
                SoLuotDaCoDiem = diemDayDu.Count,
                TenMonDaChon = tenMonDaChon,
                ThoiDiemDaChon = mocDaChon,
                NamHocDaChon = namHoc
            };

            if (diemDayDu.Count > 0)
            {
                ketQua.DiemTrungBinh = Math.Round(diemDayDu.Average(), 2);
                ketQua.DiemCaoNhat = diemDayDu.Max();
                ketQua.DiemThapNhat = diemDayDu.Min();
            }

            ketQua.SoHoanThanhTot = danhSachDiemXet.Count(d => d.KetQuaMonHoc == "Hoàn thành tốt");
            ketQua.SoHoanThanh = danhSachDiemXet.Count(d => d.KetQuaMonHoc == "Hoàn thành");
            ketQua.SoChuaHoanThanh = danhSachDiemXet.Count(d => d.KetQuaMonHoc == "Chưa hoàn thành");

            return ketQua;
        }

        private void btnThongKe_Click(object? sender, EventArgs e)
        {
            if (cboMonHoc.SelectedValue == null || cboThoiDiemDanhGia.SelectedItem == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn đầy đủ năm học, môn học và thời điểm đánh giá.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string maMonDaChon = cboMonHoc.SelectedValue.ToString()!;
            string tenMonDaChon = ((MonHocLua)cboMonHoc.SelectedItem!).TenMon;
            string namHoc = cboNamHoc.Text.Trim();
            string mocDaChon = cboThoiDiemDanhGia.SelectedItem.ToString()!;

            KetQuaThongKe ketQua = TinhThongKe(maMonDaChon, tenMonDaChon, namHoc, mocDaChon);
            _ketQuaHienTai = ketQua;

            HienThiKetQua(ketQua);
        }

        private static string PhanTram(int soLuong, int tongSo)
        {
            if (tongSo == 0)
            {
                return "0%";
            }

            return Math.Round(soLuong * 100.0 / tongSo, 1) + "%";
        }

        private void HienThiKetQua(KetQuaThongKe ketQua)
        {
            _oGiaTriThe["TongSoHocSinh"].Text = ketQua.TongSoHocSinh.ToString();
            _oGiaTriThe["SoLuotDiem"].Text = ketQua.SoLuotDaCoDiem.ToString();

            _oGiaTriThe["DiemTB"].Text = ketQua.DiemTrungBinh.HasValue
                ? ketQua.DiemTrungBinh.Value.ToString("0.0")
                : "—";

            _oGiaTriThe["DiemCao"].Text = ketQua.DiemCaoNhat.HasValue
                ? ketQua.DiemCaoNhat.Value.ToString("0.0")
                : "—";

            _oGiaTriThe["DiemThap"].Text = ketQua.DiemThapNhat.HasValue
                ? ketQua.DiemThapNhat.Value.ToString("0.0")
                : "—";

            if (!ketQua.DiemTrungBinh.HasValue)
            {
                _oPhuThe["DiemTB"].Text = "Chưa có dữ liệu";
            }
            else
            {
                _oPhuThe["DiemTB"].Text = string.Empty;
            }

            int tongSoLuotXepLoai = ketQua.SoHoanThanhTot + ketQua.SoHoanThanh + ketQua.SoChuaHoanThanh;

            _oGiaTriThe["HoanThanhTot"].Text = ketQua.SoHoanThanhTot.ToString();
            _oPhuThe["HoanThanhTot"].Text = PhanTram(ketQua.SoHoanThanhTot, tongSoLuotXepLoai) + " tổng số lượt";

            _oGiaTriThe["HoanThanh"].Text = ketQua.SoHoanThanh.ToString();
            _oPhuThe["HoanThanh"].Text = PhanTram(ketQua.SoHoanThanh, tongSoLuotXepLoai) + " tổng số lượt";

            _oGiaTriThe["ChuaHoanThanh"].Text = ketQua.SoChuaHoanThanh.ToString();
            _oPhuThe["ChuaHoanThanh"].Text = PhanTram(ketQua.SoChuaHoanThanh, tongSoLuotXepLoai) + " tổng số lượt";
        }

        // ================================
        // IN BÁO CÁO THỐNG KÊ
        // ================================
        private void btnInBaoCao_Click(object? sender, EventArgs e)
        {
            if (_ketQuaHienTai == null)
            {
                MessageBox.Show(
                    "Vui lòng bấm \"Thống kê\" trước khi in báo cáo.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_BaoCao_PrintPage;

            using PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 900,
                Height = 700
            };

            printPreview.ShowDialog();
        }

        private void PrintDocument_BaoCao_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (_ketQuaHienTai == null)
            {
                return;
            }

            KetQuaThongKe ketQua = _ketQuaHienTai;

            Graphics g = e.Graphics!;
            Font fontTieuDe = new Font("Arial", 13, FontStyle.Bold);
            Font fontThuong = new Font("Arial", 10);

            int left = 50;
            int top = 40;

            string tenMonIn = ketQua.TenMonDaChon == "Tất cả" ? "Tất cả các môn" : ketQua.TenMonDaChon;

            g.DrawString(
                $"BÁO CÁO THỐNG KÊ LỚP {_tenLopPhuTrach} - MÔN {tenMonIn} - NĂM HỌC {ketQua.NamHocDaChon}",
                fontTieuDe, Brushes.Black, left, top
            );
            top += 30;

            g.DrawString($"Thời điểm đánh giá: {ketQua.ThoiDiemDaChon}", fontThuong, Brushes.Black, left, top);
            top += 30;

            g.DrawString($"Tổng số học sinh: {ketQua.TongSoHocSinh}", fontThuong, Brushes.Black, left, top);
            top += 25;

            g.DrawString($"Số lượt đã có điểm KTĐK: {ketQua.SoLuotDaCoDiem}", fontThuong, Brushes.Black, left, top);
            top += 25;

            string diemTB = ketQua.DiemTrungBinh.HasValue ? ketQua.DiemTrungBinh.Value.ToString("0.0") : "Chưa có dữ liệu";
            g.DrawString($"Điểm trung bình: {diemTB}", fontThuong, Brushes.Black, left, top);
            top += 25;

            string diemCao = ketQua.DiemCaoNhat.HasValue ? ketQua.DiemCaoNhat.Value.ToString("0.0") : "-";
            string diemThap = ketQua.DiemThapNhat.HasValue ? ketQua.DiemThapNhat.Value.ToString("0.0") : "-";
            g.DrawString($"Điểm cao nhất: {diemCao}   -   Điểm thấp nhất: {diemThap}", fontThuong, Brushes.Black, left, top);
            top += 25;

            int tongSoLuotXepLoai = ketQua.SoHoanThanhTot + ketQua.SoHoanThanh + ketQua.SoChuaHoanThanh;

            g.DrawString(
                $"Hoàn thành tốt: {ketQua.SoHoanThanhTot} ({PhanTram(ketQua.SoHoanThanhTot, tongSoLuotXepLoai)})" +
                $"   -   Hoàn thành: {ketQua.SoHoanThanh} ({PhanTram(ketQua.SoHoanThanh, tongSoLuotXepLoai)})" +
                $"   -   Chưa hoàn thành: {ketQua.SoChuaHoanThanh} ({PhanTram(ketQua.SoChuaHoanThanh, tongSoLuotXepLoai)})",
                fontThuong, Brushes.Black, left, top
            );
            top += 45;

            g.DrawString($"Ngày in: {DateTime.Now:dd/MM/yyyy}", fontThuong, Brushes.Black, left, top);
        }
    }
}
