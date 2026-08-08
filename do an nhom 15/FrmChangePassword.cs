using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmChangePassword : Form
    {
        private readonly TaiKhoanService _taiKhoanService;

        public FrmChangePassword()
        {
            InitializeComponent();

            _taiKhoanService = new TaiKhoanService();

            GiaoDien.ApDungTuDong(this);

            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;

            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
        }

        private void btnDoiMatKhau_Click(object? sender, EventArgs e)
        {
            if (SessionManager.TaiKhoanDangNhap == null)
            {
                MessageBox.Show(
                    "Phiên đăng nhập đã hết hạn.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var ketQua = _taiKhoanService.DoiMatKhau(
                SessionManager.TaiKhoanDangNhap.TenDangNhap,
                txtMatKhauCu.Text,
                txtMatKhauMoi.Text,
                txtNhapLaiMatKhau.Text
            );

            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}