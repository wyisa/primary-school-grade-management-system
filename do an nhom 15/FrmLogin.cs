using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmLogin : Form
    {
        private readonly TaiKhoanService _taiKhoanService;

        public FrmLogin()
        {
            InitializeComponent();

            _taiKhoanService =
                new TaiKhoanService();

            txtMatKhau.UseSystemPasswordChar =
                true;

            ApDungGiaoDien();

            // Gắn sự kiện cho nút Đăng nhập
            btnDangNhap.Click +=
                btnDangNhap_Click;

            // Gắn sự kiện cho nút Đăng ký
            lnkDangKy.Click +=
                lnkDangKy_Click;
        }

        // Áp theme xanh lá nhẹ nhàng cho toàn bộ control trên form
        private void ApDungGiaoDien()
        {
            GiaoDien.ApDungNenForm(this);

            // Panel thương hiệu bên trái: nền gradient đậm dần, chữ trắng nổi bật
            GiaoDien.VeNenGradient(pnlThuongHieu, GiaoDien.MauXanhChinh, GiaoDien.MauXanhDam, 120f);
            lblThuongHieuTieuDe.BackColor = Color.Transparent;
            lblThuongHieuPhu.BackColor = Color.Transparent;
            lblBieuTuong.BackColor = Color.Transparent;

            GiaoDien.LamDepThe(pnlCard, 18);

            GiaoDien.LamDepTieuDe(lblTieuDe, lon: true);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            GiaoDien.LamDepNhanPhu(lblPhuDe);
            lblPhuDe.TextAlign = ContentAlignment.MiddleCenter;

            GiaoDien.LamDepNhanPhu(lblTenDangNhap);
            GiaoDien.LamDepNhanPhu(lblMatKhau);

            GiaoDien.LamDepTextBox(txtTenDangNhap);
            GiaoDien.LamDepTextBox(txtMatKhau);

            GiaoDien.LamDepNut(btnDangNhap, GiaoDien.KieuNut.Chinh, 10);

            GiaoDien.LamDepLinkLabel(lnkDangKy);
            lnkDangKy.TextAlign = ContentAlignment.MiddleCenter;
        }

        // NÚT ĐĂNG NHẬP
        private void btnDangNhap_Click(
            object? sender,
            EventArgs e)
        {
            string tenDangNhap =
                txtTenDangNhap.Text.Trim();

            string matKhau =
                txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(
                tenDangNhap))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên đăng nhập.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenDangNhap.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(
                matKhau))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtMatKhau.Focus();

                return;
            }

            TaiKhoan? taiKhoan =
                _taiKhoanService.DangNhap(
                    tenDangNhap,
                    matKhau
                );

            if (taiKhoan == null)
            {
                MessageBox.Show(
                    "Tên đăng nhập hoặc mật khẩu không đúng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Lưu tài khoản đang đăng nhập
            SessionManager.TaiKhoanDangNhap =
                taiKhoan;

            MessageBox.Show(
                "Đăng nhập thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (taiKhoan.VaiTro == "Giáo viên")
            {
                FrmMainTeacher frmMainTeacher =
                    new FrmMainTeacher();

                frmMainTeacher.Show();

                this.Hide();
            }
            else if (taiKhoan.VaiTro == "Phụ huynh")
            {
                FrmXemDiemCon frmXemDiemCon =
                    new FrmXemDiemCon();

                frmXemDiemCon.Show();

                this.Hide();
            }
        }

        // NÚT ĐĂNG KÝ
        private void lnkDangKy_Click(
            object? sender,
            EventArgs e)
        {
            FrmRegisterTeacher
                frmRegisterTeacher =
                new FrmRegisterTeacher();

            frmRegisterTeacher.Show();

            this.Hide();
        }
    }
}