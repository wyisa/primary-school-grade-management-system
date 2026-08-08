using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmTaoTaiKhoanPhuHuynh : Form
    {
        private readonly TaiKhoanService _taiKhoanService;
        private readonly HocSinh _hocSinh;

        public FrmTaoTaiKhoanPhuHuynh(HocSinh hocSinh)
        {
            InitializeComponent();

            _taiKhoanService = new TaiKhoanService();
            _hocSinh = hocSinh;

            GiaoDien.ApDungTuDong(this);

            lblHocSinh.Text = "Học sinh: " + hocSinh.MaHocSinh + " - " + hocSinh.HoTen;

            btnTaoTaiKhoan.Click += btnTaoTaiKhoan_Click;
        }

        private void btnTaoTaiKhoan_Click(object? sender, EventArgs e)
        {
            var ketQua = _taiKhoanService.DangKyPhuHuynh(
                txtTenDangNhap.Text,
                txtMatKhau.Text,
                _hocSinh.MaHocSinh,
                _hocSinh.HoTen
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

        private void FrmTaoTaiKhoanPhuHuynh_Load(object sender, EventArgs e)
        {



        }
    }
}