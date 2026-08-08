namespace do_an_nhom_15
{
    partial class FrmTaoTaiKhoanPhuHuynh
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
            lblHocSinh = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnTaoTaiKhoan = new Button();
            SuspendLayout();
            // 
            // lblHocSinh
            // 
            lblHocSinh.AutoSize = true;
            lblHocSinh.Location = new Point(68, 62);
            lblHocSinh.Name = "lblHocSinh";
            lblHocSinh.Size = new Size(54, 15);
            lblHocSinh.TabIndex = 0;
            lblHocSinh.Text = "Học sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 111);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 160);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(158, 111);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(200, 23);
            txtTenDangNhap.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(158, 157);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(200, 23);
            txtMatKhau.TabIndex = 5;
            // 
            // btnTaoTaiKhoan
            // 
            btnTaoTaiKhoan.Location = new Point(74, 254);
            btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            btnTaoTaiKhoan.Size = new Size(194, 34);
            btnTaoTaiKhoan.TabIndex = 6;
            btnTaoTaiKhoan.Text = "TẠO TÀI KHOẢN PHỤ HUYNH";
            btnTaoTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // FrmTaoTaiKhoanPhuHuynh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 340);
            Controls.Add(btnTaoTaiKhoan);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblHocSinh);
            Name = "FrmTaoTaiKhoanPhuHuynh";
            Text = "TẠO TÀI KHOẢN PHỤ HUYNH";
            Load += FrmTaoTaiKhoanPhuHuynh_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHocSinh;
        private Label label2;
        private Label label3;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Button btnTaoTaiKhoan;
    }
}