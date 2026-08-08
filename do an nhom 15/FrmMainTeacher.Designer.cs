namespace do_an_nhom_15
{
    partial class FrmMainTeacher
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btnDangXuat = new Button();
            btnDoiMatKhau = new Button();
            btnThongKe = new Button();
            btnQuanLyDiem = new Button();
            btnQuanLyHocSinh = new Button();
            lblTenHeThong = new Label();
            pnlNoiDung = new Panel();
            btnTheThongKe = new Button();
            btnTheDiem = new Button();
            btnTheHocSinh = new Button();
            lblLopPhuTrach = new Label();
            lblChaoMung = new Label();
            lblTieuDe = new Label();
            pnlMenu.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnDangXuat);
            pnlMenu.Controls.Add(btnDoiMatKhau);
            pnlMenu.Controls.Add(btnThongKe);
            pnlMenu.Controls.Add(btnQuanLyDiem);
            pnlMenu.Controls.Add(btnQuanLyHocSinh);
            pnlMenu.Controls.Add(lblTenHeThong);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(230, 560);
            pnlMenu.TabIndex = 0;
            // 
            // lblTenHeThong
            // 
            lblTenHeThong.AutoSize = false;
            lblTenHeThong.Location = new Point(0, 26);
            lblTenHeThong.Name = "lblTenHeThong";
            lblTenHeThong.Size = new Size(230, 34);
            lblTenHeThong.TabIndex = 0;
            lblTenHeThong.Text = "QUẢN LÝ ĐIỂM";
            lblTenHeThong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnQuanLyHocSinh
            // 
            btnQuanLyHocSinh.Location = new Point(0, 100);
            btnQuanLyHocSinh.Name = "btnQuanLyHocSinh";
            btnQuanLyHocSinh.Size = new Size(230, 46);
            btnQuanLyHocSinh.TabIndex = 1;
            btnQuanLyHocSinh.Text = "🎓   Quản lý học sinh";
            btnQuanLyHocSinh.UseVisualStyleBackColor = true;
            // 
            // btnQuanLyDiem
            // 
            btnQuanLyDiem.Location = new Point(0, 150);
            btnQuanLyDiem.Name = "btnQuanLyDiem";
            btnQuanLyDiem.Size = new Size(230, 46);
            btnQuanLyDiem.TabIndex = 2;
            btnQuanLyDiem.Text = "📊   Quản lý điểm";
            btnQuanLyDiem.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(0, 200);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(230, 46);
            btnThongKe.TabIndex = 3;
            btnThongKe.Text = "📈   Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(0, 250);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(230, 46);
            btnDoiMatKhau.TabIndex = 4;
            btnDoiMatKhau.Text = "🔑   Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDangXuat.Location = new Point(20, 490);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(190, 40);
            btnDangXuat.TabIndex = 5;
            btnDangXuat.Text = "🚪  Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(btnTheThongKe);
            pnlNoiDung.Controls.Add(btnTheDiem);
            pnlNoiDung.Controls.Add(btnTheHocSinh);
            pnlNoiDung.Controls.Add(lblLopPhuTrach);
            pnlNoiDung.Controls.Add(lblChaoMung);
            pnlNoiDung.Controls.Add(lblTieuDe);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(230, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Size = new Size(730, 560);
            pnlNoiDung.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(40, 36);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(149, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM";
            // 
            // lblChaoMung
            // 
            lblChaoMung.AutoSize = true;
            lblChaoMung.Location = new Point(40, 82);
            lblChaoMung.Name = "lblChaoMung";
            lblChaoMung.Size = new Size(121, 15);
            lblChaoMung.TabIndex = 1;
            lblChaoMung.Text = "Chào mừng giáo viên";
            // 
            // lblLopPhuTrach
            // 
            lblLopPhuTrach.AutoSize = true;
            lblLopPhuTrach.Location = new Point(40, 108);
            lblLopPhuTrach.Name = "lblLopPhuTrach";
            lblLopPhuTrach.Size = new Size(84, 15);
            lblLopPhuTrach.TabIndex = 2;
            lblLopPhuTrach.Text = "Lớp phụ trách:";
            // 
            // btnTheHocSinh
            // 
            btnTheHocSinh.Location = new Point(40, 170);
            btnTheHocSinh.Name = "btnTheHocSinh";
            btnTheHocSinh.Size = new Size(195, 130);
            btnTheHocSinh.TabIndex = 3;
            btnTheHocSinh.Text = "🎓\r\n\r\nQuản lý học sinh";
            btnTheHocSinh.UseVisualStyleBackColor = true;
            // 
            // btnTheDiem
            // 
            btnTheDiem.Location = new Point(255, 170);
            btnTheDiem.Name = "btnTheDiem";
            btnTheDiem.Size = new Size(195, 130);
            btnTheDiem.TabIndex = 4;
            btnTheDiem.Text = "📊\r\n\r\nQuản lý điểm";
            btnTheDiem.UseVisualStyleBackColor = true;
            // 
            // btnTheThongKe
            // 
            btnTheThongKe.Location = new Point(470, 170);
            btnTheThongKe.Name = "btnTheThongKe";
            btnTheThongKe.Size = new Size(195, 130);
            btnTheThongKe.TabIndex = 5;
            btnTheThongKe.Text = "📈\r\n\r\nThống kê";
            btnTheThongKe.UseVisualStyleBackColor = true;
            // 
            // FrmMainTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 560);
            Controls.Add(pnlNoiDung);
            Controls.Add(pnlMenu);
            MinimumSize = new Size(880, 500);
            Name = "FrmMainTeacher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý điểm";
            pnlMenu.ResumeLayout(false);
            pnlNoiDung.ResumeLayout(false);
            pnlNoiDung.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Button btnDangXuat;
        private Button btnDoiMatKhau;
        private Button btnThongKe;
        private Button btnQuanLyDiem;
        private Button btnQuanLyHocSinh;
        private Label lblTenHeThong;
        private Panel pnlNoiDung;
        private Label lblLopPhuTrach;
        private Label lblChaoMung;
        private Label lblTieuDe;
        private Button btnTheHocSinh;
        private Button btnTheDiem;
        private Button btnTheThongKe;
    }
}
