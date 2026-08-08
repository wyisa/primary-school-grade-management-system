namespace do_an_nhom_15
{
    partial class FrmRegisterTeacher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            lblNhapLaiMatKhau = new Label();
            lblHoTen = new Label();
            lblLopPhuTrach = new Label();
            btnDangKy = new Button();
            btnQuayLai = new Button();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            txtNhapLaiMatKhau = new TextBox();
            txtHoTen = new TextBox();
            cboLopPhuTrach = new ComboBox();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(132, 38);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(180, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN GIÁO VIÊN";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(53, 87);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(85, 15);
            lblTenDangNhap.TabIndex = 1;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(53, 123);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(57, 15);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblNhapLaiMatKhau
            // 
            lblNhapLaiMatKhau.AutoSize = true;
            lblNhapLaiMatKhau.Location = new Point(53, 160);
            lblNhapLaiMatKhau.Name = "lblNhapLaiMatKhau";
            lblNhapLaiMatKhau.Size = new Size(104, 15);
            lblNhapLaiMatKhau.TabIndex = 11;
            lblNhapLaiMatKhau.Text = "Nhập lại mật khẩu";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(52, 202);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(58, 15);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ và tên";
            // 
            // lblLopPhuTrach
            // 
            lblLopPhuTrach.AutoSize = true;
            lblLopPhuTrach.Location = new Point(52, 244);
            lblLopPhuTrach.Name = "lblLopPhuTrach";
            lblLopPhuTrach.Size = new Size(81, 15);
            lblLopPhuTrach.TabIndex = 4;
            lblLopPhuTrach.Text = "Lớp phụ trách";
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(82, 279);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(75, 36);
            btnDangKy.TabIndex = 5;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(296, 279);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(82, 36);
            btnQuayLai.TabIndex = 6;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(257, 79);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(100, 23);
            txtTenDangNhap.TabIndex = 7;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(257, 123);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(100, 23);
            txtMatKhau.TabIndex = 8;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtNhapLaiMatKhau
            // 
            txtNhapLaiMatKhau.Location = new Point(257, 160);
            txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            txtNhapLaiMatKhau.Size = new Size(100, 23);
            txtNhapLaiMatKhau.TabIndex = 12;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(257, 202);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(100, 23);
            txtHoTen.TabIndex = 9;
            // 
            // cboLopPhuTrach
            // 
            cboLopPhuTrach.FormattingEnabled = true;
            cboLopPhuTrach.Location = new Point(257, 236);
            cboLopPhuTrach.Name = "cboLopPhuTrach";
            cboLopPhuTrach.Size = new Size(121, 23);
            cboLopPhuTrach.TabIndex = 10;
            // 
            // FrmRegisterTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 334);
            Controls.Add(cboLopPhuTrach);
            Controls.Add(txtHoTen);
            Controls.Add(txtNhapLaiMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(btnQuayLai);
            Controls.Add(btnDangKy);
            Controls.Add(lblLopPhuTrach);
            Controls.Add(lblHoTen);
            Controls.Add(lblNhapLaiMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTenDangNhap);
            Controls.Add(lblTieuDe);
            Name = "FrmRegisterTeacher";
            Text = "ĐĂNG KÝ TÀI KHOẢN GIÁO VIÊN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTenDangNhap;
        private Label lblMatKhau;
        private Label lblNhapLaiMatKhau;
        private Label lblHoTen;
        private Label lblLopPhuTrach;
        private Button btnDangKy;
        private Button btnQuayLai;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private TextBox txtNhapLaiMatKhau;
        private TextBox txtHoTen;
        private ComboBox cboLopPhuTrach;
    }
}