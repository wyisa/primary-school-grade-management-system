using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmQuanLyHocSinh : Form
    {
        private readonly HocSinhService _hocSinhService;
        private readonly LopHocService _lopHocService;
        private string _maLopPhuTrach = string.Empty;
        private string _tenLopPhuTrach = string.Empty;

        public FrmQuanLyHocSinh()
        {
            InitializeComponent();

            _hocSinhService = new HocSinhService();
            _lopHocService = new LopHocService();

            btnThemMoi.Click += btnThemMoi_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTaoTaiKhoanPhuHuynh.Click += btnTaoTaiKhoanPhuHuynh_Click;
            dgvHocSinh.SelectionChanged += dgvHocSinh_SelectionChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            ApDungGiaoDien();

            LoadDanhSachHocSinh();
        }

        // Áp theme xanh lá: banner gradient, thẻ thống kê đa sắc, toolbar nhiều màu, bảng nổi khối
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);

            // Banner tiêu đề: nền gradient, icon + chữ trắng, huy hiệu lớp trên nền tối
            GiaoDien.VeNenGradient(pnlHeader, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam, 120f);
            lblIconTieuDe.BackColor = Color.Transparent;
            lblTieuDe.BackColor = Color.Transparent;
            GiaoDien.LamDepNhanBadge(lblLopPhuTrach, Color.White, GiaoDien.MauXanhDam);

            pnlThongKe.BackColor = GiaoDien.MauNen;

            // 3 thẻ thống kê nhanh, mỗi thẻ một màu riêng
            LamDepTheThongKe(pnlTheTong, lblIconTong, lblSoTong, lblNhanTong, GiaoDien.MauXanhNhat, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam);
            LamDepTheThongKe(pnlTheNam, lblIconNam, lblSoNam, lblNhanNam, GiaoDien.MauXanhDuongNhat, GiaoDien.MauXanhDuong, GiaoDien.MauXanhDuongHover);
            LamDepTheThongKe(pnlTheNu, lblIconNu, lblSoNu, lblNhanNu, GiaoDien.MauHongNhat, GiaoDien.MauHong, GiaoDien.MauHongHover);

            // Toolbar: khối nổi bo góc, mỗi nút một màu để bảng thao tác thêm sinh động
            GiaoDien.LamDepThe(pnlToolbar, 14);
            GiaoDien.LamDepNhanPhu(lblTimKiem);
            GiaoDien.LamDepTextBox(txtTimKiem);

            GiaoDien.LamDepNut(btnThemMoi, GiaoDien.KieuNut.Chinh, 10);
            GiaoDien.LamDepNut(btnSua, GiaoDien.KieuNut.XanhDuong, 10);
            GiaoDien.LamDepNut(btnXoa, GiaoDien.KieuNut.NguyHiem, 10);
            GiaoDien.LamDepNut(btnTaoTaiKhoanPhuHuynh, GiaoDien.KieuNut.Tim, 10);

            // Khung bảng nổi khối, bo góc, có viền nhẹ bao quanh lưới dữ liệu
            GiaoDien.LamDepThe(pnlBangCard, 16);
            GiaoDien.LamDepBang(dgvHocSinh);
        }

        // Thẻ thống kê: icon tròn màu nổi bật, số liệu lớn, nhãn mô tả phía dưới
        private static void LamDepTheThongKe(Panel the, Label icon, Label soLuong, Label nhan, Color mauNhat, Color mauDam, Color mauChuSo)
        {
            GiaoDien.LamDepThe(the, 16);

            icon.BackColor = mauNhat;
            icon.ForeColor = mauDam;
            GiaoDien.BoGocTron(icon, 28);

            soLuong.ForeColor = mauChuSo;
            nhan.ForeColor = GiaoDien.MauChuPhu;
        }

        private void LoadDanhSachHocSinh()
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

            List<HocSinh> danhSach = _hocSinhService.LayDanhSachTheoLop(_maLopPhuTrach);

            lblLopPhuTrach.Text = $"🏫 {_tenLopPhuTrach}  •  {danhSach.Count} học sinh";

            CapNhatTheThongKe(danhSach);

            HienThiLenLuoi(danhSach);
        }

        // Cập nhật số liệu trên 3 thẻ thống kê nhanh (Tổng số, Nam, Nữ)
        private void CapNhatTheThongKe(List<HocSinh> danhSach)
        {
            int soNam = danhSach.Count(hs => hs.GioiTinh == "Nam");
            int soNu = danhSach.Count(hs => hs.GioiTinh == "Nữ");

            lblSoTong.Text = danhSach.Count.ToString();
            lblSoNam.Text = soNam.ToString();
            lblSoNu.Text = soNu.ToString();
        }

        private void HienThiLenLuoi(List<HocSinh> danhSach)
        {
            dgvHocSinh.AutoGenerateColumns = true;
            dgvHocSinh.DataSource = null;
            dgvHocSinh.DataSource = danhSach;

            if (dgvHocSinh.Columns.Contains("MaLop"))
            {
                dgvHocSinh.Columns["MaLop"]!.Visible = false;
            }

            if (dgvHocSinh.Columns.Contains("MaHocSinh"))
            {
                dgvHocSinh.Columns["MaHocSinh"]!.HeaderText = "Mã học sinh";
            }

            if (dgvHocSinh.Columns.Contains("HoTen"))
            {
                dgvHocSinh.Columns["HoTen"]!.HeaderText = "Họ và tên";
            }

            if (dgvHocSinh.Columns.Contains("NgaySinh"))
            {
                dgvHocSinh.Columns["NgaySinh"]!.HeaderText = "Ngày sinh";
                dgvHocSinh.Columns["NgaySinh"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvHocSinh.Columns.Contains("GioiTinh"))
            {
                dgvHocSinh.Columns["GioiTinh"]!.HeaderText = "Giới tính";
            }
        }

        private void dgvHocSinh_SelectionChanged(object? sender, EventArgs e)
        {
            // Không cần đổ dữ liệu ra ô nhập nữa vì đã chuyển sang popup
        }

        private void btnThemMoi_Click(object? sender, EventArgs e)
        {
            using FrmThemHocSinh frm = new FrmThemHocSinh(_maLopPhuTrach, _tenLopPhuTrach);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachHocSinh();
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (dgvHocSinh.CurrentRow?.DataBoundItem is not HocSinh hocSinh)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using FrmSuaHocSinh frm = new FrmSuaHocSinh(hocSinh, _tenLopPhuTrach);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachHocSinh();
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (dgvHocSinh.CurrentRow?.DataBoundItem is not HocSinh hocSinh)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa học sinh này?\nToàn bộ điểm, đánh giá phẩm chất/năng lực và tài khoản phụ huynh (nếu có) của học sinh này sẽ bị xóa vĩnh viễn theo.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            var ketQua = _hocSinhService.Xoa(hocSinh.MaHocSinh, _maLopPhuTrach);

            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LoadDanhSachHocSinh();
            }
        }

        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            List<HocSinh> ketQua = _hocSinhService.TimKiem(_maLopPhuTrach, txtTimKiem.Text);
            HienThiLenLuoi(ketQua);
        }

        private void btnTaoTaiKhoanPhuHuynh_Click(object? sender, EventArgs e)
        {
            if (dgvHocSinh.CurrentRow?.DataBoundItem is not HocSinh hocSinh)
            {
                MessageBox.Show(
                    "Vui lòng chọn học sinh trên bảng để tạo tài khoản phụ huynh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using FrmTaoTaiKhoanPhuHuynh frm = new FrmTaoTaiKhoanPhuHuynh(hocSinh);
            frm.ShowDialog();
        }
    }
}