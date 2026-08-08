namespace do_an_nhom_15
{
    partial class FrmLogin
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
            pnlThuongHieu = new Panel();
            lblBieuTuong = new Label();
            lblThuongHieuTieuDe = new Label();
            lblThuongHieuPhu = new Label();
            pnlCard = new Panel();
            lnkDangKy = new LinkLabel();
            btnDangNhap = new Button();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            lblPhuDe = new Label();
            lblTieuDe = new Label();
            pnlThuongHieu.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlThuongHieu
            // 
            pnlThuongHieu.Controls.Add(lblThuongHieuPhu);
            pnlThuongHieu.Controls.Add(lblThuongHieuTieuDe);
            pnlThuongHieu.Controls.Add(lblBieuTuong);
            pnlThuongHieu.Dock = DockStyle.Left;
            pnlThuongHieu.Location = new Point(0, 0);
            pnlThuongHieu.Name = "pnlThuongHieu";
            pnlThuongHieu.Size = new Size(380, 520);
            pnlThuongHieu.TabIndex = 0;
            // 
            // lblBieuTuong
            // 
            lblBieuTuong.AutoSize = false;
            lblBieuTuong.Font = new Font("Segoe UI Emoji", 42F);
            lblBieuTuong.ForeColor = Color.White;
            lblBieuTuong.Location = new Point(0, 150);
            lblBieuTuong.Name = "lblBieuTuong";
            lblBieuTuong.Size = new Size(380, 80);
            lblBieuTuong.TabIndex = 0;
            lblBieuTuong.Text = "🎓";
            lblBieuTuong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThuongHieuTieuDe
            // 
            lblThuongHieuTieuDe.AutoSize = false;
            lblThuongHieuTieuDe.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblThuongHieuTieuDe.ForeColor = Color.White;
            lblThuongHieuTieuDe.Location = new Point(30, 240);
            lblThuongHieuTieuDe.Name = "lblThuongHieuTieuDe";
            lblThuongHieuTieuDe.Size = new Size(320, 90);
            lblThuongHieuTieuDe.TabIndex = 1;
            lblThuongHieuTieuDe.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM";
            lblThuongHieuTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThuongHieuPhu
            // 
            lblThuongHieuPhu.AutoSize = false;
            lblThuongHieuPhu.Font = new Font("Segoe UI", 10.5F);
            lblThuongHieuPhu.ForeColor = Color.White;
            lblThuongHieuPhu.Location = new Point(40, 330);
            lblThuongHieuPhu.Name = "lblThuongHieuPhu";
            lblThuongHieuPhu.Size = new Size(300, 60);
            lblThuongHieuPhu.TabIndex = 2;
            lblThuongHieuPhu.Text = "Kết nối nhà trường - giáo viên - phụ huynh";
            lblThuongHieuPhu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.Controls.Add(lnkDangKy);
            pnlCard.Controls.Add(btnDangNhap);
            pnlCard.Controls.Add(txtMatKhau);
            pnlCard.Controls.Add(lblMatKhau);
            pnlCard.Controls.Add(txtTenDangNhap);
            pnlCard.Controls.Add(lblTenDangNhap);
            pnlCard.Controls.Add(lblPhuDe);
            pnlCard.Controls.Add(lblTieuDe);
            pnlCard.Location = new Point(440, 75);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(420, 370);
            pnlCard.TabIndex = 1;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = false;
            lblTieuDe.Location = new Point(0, 34);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(420, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG NHẬP";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPhuDe
            // 
            lblPhuDe.AutoSize = false;
            lblPhuDe.Location = new Point(0, 68);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(420, 20);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Nhập thông tin tài khoản để tiếp tục";
            lblPhuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(40, 118);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(85, 15);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(40, 138);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(340, 30);
            txtTenDangNhap.TabIndex = 3;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(40, 183);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(57, 15);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(40, 203);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(340, 30);
            txtMatKhau.TabIndex = 5;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(40, 258);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(340, 42);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = true;
            // 
            // lnkDangKy
            // 
            lnkDangKy.AutoSize = false;
            lnkDangKy.Location = new Point(40, 316);
            lnkDangKy.Name = "lnkDangKy";
            lnkDangKy.Size = new Size(340, 20);
            lnkDangKy.TabIndex = 7;
            lnkDangKy.TabStop = true;
            lnkDangKy.Text = "Chưa có tài khoản? Đăng ký tài khoản giáo viên";
            lnkDangKy.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 520);
            Controls.Add(pnlCard);
            Controls.Add(pnlThuongHieu);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            pnlThuongHieu.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlThuongHieu;
        private Label lblBieuTuong;
        private Label lblThuongHieuTieuDe;
        private Label lblThuongHieuPhu;
        private Panel pnlCard;
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private LinkLabel lnkDangKy;
    }
}
