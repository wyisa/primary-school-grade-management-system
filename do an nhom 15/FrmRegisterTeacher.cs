using do_an_nhom_15.Models;
using do_an_nhom_15.Services;
using do_an_nhom_15.UI;

namespace do_an_nhom_15
{
    public partial class FrmRegisterTeacher : Form
    {
        private readonly TaiKhoanService _taiKhoanService;
        private readonly LopHocService _lopHocService;

        public FrmRegisterTeacher()
        {
            InitializeComponent();

            // Khởi tạo Service
            _taiKhoanService = new TaiKhoanService();
            _lopHocService = new LopHocService();

            GiaoDien.ApDungTuDong(this);

            // Chỉ cho phép chọn lớp có sẵn
            cboLopPhuTrach.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // Gắn sự kiện cho các nút
            btnDangKy.Click += btnDangKy_Click;
            btnQuayLai.Click += btnQuayLai_Click;

            // Tải danh sách lớp
            LoadDanhSachLop();
        }

        // ==========================================
        // TẢI DANH SÁCH LỚP VÀO COMBOBOX
        // ==========================================
        private void LoadDanhSachLop()
        {
            try
            {
                List<LopHoc> danhSachLop =
                    _lopHocService.LayTatCa();

                if (danhSachLop.Count == 0)
                {
                    MessageBox.Show(
                        "Hiện chưa có lớp học nào trong hệ thống.\n" +
                        "Vui lòng tạo lớp trước khi đăng ký giáo viên.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // Xóa dữ liệu cũ
                cboLopPhuTrach.DataSource = null;

                // Thiết lập dữ liệu cho ComboBox
                cboLopPhuTrach.DisplayMember = "TenLop";
                cboLopPhuTrach.ValueMember = "MaLop";
                cboLopPhuTrach.DataSource = danhSachLop;

                // Chưa chọn lớp nào
                cboLopPhuTrach.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách lớp.\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ==========================================
        // NÚT ĐĂNG KÝ
        // ==========================================
        private void btnDangKy_Click(
            object? sender,
            EventArgs e)
        {
            string tenDangNhap =
                txtTenDangNhap.Text.Trim();

            string matKhau =
                txtMatKhau.Text;

            string hoTen =
                txtHoTen.Text.Trim();

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(tenDangNhap))
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

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(matKhau))
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

            // Kiểm tra nhập lại mật khẩu
            if (matKhau != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show(
                    "Mật khẩu nhập lại không khớp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNhapLaiMatKhau.Focus();

                return;
            }

            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ và tên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHoTen.Focus();

                return;
            }

            // Kiểm tra lớp phụ trách
            if (
                cboLopPhuTrach.SelectedIndex == -1 ||
                cboLopPhuTrach.SelectedValue == null
            )
            {
                MessageBox.Show(
                    "Vui lòng chọn lớp phụ trách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cboLopPhuTrach.Focus();

                return;
            }

            // Lấy mã lớp được chọn
            string maLopPhuTrach =
                cboLopPhuTrach.SelectedValue.ToString()!;

            // Gọi Service đăng ký
            var ketQua =
                _taiKhoanService.DangKyGiaoVien(
                    tenDangNhap,
                    matKhau,
                    hoTen,
                    maLopPhuTrach
                );

            // Hiển thị kết quả
            MessageBox.Show(
                ketQua.ThongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning
            );

            // Nếu đăng ký thành công -> quay lại Form đăng nhập
            if (ketQua.ThanhCong)
            {
                FrmLogin frmLogin =
                    new FrmLogin();

                frmLogin.Show();

                this.Hide();
            }
        }

        // ==========================================
        // NÚT QUAY LẠI
        // ==========================================
        private void btnQuayLai_Click(
            object? sender,
            EventArgs e)
        {
            FrmLogin frmLogin =
                new FrmLogin();

            frmLogin.Show();

            this.Hide();
        }
    }
}