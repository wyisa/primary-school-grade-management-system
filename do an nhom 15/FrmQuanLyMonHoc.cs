using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmQuanLyMonHoc : Form
    {
        private readonly MonHocService _monHocService;

        public FrmQuanLyMonHoc()
        {
            InitializeComponent();

            _monHocService = new MonHocService();

            GiaoDien.ApDungTuDong(this);

            cboHinhThucDanhGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHinhThucDanhGia.Items.Clear();
            cboHinhThucDanhGia.Items.Add("Điểm số");
            cboHinhThucDanhGia.Items.Add("Nhận xét");

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;

            LoadDanhSach();
        }

        private void LoadDanhSach()
        {
            List<MonHoc> danhSach = _monHocService.LayTatCa();

            dgvMonHoc.AutoGenerateColumns = true;
            dgvMonHoc.DataSource = null;
            dgvMonHoc.DataSource = danhSach;

            if (dgvMonHoc.Columns.Contains("MaMon"))
            {
                dgvMonHoc.Columns["MaMon"]!.HeaderText = "Mã môn";
            }

            if (dgvMonHoc.Columns.Contains("TenMon"))
            {
                dgvMonHoc.Columns["TenMon"]!.HeaderText = "Tên môn học";
            }

            if (dgvMonHoc.Columns.Contains("HinhThucDanhGia"))
            {
                dgvMonHoc.Columns["HinhThucDanhGia"]!.HeaderText = "Hình thức đánh giá";
            }
        }

        private void dgvMonHoc_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvMonHoc.CurrentRow?.DataBoundItem is not MonHoc monHoc)
            {
                return;
            }

            txtMaMon.Text = monHoc.MaMon;
            txtTenMon.Text = monHoc.TenMon;
            cboHinhThucDanhGia.Text = monHoc.HinhThucDanhGia;

            // Không cho sửa mã môn sau khi đã chọn (mã là khóa chính)
            txtMaMon.Enabled = false;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            var ketQua = _monHocService.Them(txtMaMon.Text, txtTenMon.Text, cboHinhThucDanhGia.Text);

            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();
                LoadDanhSach();
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            var ketQua = _monHocService.Sua(txtMaMon.Text, txtTenMon.Text, cboHinhThucDanhGia.Text);

            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();
                LoadDanhSach();
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn môn học cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa môn học này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            var ketQua = _monHocService.Xoa(txtMaMon.Text);

            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();
                LoadDanhSach();
            }
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            cboHinhThucDanhGia.SelectedIndex = -1;
            txtMaMon.Enabled = true;
        }
    }
}