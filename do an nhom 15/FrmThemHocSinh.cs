using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmThemHocSinh : Form
    {
        private readonly HocSinhService _hocSinhService;
        private readonly string _maLopPhuTrach;

        public FrmThemHocSinh(string maLopPhuTrach, string tenLopPhuTrach)
        {
            InitializeComponent();

            _hocSinhService = new HocSinhService();
            _maLopPhuTrach = maLopPhuTrach;

            GiaoDien.ApDungTuDong(this);

            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            dtpNgaySinh.MaxDate = DateTime.Today;
            dtpNgaySinh.Value = DateTime.Today;

            lblLop.Text = "Lớp: " + tenLopPhuTrach + "  (tự động gán theo lớp phụ trách)";

            btnLuu.Click += btnLuu_Click;
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            var ketQua = _hocSinhService.Them(
                txtMaHocSinh.Text,
                txtHoTen.Text,
                dtpNgaySinh.Value,
                cboGioiTinh.Text,
                _maLopPhuTrach
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