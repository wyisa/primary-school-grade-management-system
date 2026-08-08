using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmQuanLyLop : Form
    {
        private readonly LopHocService _lopHocService;

        public FrmQuanLyLop()
        {
            InitializeComponent();

            _lopHocService =
                new LopHocService();

            GiaoDien.ApDungTuDong(this);

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            dgvLopHoc.CellClick +=
                dgvLopHoc_CellClick;

            LoadDanhSachLop();
        }

        // Tải danh sách lớp
        private void LoadDanhSachLop()
        {
            try
            {
                dgvLopHoc.DataSource = null;

                dgvLopHoc.DataSource =
                    _lopHocService.LayTatCa();

                dgvLopHoc.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách lớp.\n\n"
                    + ex.Message,

                    "Lỗi",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Error
                );
            }
        }

        // Thêm lớp
        private void btnThem_Click(
            object? sender,
            EventArgs e)
        {
            var ketQua =
                _lopHocService.ThemLop(
                    txtMaLop.Text,
                    txtTenLop.Text
                );

            MessageBox.Show(
                ketQua.ThongBao,

                "Thông báo",

                MessageBoxButtons.OK,

                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();

                LoadDanhSachLop();
            }
        }

        // Sửa lớp
        private void btnSua_Click(
            object? sender,
            EventArgs e)
        {
            var ketQua =
                _lopHocService.SuaLop(
                    txtMaLop.Text,
                    txtTenLop.Text
                );

            MessageBox.Show(
                ketQua.ThongBao,

                "Thông báo",

                MessageBoxButtons.OK,

                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();

                LoadDanhSachLop();
            }
        }

        // Xóa lớp
        private void btnXoa_Click(
            object? sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtMaLop.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn lớp cần xóa.",

                    "Thông báo",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp này?",

                    "Xác nhận",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            var ketQua =
                _lopHocService.XoaLop(
                    txtMaLop.Text
                );

            MessageBox.Show(
                ketQua.ThongBao,

                "Thông báo",

                MessageBoxButtons.OK,

                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            if (ketQua.ThanhCong)
            {
                LamMoi();

                LoadDanhSachLop();
            }
        }

        // Làm mới
        private void btnLamMoi_Click(
            object? sender,
            EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaLop.Clear();

            txtTenLop.Clear();

            txtMaLop.Focus();
        }

        // Chọn dòng trong DataGridView
        private void dgvLopHoc_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvLopHoc.Rows[e.RowIndex];

            txtMaLop.Text =
                row.Cells["MaLop"]
                .Value?
                .ToString();

            txtTenLop.Text =
                row.Cells["TenLop"]
                .Value?
                .ToString();
        }
    }
}