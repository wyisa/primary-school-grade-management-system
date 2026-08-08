using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmMainTeacher : Form
    {
        private readonly LopHocService _lopHocService;

        public FrmMainTeacher()
        {
            InitializeComponent();

            _lopHocService = new LopHocService();

            ApDungGiaoDien();

            // Gắn sự kiện cho các nút menu bên sidebar
            btnQuanLyHocSinh.Click += btnQuanLyHocSinh_Click;
            btnQuanLyDiem.Click += btnQuanLyDiem_Click;
            btnThongKe.Click += btnThongKe_Click;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            btnDangXuat.Click += btnDangXuat_Click;

            // Gắn sự kiện cho các thẻ truy cập nhanh (dùng chung xử lý với menu)
            btnTheHocSinh.Click += btnQuanLyHocSinh_Click;
            btnTheDiem.Click += btnQuanLyDiem_Click;
            btnTheThongKe.Click += btnThongKe_Click;

            HienThiThongTinGiaoVien();
        }

        // Áp theme xanh lá nhẹ nhàng: sidebar gradient đậm, khu nội dung trắng, thẻ truy cập nhanh đa sắc
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);

            GiaoDien.VeNenGradient(pnlMenu, GiaoDien.MauXanhDam, GiaoDien.MauXanhDamHover, 90f);
            pnlNoiDung.BackColor = GiaoDien.MauTrang;

            lblTenHeThong.ForeColor = Color.White;
            lblTenHeThong.Font = GiaoDien.FontTieuDeNho;
            lblTenHeThong.BackColor = Color.Transparent;

            GiaoDien.LamDepNutMenu(btnQuanLyHocSinh);
            GiaoDien.LamDepNutMenu(btnQuanLyDiem);
            GiaoDien.LamDepNutMenu(btnThongKe);
            GiaoDien.LamDepNutMenu(btnDoiMatKhau);
            GiaoDien.LamDepNut(btnDangXuat, GiaoDien.KieuNut.NguyHiem, 8);

            GiaoDien.LamDepTieuDe(lblTieuDe, lon: true);
            GiaoDien.LamDepNhanPhu(lblChaoMung);
            GiaoDien.LamDepNhanPhu(lblLopPhuTrach);

            // Mỗi thẻ truy cập nhanh một màu riêng để trang chủ sinh động, dễ phân biệt chức năng
            LamDepThe(btnTheHocSinh, GiaoDien.MauXanhNhat, GiaoDien.MauXanhDam, GiaoDien.MauXanhChinh);
            LamDepThe(btnTheDiem, GiaoDien.MauXanhDuongNhat, GiaoDien.MauXanhDuongHover, GiaoDien.MauXanhDuong);
            LamDepThe(btnTheThongKe, GiaoDien.MauCamNhat, GiaoDien.MauCamHover, GiaoDien.MauCam);
        }

        // Thẻ truy cập nhanh trên trang chủ: nền màu nhạt riêng, chữ đậm, bo góc, đổi màu khi rê chuột
        private static void LamDepThe(Button b, Color mauNen, Color mauChu, Color mauVienHover)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = GiaoDien.MauVien;
            b.BackColor = mauNen;
            b.ForeColor = mauChu;
            b.Font = GiaoDien.FontTieuDeNho;
            b.Cursor = Cursors.Hand;
            b.TextAlign = ContentAlignment.MiddleCenter;

            b.MouseEnter += (s, e) =>
            {
                b.BackColor = ControlPaintLighten(mauVienHover);
                b.FlatAppearance.BorderColor = mauVienHover;
            };
            b.MouseLeave += (s, e) =>
            {
                b.BackColor = mauNen;
                b.FlatAppearance.BorderColor = GiaoDien.MauVien;
            };
        }

        private static Color ControlPaintLighten(Color mauGoc)
        {
            return Color.FromArgb(255,
                Math.Min(255, mauGoc.R + 60),
                Math.Min(255, mauGoc.G + 60),
                Math.Min(255, mauGoc.B + 60));
        }

        // Hiển thị tên giáo viên và lớp phụ trách
        private void HienThiThongTinGiaoVien()
        {
            TaiKhoan? taiKhoan = SessionManager.TaiKhoanDangNhap;

            if (taiKhoan == null)
            {
                return;
            }

            lblChaoMung.Text =
                "Chào mừng giáo viên: " + taiKhoan.HoTen;

            string tenLop = taiKhoan.MaLopPhuTrach ?? "";

            try
            {
                LopHoc? lop = _lopHocService
                    .LayTatCa()
                    .FirstOrDefault(l => l.MaLop == taiKhoan.MaLopPhuTrach);

                if (lop != null)
                {
                    tenLop = lop.TenLop;
                }
            }
            catch
            {
                // Nếu không tải được danh sách lớp thì vẫn hiển thị mã lớp
            }

            lblLopPhuTrach.Text = "Lớp phụ trách: " + tenLop;
        }

        // Mở Form quản lý học sinh
        private void btnQuanLyHocSinh_Click(
            object? sender,
            EventArgs e)
        {
            using FrmQuanLyHocSinh frm = new FrmQuanLyHocSinh();
            frm.ShowDialog();
        }

        // Mở Form quản lý điểm
        private void btnQuanLyDiem_Click(
            object? sender,
            EventArgs e)
        {
            using FrmQuanLyDiem frm = new FrmQuanLyDiem();
            frm.ShowDialog();
        }

        // Mở Form thống kê
        private void btnThongKe_Click(
            object? sender,
            EventArgs e)
        {
            using FrmThongKe frm = new FrmThongKe();
            frm.ShowDialog();
        }

        // Mở Form đổi mật khẩu
        private void btnDoiMatKhau_Click(
            object? sender,
            EventArgs e)
        {
            using FrmChangePassword frm = new FrmChangePassword();
            frm.ShowDialog();
        }

        // Đăng xuất
        private void btnDangXuat_Click(
            object? sender,
            EventArgs e)
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